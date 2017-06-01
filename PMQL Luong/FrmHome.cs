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
        private XtraTabPage xtraQuanLyTaiKhoan;
        private XtraTabPage xtraHeSoLuong;
        private XtraTabPage xtraTienPhat;
        private XtraTabPage xtraTienThuong;
        private XtraTabPage xtraChucVu;
        private XtraTabPage xtraTimKiemNhanVien;
        private XtraTabPage xtraTienTamUng;
        private XtraTabPage xtraThongKeNhanVien;
        private XtraTabPage xtraNhanVien;
        private UcPhongBan ucPhongban;
        private UcQuanLyTaiKhoan ucQuanlytaikhoan;
        private UcHeSoLuong ucHesoluong;
        private UcTienphat ucTienphat;
        private UcTienThuong ucTienthuong;
        private UcChucVu ucChucvu;
        private UcTimkiem ucTimkiemNhanvien;
        private UcUngtien ucTientamung;
        private UcThongkeNhanvien ucThongkenhanvien;
        private UcNhanVien ucNhanvien;

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
                case "user":
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

        private void btnDangXuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmDangNhap = new FrmDangNhap(strConnect);
            frmDangNhap.ICall = this;
            frmDangNhap.Show();
            this.Hide();
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

        private void btnNguoiDung_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!xtraTabMain.TabPages.Contains(xtraQuanLyTaiKhoan))
            {
                xtraQuanLyTaiKhoan = new XtraTabPage();
                ucQuanlytaikhoan = new UcQuanLyTaiKhoan(strConnect, user);
                xtraQuanLyTaiKhoan.Controls.Add(ucQuanlytaikhoan);
                xtraTabMain.TabPages.Add(xtraQuanLyTaiKhoan);

                xtraQuanLyTaiKhoan.Text = "Quản lý tài khoản";
                ucQuanlytaikhoan.Dock = DockStyle.Fill;
            }
            xtraTabMain.SelectedTabPage = xtraQuanLyTaiKhoan;
        }

        private void btnHeSoLuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!xtraTabMain.TabPages.Contains(xtraHeSoLuong))
            {
                xtraHeSoLuong = new XtraTabPage();
                ucHesoluong = new UcHeSoLuong(strConnect, user);
                xtraHeSoLuong.Controls.Add(ucHesoluong);
                xtraTabMain.TabPages.Add(xtraHeSoLuong);

                xtraHeSoLuong.Text = "Quản lý hệ số lương";
                ucHesoluong.Dock = DockStyle.Fill;
            }
            xtraTabMain.SelectedTabPage = xtraHeSoLuong;
        }

        private void btnTienPhat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!xtraTabMain.TabPages.Contains(xtraTienPhat))
            {
                xtraTienPhat = new XtraTabPage();
                ucTienphat = new UcTienphat(strConnect, user);
                xtraTienPhat.Controls.Add(ucTienphat);
                xtraTabMain.TabPages.Add(xtraTienPhat);

                xtraTienPhat.Text = "Tiền phạt nhân viên";
                ucTienphat.Dock = DockStyle.Fill;
            }
            xtraTabMain.SelectedTabPage = xtraTienPhat;
        }

        private void btnTienThuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!xtraTabMain.TabPages.Contains(xtraTienThuong))
            {
                xtraTienThuong = new XtraTabPage();
                ucTienthuong = new UcTienThuong(strConnect, user);
                xtraTienThuong.Controls.Add(ucTienthuong);
                xtraTabMain.TabPages.Add(xtraTienThuong);

                xtraTienThuong.Text = "Tiền thưởng nhân viên";
                ucTienthuong.Dock = DockStyle.Fill;
            }
            xtraTabMain.SelectedTabPage = xtraTienThuong;
        }

        private void btnChucVu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!xtraTabMain.TabPages.Contains(xtraChucVu))
            {
                xtraChucVu = new XtraTabPage();
                ucChucvu = new UcChucVu(strConnect, user);
                xtraChucVu.Controls.Add(ucChucvu);
                xtraTabMain.TabPages.Add(xtraChucVu);

                xtraChucVu.Text = "Quản lý chức vụ";
                ucChucvu.Dock = DockStyle.Fill;
            }
            xtraTabMain.SelectedTabPage = xtraChucVu;
        }

        private void btnTimKiemNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!xtraTabMain.TabPages.Contains(xtraTimKiemNhanVien))
            {
                xtraTimKiemNhanVien = new XtraTabPage();
                ucTimkiemNhanvien = new UcTimkiem(strConnect);
                xtraTimKiemNhanVien.Controls.Add(ucTimkiemNhanvien);
                xtraTabMain.TabPages.Add(xtraTimKiemNhanVien);

                xtraTimKiemNhanVien.Text = "Tìm kiếm thông tin nhân viên";
                ucTimkiemNhanvien.Dock = DockStyle.Fill;
            }
            xtraTabMain.SelectedTabPage = xtraTimKiemNhanVien;
        }

        private void btnTamUng_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!xtraTabMain.TabPages.Contains(xtraTienTamUng))
            {
                xtraTienTamUng = new XtraTabPage();
                ucTientamung = new UcUngtien(strConnect, user);
                xtraTienTamUng.Controls.Add(ucTientamung);
                xtraTabMain.TabPages.Add(xtraTienTamUng);

                xtraTienTamUng.Text = "Tiền nhân viên tạm ứng";
                ucTientamung.Dock = DockStyle.Fill;
            }
            xtraTabMain.SelectedTabPage = xtraTienTamUng;
        }

        private void btnDanhSachNV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!xtraTabMain.TabPages.Contains(xtraThongKeNhanVien))
            {
                xtraThongKeNhanVien = new XtraTabPage();
                ucThongkenhanvien = new UcThongkeNhanvien(strConnect);
                xtraThongKeNhanVien.Controls.Add(ucThongkenhanvien);
                xtraTabMain.TabPages.Add(xtraThongKeNhanVien);

                xtraThongKeNhanVien.Text = "Thống kê nhân viên";
                ucThongkenhanvien.Dock = DockStyle.Fill;
            }
            xtraTabMain.SelectedTabPage = xtraThongKeNhanVien;
        }

        private void btnNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (!xtraTabMain.TabPages.Contains(xtraNhanVien))
            {
                xtraNhanVien = new XtraTabPage();
                ucNhanvien = new UcNhanVien(strConnect, user);
                xtraNhanVien.Controls.Add(ucNhanvien);
                xtraTabMain.TabPages.Add(xtraNhanVien);

                xtraNhanVien.Text = "Quản lý nhân viên";
                ucNhanvien.Dock = DockStyle.Fill;
            }
            xtraTabMain.SelectedTabPage = xtraNhanVien;
        }
    }
}
