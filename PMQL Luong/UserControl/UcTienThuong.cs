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
using PMQL_Luong.Entities;
using System.Data.SqlClient;

namespace PMQL_Luong.UserControl
{
    public partial class UcTienThuong : DevExpress.XtraEditors.XtraUserControl
    {
        private SqlConnection strConnect;
        private User user;

        public UcTienThuong(SqlConnection strConnect, User user)
        {
            InitializeComponent();
            this.strConnect = strConnect;
            this.user = user;
            if (!KiemTraQuyenTruyCap())
            {
                btn_themnv.Enabled = false;
                btn_themtien.Enabled = false;
            }
            else
            {
                btn_themtien.Enabled = true;
                btn_themnv.Enabled = true;
            }
            btn_suatien.Enabled = false;
            btn_suanv.Enabled = false;
            btn_xoatien.Enabled = false;
            btn_xoanv.Enabled = false;
            btn_luu.Visible = false;
            btn_huy.Visible = false;
            btn_luu2.Visible = false;
            btn_huy2.Visible = false;
            txt_nvghinhan.Text = user.Name;
        }

        private void UcTienThuong_Load(object sender, EventArgs e)
        {
            loadDataNhanvienthuong();
            loadDataTienthuong();
            loadComboBoxNhanvien();
            loadComboBoxMucthuong();
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

        private void loadDataTienthuong()
        {
            try
            {
                SqlCommand command = new SqlCommand("select * from tienthuong", strConnect);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grid_thuong.DataSource = dt;
                grv_thuong.Columns["mathuong"].Caption = "Mã thưởng";
                grv_thuong.Columns["mota"].Caption = "Mô tả";
                grv_thuong.Columns["giatri"].Caption = "Tiền thưởng";
            }
            catch { }
        }

        private void loadDataNhanvienthuong()
        {
            try
            {
                SqlCommand command = new SqlCommand("SP_HienthiNhanvienThuong", strConnect);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grid_nhanvien.DataSource = dt;
                grv_nhanvien.Columns["machitiet"].Visible = false;
                grv_nhanvien.Columns["tennhanvien"].Caption = "Nhân viên thưởng";
                grv_nhanvien.Columns["mota"].Caption = "Mô tả";
                grv_nhanvien.Columns["giatri"].Caption = "Tiền thưởng";
                grv_nhanvien.Columns["ngay"].Caption = "Ngày thưởng";
                grv_nhanvien.Columns["ngay"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                grv_nhanvien.Columns["ngay"].DisplayFormat.FormatString = "dd/MM/yyyy";
                grv_nhanvien.Columns["nhanvienghi"].Caption = "Nhân viên ghi nhận";
                grv_nhanvien.BestFitColumns();
            }
            catch { }
        }

        private void loadComboBoxNhanvien()
        {
            try
            {
                SqlCommand command = new SqlCommand("select * from Nhanvien", strConnect);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmp_tennv.DataSource = dt;
                cmp_tennv.DisplayMember = "tennhanvien";
                cmp_tennv.ValueMember = "manhanvien";
                cmp_tennv.SelectedIndex = -1;
            }
            catch { }
        }

        private void loadComboBoxMucthuong()
        {
            try
            {
                SqlCommand command = new SqlCommand("select * from tienthuong", strConnect);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmp_mucthuong.DataSource = dt;
                cmp_mucthuong.DisplayMember = "mota";
                cmp_mucthuong.ValueMember = "mathuong";
                cmp_mucthuong.SelectedIndex = -1;
            }
            catch { }
        }

        private List<string> Getdanhsachthuong(string sql)
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

        private string TaoMathuong()
        {
            List<string> dsma = Getdanhsachthuong("select mathuong from tienthuong order by mathuong");
            string ma = dsma[dsma.Count - 1];
            ma = ma.Substring(2);
            int so = int.Parse(ma);
            so = so + 1;
            ma = so.ToString();
            if (so < 10)
            {
                ma = "MT00" + ma;
            }
            else if (so >= 10 && so < 100)
            {
                ma = "MT0" + ma;
            }
            else ma = "MT" + ma;
            return ma;
        }

        private void grv_thuong_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            TaoSTT_GridView(grv_thuong, e);
        }

        private void grv_nhanvien_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            TaoSTT_GridView(grv_nhanvien, e);
        }

        private void grv_thuong_Click(object sender, EventArgs e)
        {
            try
            {
                txt_matienthuong.Text = grv_thuong.GetRowCellValue(grv_thuong.FocusedRowHandle, "mathuong").ToString();
                txt_mota.Text = grv_thuong.GetRowCellValue(grv_thuong.FocusedRowHandle, "mota").ToString();
                txt_giatri.Text = grv_thuong.GetRowCellValue(grv_thuong.FocusedRowHandle, "giatri").ToString();
                if (!KiemTraQuyenTruyCap())
                {
                    btn_suatien.Enabled = false;
                    btn_xoatien.Enabled = false;
                }
                else
                {
                    btn_suatien.Enabled = true;
                    btn_xoatien.Enabled = true;
                }
                btn_luu.Visible = false;
                btn_huy.Visible = false;
            }
            catch { }
        }

        private void grv_nhanvien_Click(object sender, EventArgs e)
        {
            try
            {
                string ma = grv_nhanvien.GetRowCellValue(grv_nhanvien.FocusedRowHandle, "machitiet").ToString();
                dtp_ngaythuong.Text = grv_nhanvien.GetRowCellValue(grv_nhanvien.FocusedRowHandle, "ngay").ToString();
                cmp_tennv.Text = grv_nhanvien.GetRowCellValue(grv_nhanvien.FocusedRowHandle, "tennhanvien").ToString();
                cmp_mucthuong.Text = grv_nhanvien.GetRowCellValue(grv_nhanvien.FocusedRowHandle, "mota").ToString();
                txt_nvghinhan.Text = grv_nhanvien.GetRowCellValue(grv_nhanvien.FocusedRowHandle, "nhanvienghi").ToString();

                if (!KiemTraQuyenTruyCap())
                {
                    btn_suanv.Enabled = false;
                    btn_xoanv.Enabled = false;
                }
                else
                {
                    btn_suanv.Enabled = true;
                    btn_xoanv.Enabled = true;
                }
                btn_luu2.Visible = false;
                btn_huy2.Visible = false;
            }
            catch { }
        }

        private void btn_themtien_Click(object sender, EventArgs e)
        {
            txt_matienthuong.Text = TaoMathuong();
            txt_matienthuong.Enabled = false;
            txt_mota.Text = "";
            txt_giatri.Text = "";

            btn_luu.Visible = true;
            btn_huy.Visible = true;
            btn_suatien.Enabled = false;
            btn_xoatien.Enabled = false;
        }

        private void btn_suatien_Click(object sender, EventArgs e)
        {
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn thay đổi tiền thưởng?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    SqlCommand command = new SqlCommand("SP_SuaMucThuong", strConnect);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@mathuong", txt_matienthuong.Text));
                    command.Parameters.Add(new SqlParameter("@mota", txt_mota.Text));
                    command.Parameters.Add(new SqlParameter("@giatri", txt_giatri.Text));

                    command.ExecuteNonQuery();
                    XtraMessageBox.Show("Thay đổi tiền thưởng thành công", "Thông báo", MessageBoxButtons.OK);
                    loadDataTienthuong();
                    txt_matienthuong.Text = "";
                    txt_mota.Text = "";
                    txt_giatri.Text = "";
                    loadComboBoxMucthuong();
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_xoatien_Click(object sender, EventArgs e)
        {
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn xóa mức thưởng " + txt_matienthuong.Text + " không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    SqlCommand command = new SqlCommand("SP_XoaMucThuong", strConnect);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@mathuong", txt_matienthuong.Text));

                    command.ExecuteNonQuery();
                    XtraMessageBox.Show("Xóa thành công", "Thông báo", MessageBoxButtons.OK);
                    loadDataTienthuong();
                    txt_matienthuong.Text = "";
                    txt_mota.Text = "";
                    txt_giatri.Text = "";
                    loadComboBoxMucthuong();
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_themnv_Click(object sender, EventArgs e)
        {
            txt_nvghinhan.Text = user.Name;
            cmp_tennv.Text = "";
            cmp_mucthuong.Text = "";
            dtp_ngaythuong.Text = "";

            btn_luu2.Visible = true;
            btn_huy2.Visible = true;
            btn_suanv.Enabled = false;
            btn_xoanv.Enabled = false;
        }

        private void btn_suanv_Click(object sender, EventArgs e)
        {
            string ma = grv_nhanvien.GetRowCellValue(grv_nhanvien.FocusedRowHandle, "machitiet").ToString();
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn thay đổi nhân viên thưởng không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    SqlCommand command = new SqlCommand("SP_SuaChitietThuong", strConnect);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@machitiet", ma));
                    command.Parameters.Add(new SqlParameter("@manv", cmp_tennv.SelectedValue));
                    command.Parameters.Add(new SqlParameter("@matienthuong", cmp_mucthuong.SelectedValue));
                    command.Parameters.Add(new SqlParameter("@ngay", dtp_ngaythuong.Value));
                    command.Parameters.Add(new SqlParameter("@manvghi", user.Id));

                    command.ExecuteNonQuery();
                    XtraMessageBox.Show("Thay đổi nhân viên thành công công", "Thông báo", MessageBoxButtons.OK);
                    loadDataNhanvienthuong();
                    dtp_ngaythuong.Text = "";
                    cmp_tennv.Text = "";
                    cmp_mucthuong.Text = "";
                    txt_nvghinhan.Text = "";
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_xoanv_Click(object sender, EventArgs e)
        {
            string ma = grv_nhanvien.GetRowCellValue(grv_nhanvien.FocusedRowHandle, "machitiet").ToString();
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn xóa nhân viên này không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    SqlCommand command = new SqlCommand("SP_XoaChitietThuong", strConnect);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@machitiet", ma));
                    command.ExecuteNonQuery();
                    XtraMessageBox.Show("Xóa nhân viên thành công", "Thông báo", MessageBoxButtons.OK);
                    loadDataNhanvienthuong();
                    dtp_ngaythuong.Text = "";
                    cmp_tennv.Text = "";
                    cmp_mucthuong.Text = "";
                    txt_nvghinhan.Text = "";
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn thêm mức thưởng", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    SqlCommand command = new SqlCommand("SP_ThemMucThuong", strConnect);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@mathuong", txt_matienthuong.Text)).ToString();
                    command.Parameters.Add(new SqlParameter("@mota", txt_mota.Text)).ToString();
                    command.Parameters.Add(new SqlParameter("@giatri", txt_giatri.Text)).ToString();

                    command.ExecuteNonQuery();
                    XtraMessageBox.Show("Thêm mức thưởng thành công", "Thông báo", MessageBoxButtons.OK);
                    loadDataTienthuong();
                    txt_matienthuong.Text = "";
                    txt_mota.Text = "";
                    txt_giatri.Text = "";
                    btn_luu.Visible = false;
                    btn_huy.Visible = false;
                    loadComboBoxMucthuong();
                }
                catch
                {
                    XtraMessageBox.Show("Thông tin nhập vào không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_huy_Click(object sender, EventArgs e)
        {
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn hủy bỏ thao tác này không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                txt_matienthuong.Text = "";
                txt_mota.Text = "";
                txt_giatri.Text = "";
                btn_luu.Visible = false;
                btn_huy.Visible = false;
            }
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
            if ("".Equals(txt_giatri.Text))
            {
                errGiatri.Icon = Properties.Resources.ic_nook;
                errGiatri.SetError(txt_giatri, "");
            }
            else
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
        }

        private void btn_luu2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn thêm mức thưởng cho nhân viên không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    SqlCommand command = new SqlCommand("SP_ThemChitietThuong", strConnect);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@manv", cmp_tennv.SelectedValue));
                    command.Parameters.Add(new SqlParameter("@matienthuong", cmp_mucthuong.SelectedValue));
                    command.Parameters.Add(new SqlParameter("@ngay", dtp_ngaythuong.Value));
                    command.Parameters.Add(new SqlParameter("@manvghi", user.Id));

                    command.ExecuteNonQuery();
                    XtraMessageBox.Show("Thêm nhân viên thưởng thành công", "Thông báo", MessageBoxButtons.OK);
                    loadDataNhanvienthuong();
                    dtp_ngaythuong.Text = "";
                    cmp_tennv.Text = "";
                    cmp_mucthuong.Text = "";
                    txt_nvghinhan.Text = "";
                    btn_luu2.Visible = false;
                    btn_huy2.Visible = false;
            }
                catch
            {
                XtraMessageBox.Show("Thông tin nhập vào không chính xác", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        }

        private void btn_huy2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn hủy bỏ thao tác này không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                dtp_ngaythuong.Text = "";
                cmp_tennv.Text = "";
                cmp_mucthuong.Text = "";
                txt_nvghinhan.Text = "";
                btn_luu2.Visible = false;
                btn_huy2.Visible = false;
            }
        }


        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("SP_TimKiemTienThuong", strConnect);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@timkiem", txt_timkiem.Text));
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grid_thuong.DataSource = dt;
                grv_thuong.Columns["mathuong"].Caption = "Mã thưởng";
                grv_thuong.Columns["mota"].Caption = "Mô tả";
                grv_thuong.Columns["giatri"].Caption = "Tiền thưởng";
            }
            catch
            {
                XtraMessageBox.Show("Rất tiếc, không tìm thấy thông tin cần tìm kiếm. Yêu cầu bạn nhập lại thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
