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
using DevExpress.XtraGrid.Views.Grid;

namespace PMQL_Luong.UserControl
{
    public partial class UcHeSoLuong : DevExpress.XtraEditors.XtraUserControl
    {
        private SqlConnection strConnect;
        private User user;

        public UcHeSoLuong(SqlConnection strConnect, User user)
        {
            InitializeComponent();
            this.strConnect = strConnect;
            this.user = user;

            if (!KiemTraQuyenTruyCap())
                btn_them.Enabled = false;
            else
                btn_them.Enabled = true;
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
            btn_luu.Visible = false;
            btn_huy.Visible = false;
        }

        private void UcHeSoLuong_Load(object sender, EventArgs e)
        {
            loadDataHesoluong();
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

        private void loadDataHesoluong()
        {
            try
            {
                SqlCommand command = new SqlCommand("select * from hesoluong", strConnect);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grid_hesoluong.DataSource = dt;
                grv_hesoluong.Columns["maheso"].Caption = "Mã hệ số";
                grv_hesoluong.Columns["giatri"].Caption = "Hệ số";
                grv_hesoluong.Columns["mota"].Caption = "Mô tả";
                grv_hesoluong.BestFitColumns();
            }
            catch { }
        }

        private void grv_hesoluong_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            TaoSTT_GridView(grv_hesoluong, e);
        }

        private bool checkHeso()
        {
            bool check = true;
            try
            {
                float heso = float.Parse(txt_giatri.Text);
                check = true;
            }
            catch
            {
                check = false;
            }
            return check;
        }

        private void txt_giatri_EditValueChanged(object sender, EventArgs e)
        {
            if (!checkHeso())
            {
                errGiatri.Icon = Properties.Resources.ic_nook;
                errGiatri.SetError(txt_giatri, "Hệ số không phù hợp");
            }
            else
            {
                errGiatri.Icon = Properties.Resources.ic_ok;
                errGiatri.SetError(txt_giatri, "Hệ số đúng");
            }
        }

        private void grv_hesoluong_Click(object sender, EventArgs e)
        {
            try
            {
                txt_mahs.Text = grv_hesoluong.GetRowCellValue(grv_hesoluong.FocusedRowHandle, "maheso").ToString();
                txt_giatri.Text = grv_hesoluong.GetRowCellValue(grv_hesoluong.FocusedRowHandle, "giatri").ToString();
                txt_mota.Text = grv_hesoluong.GetRowCellValue(grv_hesoluong.FocusedRowHandle, "mota").ToString();
                txt_nhanvien.Text = user.Name;

                if (!KiemTraQuyenTruyCap())
                {
                    btn_sua.Enabled = false;
                    btn_xoa.Enabled = false;
                }
                else
                {
                    btn_sua.Enabled = true;
                    btn_xoa.Enabled = true;
                }
                btn_luu.Visible = false;
                btn_huy.Visible = false;
            }
            catch
            {

            }
        }

        private List<string> Getdanhhesoluong(string sql)
        {
            List<string> dsma = new List<string>();
            SqlDataAdapter da = new SqlDataAdapter(sql, strConnect);
            DataTable dt = new DataTable();
            da.Fill(dt);

            DataRowCollection ds = dt.Rows;
            object[] obj;
            string temp;
            for (int i = 0; i < ds.Count; i++)
            {
                obj = ds[i].ItemArray;
                temp = obj[0].ToString();
                dsma.Add(temp);
            }
            return dsma;
        }

        private string TaoHeSoLuong()
        {
            List<string> dsma = Getdanhhesoluong("select hsl.maheso from hesoluong hsl order by hsl.maheso");
            string ma = dsma[dsma.Count - 1];
            ma = ma.Substring(2);
            int so = int.Parse(ma);
            so = so + 1;
            ma = so.ToString();
            if (so < 10)
            {
                ma = "HS00" + ma;
            }
            else if (so >= 10 && so < 100)
            {
                ma = "HS0" + ma;
            }
            else ma = "HS" + ma;
            return ma;
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            txt_mahs.Text = TaoHeSoLuong();
            txt_mahs.Enabled = false;
            txt_giatri.Text = "";
            txt_mota.Text = "";
            txt_nhanvien.Text = user.Name;

            btn_luu.Visible = true;
            btn_huy.Visible = true;
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn thay đổi hệ số lương không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    SqlCommand command = new SqlCommand("SP_SuaHeso", strConnect);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@maheso", txt_mahs.Text));
                    command.Parameters.Add(new SqlParameter("@giatri", txt_giatri.Text));
                    command.Parameters.Add(new SqlParameter("@mota", txt_mota.Text));

                    command.ExecuteNonQuery();
                    XtraMessageBox.Show("Thay đổi thông tin hệ số lương thành công", "Thông báo", MessageBoxButtons.OK);
                    loadDataHesoluong();
                    txt_mahs.Text = "";
                    txt_giatri.Text = "";
                    txt_mota.Text = "";
                    txt_nhanvien.Text = "";
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn xóa hệ số lương " + txt_mahs.Text + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    SqlCommand command = new SqlCommand("SP_XoaHeso", strConnect);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@maheso", txt_mahs.Text));

                    command.ExecuteNonQuery();
                    XtraMessageBox.Show("Xóa hệ số thành công", "Thông báo", MessageBoxButtons.OK);
                    loadDataHesoluong();
                    txt_mahs.Text = "";
                    txt_giatri.Text = "";
                    txt_mota.Text = "";
                    txt_nhanvien.Text = "";
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (txt_giatri.Text == "")
                XtraMessageBox.Show("Bạn chưa nhập hệ số", "Thông báo", MessageBoxButtons.OK);
            else if (txt_mota.Text == "")
                XtraMessageBox.Show("Điền thiếu thông tin", "Thông báo", MessageBoxButtons.OK);
            else
            {
                DialogResult dialog = XtraMessageBox.Show("Bạn có muốn thêm hệ số lương không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        SqlCommand command = new SqlCommand("SP_ThemHeso", strConnect);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@maheso", txt_mahs.Text));
                        command.Parameters.Add(new SqlParameter("@giatri", txt_giatri.Text));
                        command.Parameters.Add(new SqlParameter("@mota", txt_mota.Text));

                        command.ExecuteNonQuery();
                        XtraMessageBox.Show("Thêm hệ số thành công", "Thông báo", MessageBoxButtons.OK);
                        loadDataHesoluong();
                        txt_mahs.Text = "";
                        txt_giatri.Text = "";
                        txt_mota.Text = "";
                        txt_nhanvien.Text = "";
                        btn_luu.Visible = false;
                        btn_huy.Visible = false;
                    }
                    catch
                    {
                        XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn hủy bỏ thao tác này không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                txt_mahs.Text = "";
                txt_giatri.Text = "";
                txt_mota.Text = "";
                txt_nhanvien.Text = "";
                btn_luu.Visible = false;
                btn_huy.Visible = false;
            }
        }

        private void btn_sualuong_Click(object sender, EventArgs e)
        {
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn thay đổi lương cơ bản không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                SqlCommand command = new SqlCommand("SP_SuaLuongCoban", strConnect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@luongcoban", txt_luong.Text));

                command.ExecuteNonQuery();
                XtraMessageBox.Show("Thay đổi thông tin lương cơ bản thành công", "Thông báo", MessageBoxButtons.OK);
                txt_luong.Text = "";
            }
        }

        private void txt_luong_EditValueChanged(object sender, EventArgs e)
        {
            if (!checkHeso())
            {
                errLuong.Icon = Properties.Resources.ic_nook;
                errLuong.SetError(txt_giatri, "Hệ số không phù hợp");
            }
            else
            {
                errLuong.Icon = Properties.Resources.ic_ok;
                errLuong.SetError(txt_giatri, "Hệ số đúng");
            }
        }
    }
}
