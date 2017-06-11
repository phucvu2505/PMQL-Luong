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
using System.Data.SqlClient;
using PMQL_Luong.Entities;
using DevExpress.XtraGrid.Views.Grid;

namespace PMQL_Luong.UserControl
{
    public partial class UcTienphat : DevExpress.XtraEditors.XtraUserControl
    {
        SqlConnection StrCnn;
        User nd;
        public UcTienphat(SqlConnection str, User ndg)
        {
            InitializeComponent();
            StrCnn = str;
            nd = ndg;
            if (!KiemTraQuyenTruyCap())
            {
                gBmucphat.Visible = false;
                gbNguoiphat.Visible = false;
            }
            else
            {
                gBmucphat.Visible = true;
                gbNguoiphat.Visible = true;
                txtma.Enabled = false;
                txtnguoighi.Enabled=false;
            }
            loadmucphat();
            loadtienphat();
            loadcbnNhanvien2();
            loadcbntienphat();
        }

        void loadmucphat()
        {
            SqlCommand com = new SqlCommand(@"select* from tienphat", StrCnn);
            SqlDataAdapter dt = new SqlDataAdapter(com);
            DataTable tb = new DataTable();
            dt.Fill(tb);
            gcmucphat.DataSource = tb;
            gridView1.Columns["maphat"].Caption = "Mã mức phạt";
            gridView1.Columns["tenmucphat"].Caption = "Tên mức phạt";
            gridView1.Columns["giatri"].Caption = "Giá trị";

        }
        void loadtienphat()
        {
            SqlCommand com = new SqlCommand(@"select ct.machitiet,nv.tennhanvien,tp.tenmucphat,tp.giatri,ct.ngay,b.tennhanvien as nvghi
                                              from chitiettienphat ct join nhanvien nv on nv.manhanvien=ct.manv 
                                              join tienphat tp on tp.maphat=ct.matienphat 
                                              join (select ct.machitiet,nv.tennhanvien from chitiettienphat ct 
                                                    join nhanvien nv on ct.manvghi=nv.manhanvien) b on ct.machitiet=b.machitiet", StrCnn);
            SqlDataAdapter dt = new SqlDataAdapter(com);
            DataTable tb = new DataTable();
            dt.Fill(tb);
            gctienphat.DataSource = tb;
            gridView2.Columns["machitiet"].Visible = false;
            gridView2.Columns["tennhanvien"].Caption = "Người bị phạt";
            gridView2.Columns["tenmucphat"].Caption = "Tên mức phạt";
            gridView2.Columns["giatri"].Caption = "Giá trị";
            gridView2.Columns["ngay"].Caption = "Ngày";
            gridView2.Columns["nvghi"].Caption = "Người ghi";

        }

        void loadcbntienphat()
        {
            SqlCommand com = new SqlCommand(@"select* from tienphat", StrCnn);
            SqlDataAdapter dt = new SqlDataAdapter(com);
            DataTable tb = new DataTable();
            dt.Fill(tb);
            cbntenmuc.DataSource = tb;
            cbntenmuc.DisplayMember = "tenmucphat";
            cbntenmuc.ValueMember = "maphat";
            cbntenmuc.SelectedIndex = -1;
        }
        
        void loadcbnNhanvien2()
        {
            SqlCommand com = new SqlCommand(@"select * from nhanvien", StrCnn);
            SqlDataAdapter dt = new SqlDataAdapter(com);
            DataTable tb = new DataTable();
            dt.Fill(tb);
            cbntenngbiphat.DataSource = tb;
            cbntenngbiphat.DisplayMember = "tennhanvien";
            cbntenngbiphat.ValueMember = "manhanvien";
            cbntenngbiphat.SelectedIndex = -1;
        }

        private bool KiemTraQuyenTruyCap()
        {
            bool check = false;
            List<string> ls = Getdanhsachnhanvien("select mataikhoan from taikhoan where quyentruycap = 'admin' or quyentruycap = 'superadmin' ");
            {
                for (int i = 0; i < ls.Count; i++)
                {
                    if (ls[i].Equals(nd.Id))
                    {
                        check = true;
                        break;
                    }
                }
            }
            return check;
        }

        public string tentaikhoan()
        {
            SqlCommand com = new SqlCommand(@"select tennhanvien from nhanvien where manhanvien=@ma", StrCnn);
            com.CommandType = CommandType.Text;
            com.Parameters.Add(new SqlParameter("@ma", nd.Id));
            SqlDataAdapter dt = new SqlDataAdapter(com);
            DataTable tb = new DataTable();
            dt.Fill(tb);
            DataRow dr = tb.Rows[0];
            string ten = dr["tennhanvien"].ToString();
            return ten;
        }

        private List<string> Getdanhsachnhanvien(string manhanvien)
        {
            List<string> ls = new List<string>();
            SqlDataAdapter da = new SqlDataAdapter(manhanvien, StrCnn);
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

        private string TaoMaphat()
        {
            List<string> dsma = Getdanhsachphat("select maphat from tienphat order by maphat");
            string ma = dsma[dsma.Count - 1];
            ma = ma.Substring(2);
            int so = int.Parse(ma);
            so = so + 1;
            ma = so.ToString();
            if (so < 10)
            {
                ma = "MP00" + ma;
            }
            else if (so >= 10 && so < 100)
            {
                ma = "MP0" + ma;
            }
            else ma = "MP" + ma;
            return ma;
        }

        private List<string> Getdanhsachphat(string sql)
        {
            List<string> dsma = new List<string>();
            SqlDataAdapter da = new SqlDataAdapter(sql, StrCnn);
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

        private void button1_Click(object sender, EventArgs e)
        {
            btn_suangphat.Enabled = false;
            btn_xoangphat.Enabled = false;
            txtnguoighi.Text = tentaikhoan();
            txtnguoighi.Enabled = false;
            cbntenmuc.SelectedIndex = -1;
            cbntenngbiphat.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //btn_themngphat.Enabled = false;
            //btn_XoaPhat.Enabled = false;
            txtnguoighi.Text = tentaikhoan();
            txtnguoighi.Enabled = false;
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn thay đổi không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    string ma = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "machitiet").ToString();
                    SqlCommand com = new SqlCommand("SP_SuaChitietphat", StrCnn);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add(new SqlParameter("@machitiet", ma));
                    com.Parameters.Add(new SqlParameter("@nguoibiphat", cbntenngbiphat.SelectedValue));
                    com.Parameters.Add(new SqlParameter("@maphat", cbntenmuc.SelectedValue));
                    com.Parameters.Add(new SqlParameter("@ngay", dateTimePicker1.Value));
                    com.ExecuteNonQuery();
                    XtraMessageBox.Show("Bạn sửa thành công!");
                    loadtienphat();
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            btn_themngphat.Enabled = true;
            btn_XoaPhat.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //btn_themngphat.Enabled = false;
            //btn_suangphat.Enabled = false;
            string ma = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "machitiet").ToString();
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    SqlCommand com = new SqlCommand("SP_XoaChitietphat", StrCnn);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add(new SqlParameter("@machitiet", ma));
                    com.ExecuteNonQuery();
                    XtraMessageBox.Show("Bạn xóa thành công!");
                    loadtienphat();
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            btn_themngphat.Enabled = true;
            btn_suangphat.Enabled = true;
        }

        private void gcmucphat_Click(object sender, EventArgs e)
        {
            txtma.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "maphat").ToString();
            txtten.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "tenmucphat").ToString();
            txtgiatri.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "giatri").ToString();
            txtma.Enabled = false;

        }

        private void gctienphat_Click(object sender, EventArgs e)
        {

            dateTimePicker1.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "ngay").ToString();
            cbntenngbiphat.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "tennhanvien").ToString();
            cbntenmuc.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "tenmucphat").ToString();
            txtnguoighi.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "nvghi").ToString();
        }

        private void btn_luuphat_Click(object sender, EventArgs e)
        {
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn thêm không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    SqlCommand com = new SqlCommand("SP_Themmucphat", StrCnn);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add(new SqlParameter("@mamucphat", TaoMaphat()));
                    com.Parameters.Add(new SqlParameter("@tenmucphat", txtten.Text));
                    com.Parameters.Add(new SqlParameter("@giatri", txtgiatri.Text));
                    com.ExecuteNonQuery();
                    XtraMessageBox.Show("Bạn thêm thành công!");
                    loadmucphat();
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            txtten.Text = "";
            txtgiatri.Text = "";
            txtma.Refresh();
            txtten.Refresh();
            txtgiatri.Refresh();

        }

        private void btn_luungphat_Click(object sender, EventArgs e)
        {
            
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn thêm không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    SqlCommand com = new SqlCommand("SP_ThemChitietphat", StrCnn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter("@nguoibiphat", cbntenngbiphat.SelectedValue));
                com.Parameters.Add(new SqlParameter("@maphat", cbntenmuc.SelectedValue));
                com.Parameters.Add(new SqlParameter("@ngay", dateTimePicker1.Value));
                com.Parameters.Add(new SqlParameter("@nguoighi", nd.Id));
                com.ExecuteNonQuery();
                XtraMessageBox.Show("Bạn thêm thành công!");
                loadtienphat();
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            btn_suangphat.Enabled = true;
            btn_xoangphat.Enabled = true;
            cbntenmuc.SelectedIndex = -1;
            cbntenngbiphat.SelectedIndex = -1;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            
            string ma = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "maphat").ToString();

            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn thay đổi không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    SqlCommand com = new SqlCommand("SP_Suamucphat", StrCnn);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add(new SqlParameter("@mamucphat", ma));
                    com.Parameters.Add(new SqlParameter("@tenmucphat", txtten.Text));
                    com.Parameters.Add(new SqlParameter("@giatri", txtgiatri.Text));
                    com.ExecuteNonQuery();
                    XtraMessageBox.Show("Bạn sửa thành công!");
                    loadmucphat();
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            txtma.Refresh();
            txtten.Refresh();
            txtgiatri.Refresh();
        }

        private void btn__Click(object sender, EventArgs e)
        {
            txtma.Text = TaoMaphat();
            txtma.Enabled = false;
            txtten.Text = "";
            txtgiatri.Text = "";
            
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            
            string ma = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "maphat").ToString();

            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    SqlCommand com = new SqlCommand("SP_Xoamucphat", StrCnn);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add(new SqlParameter("@mamucphat", ma));
                    com.ExecuteNonQuery();
                    XtraMessageBox.Show("Bạn xóa thành công!");
                    loadmucphat();
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtgiatri_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                errorProvider1.Icon = Properties.Resources.ic_nook;
                errorProvider1.SetError(txtgiatri, "Không được nhập chữ");
                e.Handled = true;
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

        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            TaoSTT_GridView(gridView1, e);
        }

        private void gridView2_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            TaoSTT_GridView(gridView2, e);
        }

        private void txt_timkiem_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                SqlCommand com = new SqlCommand("SP_TimKiemTienPhat", StrCnn);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter("@timkiem", txt_timkiem.Text));
                SqlDataAdapter dt = new SqlDataAdapter(com);
                DataTable tb = new DataTable();
                dt.Fill(tb);
                gcmucphat.DataSource = tb;
                gridView1.Columns["maphat"].Caption = "Mã mức phạt";
                gridView1.Columns["tenmucphat"].Caption = "Tên mức phạt";
                gridView1.Columns["giatri"].Caption = "Giá trị";
            }
            catch
            {
                XtraMessageBox.Show("Rất tiếc, không tìm thấy thông tin cần tìm kiếm. Yêu cầu bạn nhập lại thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
