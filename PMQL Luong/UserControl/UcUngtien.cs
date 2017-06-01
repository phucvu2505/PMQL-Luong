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

namespace PMQL_Luong.UserControl
{
    public partial class UcUngtien : DevExpress.XtraEditors.XtraUserControl
    {
        SqlConnection StrCnn;
        User nd;
        string ma;
        public UcUngtien(SqlConnection str, User ndg)
        {
            InitializeComponent();
            StrCnn = str;
            nd = ndg;
            if (!KiemTraQuyenTruyCap())
            {
                groupBox1.Visible = false;
            }
            else
            {
                groupBox1.Visible = true;
            }
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
            SqlCommand com = new SqlCommand(@"select u.maungtien,nv.tennhanvien,u.ngayung,u.ngaynhantien,u.giatri 
                                              from ungtien u join nhanvien nv on nv.manhanvien=u.manhanvien", StrCnn);
            SqlDataAdapter dt = new SqlDataAdapter(com);
            DataTable tb = new DataTable();
            dt.Fill(tb);
            gridControl1.DataSource = tb;
            gridView1.Columns["maungtien"].Visible=false;
            gridView1.Columns["tennhanvien"].Caption = "Nhân viên";
            gridView1.Columns["ngayung"].Caption = "Ngày ứng";
            gridView1.Columns["ngaynhantien"].Caption = "Ngày nhận";
            gridView1.Columns["giatri"].Caption = "Giá trị";
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ma= gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "maungtien").ToString(); 
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn sửa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    SqlCommand com = new SqlCommand("SP_Suaungtien", StrCnn);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add(new SqlParameter("@ma",ma));
                    com.Parameters.Add(new SqlParameter("@nguoinhan", comboBox1.SelectedValue));
                    com.Parameters.Add(new SqlParameter("@ngayung", dateTimePicker1.Value));
                    com.Parameters.Add(new SqlParameter("@ngaynhan", dateTimePicker2.Value));
                    com.Parameters.Add(new SqlParameter("@giatri", textBox1.Text));
                    com.ExecuteNonQuery();
                    MessageBox.Show("Bạn sửa thành công!");
                    loaddanhsach();
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ma = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "maungtien").ToString();
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn sửa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    SqlCommand com = new SqlCommand("SP_Xoaungtien", StrCnn);
                    com.CommandType = CommandType.StoredProcedure;
                    com.Parameters.Add(new SqlParameter("@ma", ma));
                    com.ExecuteNonQuery();
                    MessageBox.Show("Bạn xóa thành công!");
                    loaddanhsach();
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ma = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "maungtien").ToString();
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
                    MessageBox.Show("Bạn thêm thành công!");
                    loaddanhsach();
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn thêm không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                XtrareportUngtien report = new XtrareportUngtien(StrCnn, ma);
                report.ShowDialog();
            }
        }
    }
}
