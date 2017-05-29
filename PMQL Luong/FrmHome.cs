using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using PMQL_Luong.Entities;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using PMQL_Luong.UserControl;

namespace PMQL_Luong
{
    public partial class FrmHome : DevExpress.XtraBars.Ribbon.RibbonForm, ICallBack
    {
        private User user;
        private FrmDangNhap frmDangNhap;
        private SqlConnection strConnect;

        private XtraTabPage xtraPhongBan;
        private XtraTabPage xtraLuongCoBan;
        private UcPhongBan ucPhongban;
        private UcLuongCoBan ucLuongcoban;

        public FrmHome()
        {
            InitializeComponent();
            try
            {
                //CÁC THÀNH VIÊN LƯU Ý KHÔNG ĐƯỢC THAY ĐỔI BẤT CỨ THÔNG TIN GÌ Ở strConnect 
                strConnect = new SqlConnection(@"Server = (local) ; Database=PMQUANLYLUONG; Trusted_Connection = true");
                strConnect.Open();
            }
            catch
            {
                strConnect = new SqlConnection(@"Server = (local)\SQLEXPRESS ; Database=PMQUANLYLUONG; Trusted_Connection = true");
                strConnect.Open();
            }
            frmDangNhap = new FrmDangNhap(strConnect);
            frmDangNhap.ICall = this;
            frmDangNhap.Show();
        }

        public void loginSuccess(User user)
        {
            this.user = user;
            this.Show();
            foreach (XtraTabPage xTraPage in xtraTabMain.TabPages)
            {
                if (xTraPage.Text.Equals("Trang chủ"))
                {
                    xtraTabPage1 = xTraPage;
                    break;
                }
            }
            xtraTabMain.TabPages.Clear();
            xtraTabMain.TabPages.Add(xtraTabPage1);
            switch (user.Permission)
            {
                case "superadmin":
                    {
                        txtTenNguoiDung.Caption = "Giám đốc: ";
                        break;
                    }
                case "admin":
                    {
                        txtTenNguoiDung.Caption = "Quản lý: ";
                        break;
                    }
                case "client":
                    {
                        txtTenNguoiDung.Caption = "Nhân viên: ";
                        break;
                    }
            }
            txtTenNguoiDung.Caption = txtTenNguoiDung.Caption + user.Name;
        }

        public void formClosing()
        {
            this.Dispose();
        }

        private void xtraTabMain_CloseButtonClick(object sender, EventArgs e)
        {
            ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
            (arg.Page as XtraTabPage).Dispose();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {
            //DevExpress.UserSkins.BonusSkins.Register();
            //DevExpress.XtraBars.Helpers.SkinHelper.InitSkinGallery(ribbonGalleryBarItem1, true);
            timer1.Start();
        }

        private void FrmHome_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            string datetime = "";
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
                datetime = "Thứ hai ";
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Tuesday)
                datetime = "Thứ ba ";
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Wednesday)
                datetime = "Thứ tư ";
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Thursday)
                datetime = "Thứ năm ";
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
                datetime = "Thứ sáu ";
            else if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
                datetime = "Thứ bảy ";
            else
                datetime = "Chủ nhật ";

            datetime = datetime + "ngày " + day + " tháng " + month + " năm " + year;
            datetime = datetime + ", " + DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDangNhap = new FrmDangNhap(strConnect);
            frmDangNhap.ICall = this;
            frmDangNhap.Show();
            this.Hide();
        }

        private void btnPhongBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!xtraTabMain.TabPages.Contains(xtraPhongBan))
            {
                xtraPhongBan = new XtraTabPage();
                ucPhongban = new UcPhongBan(strConnect, user);
                xtraPhongBan.Controls.Add(ucPhongban);
                xtraTabMain.TabPages.Add(xtraPhongBan);

                xtraPhongBan.Text = "Quản lý phòng ban";
                ucPhongban.Dock = DockStyle.Fill;
            }
            xtraTabMain.SelectedTabPage = xtraPhongBan;
        }

        private void btnLuongCoBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!xtraTabMain.TabPages.Contains(xtraLuongCoBan))
            {
                xtraLuongCoBan = new XtraTabPage();
                ucLuongcoban = new UcLuongCoBan(strConnect, user);
                xtraLuongCoBan.Controls.Add(ucLuongcoban);
                xtraTabMain.TabPages.Add(xtraLuongCoBan);

                xtraLuongCoBan.Text = "Lương cơ bản của nhân viên";
                ucLuongcoban.Dock = DockStyle.Fill;
            }
            xtraTabMain.SelectedTabPage = xtraLuongCoBan;
        }
    }
}
