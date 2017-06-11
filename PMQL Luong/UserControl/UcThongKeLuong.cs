using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System.Data.SqlClient;
using PMQL_Luong.Entities;
using System.Drawing.Printing;
using System.Text.RegularExpressions;

namespace PMQL_Luong.UserControl
{
    public partial class UcThongKeLuong : DevExpress.XtraEditors.XtraUserControl
    {
        private SqlConnection strConnect;
        private List<NhanVien> listNV;
        private string manv = "";
        private int nam = 0;
        private int thang = 0;        
        private DataTable table;
        private User user;

        public UcThongKeLuong(SqlConnection strConnect)
        {
            InitializeComponent();
            this.strConnect = strConnect;
        }

        private void UcThongKeLuong_Load(object sender, EventArgs e)
        {
            TinhNgayThang();
            Load_PhongBan_cmb();
            Load_ChucVu_cmb();
            Load_ThongTin_NhanVien();
        }

        private void TaoSTT_GridView(GridView grv, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (!grv.IsGroupRow(e.RowHandle)) //Nếu không phải là Group
            {
                if (e.Info.IsRowIndicator) //Nếu là dòng Indicator
                {
                    if (e.RowHandle < 0)
                    {
                        e.Info.ImageIndex = 0;
                        e.Info.DisplayText = string.Empty;
                    }
                    else
                    {
                        e.Info.ImageIndex = -1; //Không hiển thị hình
                        e.Info.DisplayText = (e.RowHandle + 1).ToString(); //Số thứ tự tăng dần
                    }
                    SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font); //Lấy kích thước của vùng hiển thị Text
                    Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                    BeginInvoke(new MethodInvoker(delegate { cal(_Width, grv); })); //Tăng kích thước nếu Text vượt quá
                }
            }
            else
            {
                e.Info.ImageIndex = -1;
                e.Info.DisplayText = string.Format("[{0}]", (e.RowHandle * -1)); //Nhân -1 để đánh lại số thứ tự tăng dần
                SizeF _Size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
                Int32 _Width = Convert.ToInt32(_Size.Width) + 20;
                BeginInvoke(new MethodInvoker(delegate { cal(_Width, grv); }));
            }
        }

        private bool cal(Int32 _Width, GridView _View)
        {
            _View.IndicatorWidth = _View.IndicatorWidth < _Width ? _Width : _View.IndicatorWidth;
            return true;
        }

        private void grv_DSnhanvien_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            TaoSTT_GridView(grv_DSnhanvien, e);
        }

        private void grv_TienThuong_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            TaoSTT_GridView(grv_TienThuong, e);
        }

        private void grv_TienPhat_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            TaoSTT_GridView(grv_TienPhat, e);
        }

        private void TinhNgayThang()
        {
            try
            {
                string temp = dtp_NgayThang.Value.ToShortDateString();
                string[] A = temp.Split('/');
                thang = int.Parse(A[0]);
                nam = int.Parse(A[2]);
                if (thang != 0 && nam != 0)
                {
                    lbl_NgayThang.Text = "Tháng " + thang + " năm " + nam;
                }
                else
                {
                    lbl_NgayThang.Text = "";
                }
            }
            catch
            {
                XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Load_ThongTin_NhanVien()
        {
            listNV = new List<NhanVien>();
            try
            {
                SqlCommand comma = new SqlCommand("SP_ThongKeLuong", strConnect);
                comma.CommandType = CommandType.StoredProcedure;
                comma.Parameters.Add(new SqlParameter("@manv", txt_MaNV.Text));
                comma.Parameters.Add(new SqlParameter("@tennv", txt_TenNV.Text));
                comma.Parameters.Add(new SqlParameter("@trinhdo", cmb_HocVan.Text));
                comma.Parameters.Add(new SqlParameter("@phongban", cmb_PhongBan.Text));
                comma.Parameters.Add(new SqlParameter("@chucvu", cmb_ChucVu.Text));
                SqlDataAdapter da2 = new SqlDataAdapter(comma);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);

                object[] objLista;
                DataRowCollection rowLista = dt2.Rows;

                for (int i = 0; i < rowLista.Count; i++)
                {
                    NhanVien objNhanVien = new NhanVien();
                    objLista = rowLista[i].ItemArray;
                    objNhanVien.manv = objLista[0].ToString();
                    objNhanVien.tennv = objLista[1].ToString();
                    objNhanVien.hocvan = objLista[2].ToString();
                    objNhanVien.phongban = objLista[3].ToString();
                    objNhanVien.chucvu = objLista[4].ToString();
                    objNhanVien.luongthang = double.Parse(objLista[5].ToString());
                    listNV.Add(objNhanVien);
                }

            }
            catch
            {
                XtraMessageBox.Show("Thông tin tìm kiếm không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            for (int i = 0; i < listNV.Count; i++)
            {
                SqlCommand comm = new SqlCommand("SP_TinhTienThuong", strConnect);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@manv", listNV[i].manv));
                comm.Parameters.Add(new SqlParameter("@thang", thang));
                comm.Parameters.Add(new SqlParameter("@nam", nam));
                SqlDataAdapter da = new SqlDataAdapter(comm);
                System.Data.DataTable dtp = new DataTable();
                da.Fill(dtp);

                object[] objList;
                DataRowCollection rowList = dtp.Rows;
                try
                {
                    objList = rowList[0].ItemArray;
                    listNV[i].tienthuong = double.Parse(objList[0].ToString());
                }
                catch
                {
                    listNV[i].tienthuong = 0;
                }
            }

            for (int i = 0; i < listNV.Count; i++)
            {
                SqlCommand comm1 = new SqlCommand("SP_TinhTienPhat", strConnect);
                comm1.CommandType = CommandType.StoredProcedure;
                comm1.Parameters.Add(new SqlParameter("@manv", listNV[i].manv));
                comm1.Parameters.Add(new SqlParameter("@thang", thang));
                comm1.Parameters.Add(new SqlParameter("@nam", nam));
                SqlDataAdapter da1 = new SqlDataAdapter(comm1);
                System.Data.DataTable dt1 = new DataTable();
                da1.Fill(dt1);

                object[] objList1;
                DataRowCollection rowList1 = dt1.Rows;
                try
                {
                    objList1 = rowList1[0].ItemArray;
                    listNV[i].tienphat = double.Parse(objList1[0].ToString());
                }
                catch
                {
                    listNV[i].tienphat = 0;
                }
            }

            for (int i = 0; i < listNV.Count; i++)
            {
                listNV[i].tongtien = listNV[i].luongthang + listNV[i].tienthuong - listNV[i].tienphat;
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Mã nhân viên");
            dt.Columns.Add("Tên nhân viên");
            dt.Columns.Add("Trình độ");
            dt.Columns.Add("Phòng ban");
            dt.Columns.Add("Chức vụ");
            dt.Columns.Add("Lương nhân viên (VNĐ)");
            dt.Columns.Add("Tiền thưởng (VNĐ)");
            dt.Columns.Add("Tiền phạt (VNĐ)");
            dt.Columns.Add("Tổng tiền (VNĐ)");

            for (int i = 0; i < listNV.Count; i++)
            {
                DataRow dtRow = dt.NewRow();
                dtRow[0] = listNV[i].manv;
                dtRow[1] = listNV[i].tennv;
                dtRow[2] = listNV[i].hocvan;
                dtRow[3] = listNV[i].phongban;
                dtRow[4] = listNV[i].chucvu;
                dtRow[5] = listNV[i].luongthang.ToString("#,###");
                dtRow[6] = listNV[i].tienthuong.ToString("#,###");
                dtRow[7] = listNV[i].tienphat.ToString("#,###");
                dtRow[8] = listNV[i].tongtien.ToString("#,###");
                dt.Rows.Add(dtRow);
            }
            table = dt;

            grc_DSnhanvien.DataSource = dt;
            grv_DSnhanvien.Columns["Mã nhân viên"].BestFit();
            grv_DSnhanvien.Columns["Tên nhân viên"].BestFit();
            grv_DSnhanvien.Columns["Trình độ"].BestFit();
            grv_DSnhanvien.Columns["Phòng ban"].BestFit();
            grv_DSnhanvien.Columns["Chức vụ"].BestFit();
            grv_DSnhanvien.Columns["Lương nhân viên (VNĐ)"].BestFit();
            grv_DSnhanvien.Columns["Tiền thưởng (VNĐ)"].BestFit();
            grv_DSnhanvien.Columns["Tiền phạt (VNĐ)"].BestFit();
            grv_DSnhanvien.Columns["Tổng tiền (VNĐ)"].BestFit();
        }

        private void Load_PhongBan_cmb()
        {
            SqlCommand comm = new SqlCommand("select maphongban,tenphongban from phongban", strConnect);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmb_PhongBan.DataSource = dt;
            cmb_PhongBan.DisplayMember = "tenphongban";
            cmb_PhongBan.ValueMember = "maphongban";
            cmb_PhongBan.SelectedIndex = -1;
        }

        private void Load_ChucVu_cmb()
        {
            SqlCommand comm = new SqlCommand("select machucvu,tenchucvu from chucvu", strConnect);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmb_ChucVu.DataSource = dt;
            cmb_ChucVu.DisplayMember = "tenchucvu";
            cmb_ChucVu.ValueMember = "machucvu";
            cmb_ChucVu.SelectedIndex = -1;
        }

        private void txt_MaNV_EditValueChanged(object sender, EventArgs e)
        {
            Load_ThongTin_NhanVien();
        }

        private void txt_TenNV_EditValueChanged(object sender, EventArgs e)
        {
            Load_ThongTin_NhanVien();
        }

        private void cmb_HocVan_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_ThongTin_NhanVien();
        }

        private void cmb_PhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_ThongTin_NhanVien();
        }

        private void cmb_ChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_ThongTin_NhanVien();
        }

        private void grv_DSnhanvien_Click(object sender, EventArgs e)
        {
            try
            {
                panel_ChiTiet.Visible = true;
                manv = grv_DSnhanvien.GetRowCellValue(grv_DSnhanvien.FocusedRowHandle, "Mã nhân viên").ToString();
                lbl_MaNV.Text = manv;
                lbl_TenNV.Text = grv_DSnhanvien.GetRowCellValue(grv_DSnhanvien.FocusedRowHandle, "Tên nhân viên").ToString();
                Load_ChiTietPhat();
                Load_ChiTietThuong();
            }
            catch
            {
                XtraMessageBox.Show("Không có nhân viên nào", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Tat_Click(object sender, EventArgs e)
        {
            panel_ChiTiet.Visible = false;
        }

        private void Load_ChiTietPhat()
        {
            SqlCommand comm = new SqlCommand("SP_HienThiChiTietTienPhat", strConnect);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.Add(new SqlParameter("@manv", manv));
            comm.Parameters.Add(new SqlParameter("@thang", thang));
            comm.Parameters.Add(new SqlParameter("@nam", nam));
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            grc_TienPhat.DataSource = dt;
            grv_TienPhat.Columns["manhanvien"].Caption = "Mã nhân viên";
            grv_TienPhat.Columns["tennhanvien"].Caption = "Tên nhân viên";
            grv_TienPhat.Columns["ngay"].Caption = "Ngày bị phạt";
            grv_TienPhat.Columns["tenmucphat"].Caption = "Nguyên nhân";
            grv_TienPhat.Columns["giatri"].Caption = "Tiền phạt";

        }

        private void Load_ChiTietThuong()
        {
            SqlCommand comm = new SqlCommand("SP_HienThiChiTietTienThuong", strConnect);
            comm.Parameters.Add(new SqlParameter("@manv", manv));
            comm.Parameters.Add(new SqlParameter("@thang", thang));
            comm.Parameters.Add(new SqlParameter("@nam", nam));
            comm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);

            grc_TienThuong.DataSource = dt;
            grv_TienThuong.Columns["manhanvien"].Caption = "Mã nhân viên";
            grv_TienThuong.Columns["tennhanvien"].Caption = "Tên nhân viên";
            grv_TienThuong.Columns["ngay"].Caption = "Tháng được thưởng";
            grv_TienThuong.Columns["mota"].Caption = "Thành tích";
            grv_TienThuong.Columns["giatri"].Caption = "Tiền thưởng";
        }

        private void dtp_NgayThang_ValueChanged(object sender, EventArgs e)
        {
            TinhNgayThang();
            Load_ThongTin_NhanVien();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Load_ThongTin_NhanVien();
        }

        private void btn_InBangLuong_Click(object sender, EventArgs e)
        {
            save.InitialDirectory = "C:";
            save.Title = "Lưu ra file Excel";
            save.FileName = "";
            save.Filter = "Excel File(2013)|*.xlsx|Excel File(2007)|*.xls";
            if(save.ShowDialog() != DialogResult.Cancel)
            {
                Microsoft.Office.Interop.Excel.Application ExceApp = new Microsoft.Office.Interop.Excel.Application();
                ExceApp.Application.Workbooks.Add(Type.Missing);

                ExceApp.Columns.ColumnWidth = 25;

                for(int i = 1;i<grv_DSnhanvien.Columns.Count + 1;i++)
                {
                    ExceApp.Cells[1, i] = grv_DSnhanvien.Columns[i - 1].GetTextCaption();
                }

                for(int i = 0; i < grv_DSnhanvien.RowCount; i++)
                {
                    for(int j = 0;j<grv_DSnhanvien.Columns.Count;j++)
                    {
                        ExceApp.Cells[i + 2, j + 1] = table.Rows[i][j];
                    }
                }
                ExceApp.ActiveWorkbook.SaveCopyAs(save.FileName.ToString());
                ExceApp.ActiveWorkbook.Saved = true;
                ExceApp.Quit();
                XtraMessageBox.Show("In bảng lương thành công", "Thông báo", MessageBoxButtons.OK);          
            }

        }
    }
}
