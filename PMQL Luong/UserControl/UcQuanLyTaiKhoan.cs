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
using PMQL_Luong.Entities;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using DevExpress.XtraGrid.Views.Grid;

namespace PMQL_Luong.UserControl
{
    public partial class UcQuanLyTaiKhoan : DevExpress.XtraEditors.XtraUserControl
    {
        private SqlConnection strConnect;
        private User user;
        private string ma = "";

        public UcQuanLyTaiKhoan(SqlConnection strConnect, User user)
        {
            InitializeComponent();
            this.strConnect = strConnect;
            this.user = user;
            btnThemTK.Enabled = false;
            btnSuaTK.Enabled = false;
            btnXoaTK.Enabled = false;
        }

        private void UcQuanLyTaiKhoan_Load(object sender, EventArgs e)
        {
            if (user.Permission == "user")
                ma = user.Id;
            loadDataNhanvien();
            loadDataTaikhoan();
        }

        private bool KiemTraQuyenTruyCap()
        {
            bool check = false;
            List<string> ls = Getdanhsachnhanvien("select mataikhoan from taikhoan where quyentruycap = 'admin' or quyentruycap = 'superadmin' ");
            {
                for (int i = 0; i < ls.Count; i++)
                {
                    if (ls[i].Equals(user.Id))
                    {
                        check = true;
                        break;
                    }
                }
            }
            return check;
        }

        private List<string> Getdanhsachnhanvien(string manhanvien)
        {
            List<string> ls = new List<string>();
            SqlDataAdapter da = new SqlDataAdapter(manhanvien, strConnect);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataRowCollection ds = dt.Rows;
            Object[] obj;
            string temp;
            for (int i = 0; i < ds.Count; i++)
            {
                obj = ds[i].ItemArray;
                temp = obj[0].ToString();
                ls.Add(temp);
            }
            return ls;
        }

        private bool checkSDT(string sdt)
        {
            bool check;
            string MaNV = "(\\+84|0)\\d{9,10}$";
            check = Regex.IsMatch(sdt, MaNV);
            return check;
        }

        private void txt_sodt_EditValueChanged(object sender, EventArgs e)
        {
            if (!checkSDT(txt_sodt.Text))
            {
                errSDT.Icon = Properties.Resources.ic_nook;
                errSDT.SetError(txt_sodt, "Số điện thoại không hợp lệ");
            }
            else
            {
                errSDT.Icon = Properties.Resources.ic_ok;
                errSDT.SetError(txt_sodt, "Số điện thoại hợp lệ");
            }
        }

        private void txt_matkhau_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_matkhau.Text == "")
            {
                errMatkhau.Clear();
            }
            else if (txt_matkhau.Text.Length < 6 || txt_matkhau.Text.Length >= 15)
            {
                errMatkhau.SetError(txt_matkhau, "Password phải từ 6 đến 15 kí tự.");
                errMatkhau.Icon = Properties.Resources.ic_nook;

            }
            else
            {
                errMatkhau.SetError(txt_matkhau, "Hợp lệ");
                errMatkhau.Icon = Properties.Resources.ic_ok;
            }
        }

        private void txt_nhaplaimk_EditValueChanged(object sender, EventArgs e)
        {
            if (txt_nhaplaimk.Text == "")
            {
                errLaylaiMK.Clear();
            }
            else if (txt_nhaplaimk.Text != txt_matkhau.Text)
            {
                errLaylaiMK.SetError(txt_nhaplaimk, "Nhập sai mật khẩu.");
                errLaylaiMK.Icon = Properties.Resources.ic_nook;
            }
            else
            {
                errLaylaiMK.SetError(txt_nhaplaimk, "Hợp lệ");
                errLaylaiMK.Icon = Properties.Resources.ic_ok;
            }
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

        private void loadDataNhanvien()
        {
            try
            {
                SqlCommand command = new SqlCommand("SP_HienthiDanhsachThemTaikhoan", strConnect);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grid_nhanvien.DataSource = dt;
                grv_nhanvien.Columns["manhanvien"].Caption = "Mã nhân viên";
                grv_nhanvien.Columns["tennhanvien"].Caption = "Tên nhân viên";
                grv_nhanvien.Columns["tennhanvien"].BestFit();
                grv_nhanvien.Columns["SDT"].Caption = "Số điện thoại";
                grv_nhanvien.Columns["tenphongban"].Caption = "Phòng ban";
                grv_nhanvien.Columns["tenchucvu"].Caption = "Chức vụ";
            }
            catch { }
        }

        private void loadDataTaikhoan()
        {
            try
            {
                SqlCommand command = new SqlCommand("select tk.mataikhoan, nv.tennhanvien,case tk.matkhau when '' then null else '********' end as matkhau, tk.SDT, tk.quyentruycap from taikhoan tk inner join nhanvien nv on tk.mataikhoan = nv.manhanvien where tk.mataikhoan like N'%'+@ma+'%'", strConnect);
                command.Parameters.Add(new SqlParameter("@ma", ma)).ToString();
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grid_taikhoan.DataSource = dt;
                grv_taikhoan.Columns["mataikhoan"].Caption = "Mã tài khoản";
                grv_taikhoan.Columns["tennhanvien"].Caption = "Tên nhân viên";
                grv_taikhoan.Columns["matkhau"].Caption = "Mật khẩu";
                grv_taikhoan.Columns["SDT"].Caption = "Số điện thoại";
                grv_taikhoan.Columns["quyentruycap"].Caption = "Quyền truy cập";
            }
            catch { }
        }

        private void grv_nhanvien_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            TaoSTT_GridView(grv_nhanvien, e);
        }

        private void grv_taikhoan_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            TaoSTT_GridView(grv_taikhoan, e);
        }

        private void grv_nhanvien_Click(object sender, EventArgs e)
        {
            try
            {
                txt_manv.Text = grv_nhanvien.GetRowCellValue(grv_nhanvien.FocusedRowHandle, "manhanvien").ToString();
                txt_tennv.Text = grv_nhanvien.GetRowCellValue(grv_nhanvien.FocusedRowHandle, "tennhanvien").ToString();
                txt_sodt.Text = grv_nhanvien.GetRowCellValue(grv_nhanvien.FocusedRowHandle, "SDT").ToString();

                txt_manv.Enabled = false;
                txt_tennv.Enabled = false;
                txt_sodt.Enabled = false;
                txt_matkhau.Text = "";
                txt_nhaplaimk.Text = "";
                cmp_quyentruycap.Text = "";

                if (KiemTraQuyenTruyCap())
                {
                    btnThemTK.Enabled = true;
                    btnSuaTK.Enabled = false;
                    btnXoaTK.Enabled = false;
                }
            }
            catch { }
        }

        private void btnThemTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txt_matkhau.Text.Equals(""))
                XtraMessageBox.Show("Bạn chưa điền mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (cmp_quyentruycap.Text.Equals(""))
                XtraMessageBox.Show("Bạn chưa chọn quyền truy cập", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                DialogResult dialog = XtraMessageBox.Show("Bạn có muốn thêm tài khoản cho nhân viên này không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        SqlCommand command = new SqlCommand("SP_ThemTaikhoan", strConnect);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@mataikhoan", txt_manv.Text));
                        command.Parameters.Add(new SqlParameter("@matkhau", txt_matkhau.Text));
                        command.Parameters.Add(new SqlParameter("@quyentruycap", cmp_quyentruycap.SelectedItem));
                        command.Parameters.Add(new SqlParameter("@SDT", txt_sodt.Text));

                        command.ExecuteNonQuery();
                        XtraMessageBox.Show("Thêm tài khoản thành công", "Thống báo", MessageBoxButtons.OK);
                        loadDataNhanvien();
                        loadDataTaikhoan();

                        txt_manv.Text = "";
                        txt_tennv.Text = "";
                        txt_matkhau.Text = "";
                        txt_nhaplaimk.Text = "";
                        txt_sodt.Text = "";
                        cmp_quyentruycap.Text = "";
                    }
                    catch
                    {
                        XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void grv_taikhoan_Click(object sender, EventArgs e)
        {
            try
            {
                txt_manv.Text = grv_taikhoan.GetRowCellValue(grv_taikhoan.FocusedRowHandle, "mataikhoan").ToString();
                txt_tennv.Text = grv_taikhoan.GetRowCellValue(grv_taikhoan.FocusedRowHandle, "tennhanvien").ToString();
                txt_matkhau.Text = grv_taikhoan.GetRowCellValue(grv_taikhoan.FocusedRowHandle, "matkhau").ToString();
                txt_nhaplaimk.Text = grv_taikhoan.GetRowCellValue(grv_taikhoan.FocusedRowHandle, "matkhau").ToString();
                txt_sodt.Text = grv_taikhoan.GetRowCellValue(grv_taikhoan.FocusedRowHandle, "SDT").ToString();
                cmp_quyentruycap.Text = grv_taikhoan.GetRowCellValue(grv_taikhoan.FocusedRowHandle, "quyentruycap").ToString();

                txt_manv.Enabled = false;
                txt_tennv.Enabled = false;
                txt_sodt.Enabled = true;

                if (KiemTraQuyenTruyCap())
                {
                    btnThemTK.Enabled = false;
                    btnSuaTK.Enabled = true;
                    btnXoaTK.Enabled = true;
                    cmp_quyentruycap.Enabled = true;
                }else if(user.Permission == "user")
                {
                    btnSuaTK.Enabled = true;
                    cmp_quyentruycap.Enabled = false;
                }
            }
            catch { }
        }

        private void btnSuaTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn thay đổi tài khoản không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialog == DialogResult.Yes)
            {
                try
                {
                    SqlCommand command = new SqlCommand("SP_SuaTaiKhoan", strConnect);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@mataikhoan", txt_manv.Text));
                    command.Parameters.Add(new SqlParameter("@matkhau", txt_matkhau.Text));
                    command.Parameters.Add(new SqlParameter("@quyentruycap", cmp_quyentruycap.SelectedItem));
                    command.Parameters.Add(new SqlParameter("@SDT", txt_sodt.Text));

                    command.ExecuteNonQuery();
                    XtraMessageBox.Show("Thay đổi thông tin tài khoản thành công", "Thông báo", MessageBoxButtons.OK);
                    loadDataTaikhoan();

                    txt_manv.Text = "";
                    txt_tennv.Text = "";
                    txt_matkhau.Text = "";
                    txt_nhaplaimk.Text = "";
                    txt_sodt.Text = "";
                    cmp_quyentruycap.Text = "";
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnXoaTK_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn xoa tài khoản không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(dialog == DialogResult.Yes)
            {
                try
                {
                    SqlCommand command = new SqlCommand("SP_XoaTaiKhoan", strConnect);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@mataikhoan", txt_manv.Text));

                    command.ExecuteNonQuery();
                    XtraMessageBox.Show("Xóa tài khoản thành công", "Thông báo", MessageBoxButtons.OK);
                    loadDataTaikhoan();
                    loadDataNhanvien();

                    txt_manv.Text = "";
                    txt_tennv.Text = "";
                    txt_matkhau.Text = "";
                    txt_nhaplaimk.Text = "";
                    txt_sodt.Text = "";
                    cmp_quyentruycap.Text = "";
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
