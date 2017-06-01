﻿using System;
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
            }
            loadmucphat();
            loadtienphat();
            loadcbnNhanvien1();
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
            SqlCommand com = new SqlCommand(@"select ct.machitiet,nv.tennhanvien,tp.tenmucphat,tp.giatri,ct.ngay,nv.tennhanvien 
                                              from chitiettienphat ct join nhanvien nv on nv.manhanvien=ct.manv 
                                              join tienphat tp on tp.maphat=ct.matienphat", StrCnn);
            SqlDataAdapter dt = new SqlDataAdapter(com);
            DataTable tb = new DataTable();
            dt.Fill(tb);
            gctienphat.DataSource = tb;
            gridView2.Columns["machitiet"].Visible = false;
            gridView2.Columns["tennhanvien"].Caption = "Người bị phạt";
            gridView2.Columns["tenmucphat"].Caption = "Tên mức phạt";
            gridView2.Columns["giatri"].Caption = "Giá trị";
            gridView2.Columns["ngay"].Caption = "Ngày";
            gridView2.Columns["tennhanvien"].Caption = "Người ghi";

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
        void loadcbnNhanvien1()
        {
            SqlCommand com = new SqlCommand(@"select * from nhanvien", StrCnn);
            SqlDataAdapter dt = new SqlDataAdapter(com);
            DataTable tb = new DataTable();
            dt.Fill(tb);
            cbnnguoighi.DataSource = tb;
            cbnnguoighi.DisplayMember = "tennhanvien";
            cbnnguoighi.ValueMember = "manhanvien";
            cbnnguoighi.SelectedIndex = -1;
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

        private void button4_Click(object sender, EventArgs e)
        {
            txtma.Text = TaoMaphat();
            txtma.Enabled = false;
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
                    MessageBox.Show("Bạn thêm thành công!");
                    loadmucphat();
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            txtma.Clear();
            txtten.Clear();
            txtgiatri.Clear();

        }

        private void button5_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Bạn sửa thành công!");
                    loadmucphat();
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            txtma.Clear();
            txtten.Clear();
            txtgiatri.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Bạn xóa thành công!");
                    loadmucphat();
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
                    com.Parameters.Add(new SqlParameter("@nguoighi", cbnnguoighi.SelectedValue));
                    com.ExecuteNonQuery();
                    MessageBox.Show("Bạn thêm thành công!");
                    loadtienphat();
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            cbnnguoighi.SelectedIndex = -1;
            cbntenmuc.SelectedIndex = -1;
            cbntenngbiphat.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
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
                    com.Parameters.Add(new SqlParameter("@nguoighi", cbnnguoighi.SelectedValue));
                    com.ExecuteNonQuery();
                    MessageBox.Show("Bạn sửa thành công!");
                    loadtienphat();
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
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
                    MessageBox.Show("Bạn xóa thành công!");
                    loadtienphat();
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
            cbnnguoighi.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "tennhanvien").ToString();
        }

    }
}