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
    public partial class UcUngtien : DevExpress.XtraEditors.XtraUserControl
    {
        SqlConnection StrCnn;
        User nd;
        string ma;
        string manhanvien;
        public UcUngtien(SqlConnection str, User ndg)
        {
            InitializeComponent();
            StrCnn = str;
            nd = ndg;
            if (!KiemTraQuyenTruyCap())
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                comboBox1.Enabled = false;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                textBox1.Enabled = false;
            }
            else
            {
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
            }
            textBox1.Enabled = false;
            loaddanhsach();
            loadcbnNhanvien();
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
        public float tienung(string manhanvien)
        {
            float giatri;
            SqlCommand command = new SqlCommand(@"select luong from nhanvien where manhanvien= @nhanvien", StrCnn);
            command.CommandType = CommandType.Text;
            command.Parameters.Add(new SqlParameter("@nhanvien", manhanvien));
            SqlDataAdapter dt = new SqlDataAdapter(command);
            DataTable tb = new DataTable();
            dt.Fill(tb);
            DataRow dr = tb.Rows[0];
            float tienluong = float.Parse(dr["luong"].ToString());
            giatri = tienluong / 2;
            return giatri;
        }
        void loadcbnNhanvien()
        {
            SqlCommand com = new SqlCommand(@"select * from nhanvien", StrCnn);
            SqlDataAdapter dt = new SqlDataAdapter(com);
            DataTable tb = new DataTable();
            dt.Fill(tb);
            comboBox1.DataSource = tb;
            comboBox1.DisplayMember = "tennhanvien";
            comboBox1.ValueMember = "manhanvien";
            comboBox1.SelectedIndex = -1;
        }
        void loaddanhsach()
        {
            SqlCommand com = new SqlCommand(@"select u.maungtien,u.manhanvien,nv.tennhanvien,u.ngayung,u.ngaynhantien,u.giatri 
                                              from ungtien u join nhanvien nv on nv.manhanvien=u.manhanvien", StrCnn);
            SqlDataAdapter dt = new SqlDataAdapter(com);
            DataTable tb = new DataTable();
            dt.Fill(tb);
            gridControl1.DataSource = tb;
            gridView1.Columns["maungtien"].Visible = false;
            gridView1.Columns["manhanvien"].Visible = false;
            gridView1.Columns["tennhanvien"].Caption = "Nhân viên";
            gridView1.Columns["ngayung"].Caption = "Ngày ứng";
            gridView1.Columns["ngaynhantien"].Caption = "Ngày nhận";
            gridView1.Columns["giatri"].Caption = "Giá trị";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            label4.Visible = false;
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            button4.Visible = false;
            ma = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "maungtien").ToString();
            manhanvien = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "manhanvien").ToString();
            textBox1.Enabled = false;
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn sửa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    SqlCommand com = new SqlCommand("SP_Suaungtien", StrCnn);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add(new SqlParameter("@ma", ma));
                    com.Parameters.Add(new SqlParameter("@nguoinhan", comboBox1.SelectedValue));
                    com.Parameters.Add(new SqlParameter("@ngayung", dateTimePicker1.Value));
                    com.Parameters.Add(new SqlParameter("@ngaynhan", dateTimePicker2.Value));
                    com.Parameters.Add(new SqlParameter("@giatri", tienung(manhanvien).ToString()));
                    com.ExecuteNonQuery();
                    XtraMessageBox.Show("Bạn sửa thành công!");
                    loaddanhsach();
                    button1.Enabled = true;
                    button2.Enabled = true;
                    button4.Visible = true;
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            button4.Visible = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            button4.Visible = false;
            button5.Visible = false;
            ma = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "maungtien").ToString();
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    SqlCommand com = new SqlCommand("SP_Xoaungtien", StrCnn);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add(new SqlParameter("@ma", ma));
                    com.ExecuteNonQuery();
                    XtraMessageBox.Show("Bạn xóa thành công!");
                    loaddanhsach();
                    button1.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Visible = true;
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            
            button4.Visible = true;
            button5.Visible = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ma = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "maungtien").ToString();
            manhanvien = comboBox1.SelectedValue.ToString();
            textBox1.Text = tienung(manhanvien).ToString();
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn thêm không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {

                    SqlCommand com = new SqlCommand("SP_Themungtien", StrCnn);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add(new SqlParameter("@nguoinhan", comboBox1.SelectedValue));
                    com.Parameters.Add(new SqlParameter("@ngayung", dateTimePicker1.Value));
                    com.Parameters.Add(new SqlParameter("@ngaynhan", dateTimePicker2.Value));
                    com.Parameters.Add(new SqlParameter("@giatri", textBox1.Text));
                    com.ExecuteNonQuery();
                    XtraMessageBox.Show("Bạn thêm thành công!");
                    loaddanhsach();
                    button2.Enabled = true;
                    button3.Enabled = true;
                    textBox1.Visible = true;
                    label4.Visible = true;
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            textBox1.Visible = true;
            label4.Visible = true;

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ngayung").ToString();
            dateTimePicker2.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "ngaynhantien").ToString();
            comboBox1.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "tennhanvien").ToString();
            textBox1.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "giatri").ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            ma = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "maungtien").ToString();
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn in không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                XtrareportUngtien report = new XtrareportUngtien(StrCnn, ma);
                report.ShowDialog();
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
    }
}
