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
    public partial class UcChucVu : DevExpress.XtraEditors.XtraUserControl
    {
        SqlConnection StrConn;
        User user;
        public UcChucVu(SqlConnection str, User use)
        {
            InitializeComponent();
            this.StrConn = str;
            this.user = use;
            if (!KiemTraQuyenTruyCap())
            {
                btn_Them.Enabled = false;
                btn_Xoa.Enabled = false;
                btn_Sua.Enabled = false;
                gcNhap.Enabled = false;
            }
            else
            {
                btn_Them.Enabled = true;
                btn_Xoa.Enabled = true;
                btn_Sua.Enabled = true;
                gcNhap.Enabled = true;
            }

            loadchucvu();
        }

        private List<string> Getdanhsachchucvu(string sql)
        {
            List<string> dsma = new List<string>();
            SqlDataAdapter da = new SqlDataAdapter(sql, StrConn);
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

        private string TaoMaChucvu()
        {
            List<string> dsma = Getdanhsachchucvu("select machucvu from chucvu order by machucvu");
            string ma = dsma[dsma.Count - 1];
            ma = ma.Substring(2);
            int so = int.Parse(ma);
            so = so + 1;
            ma = so.ToString();
            if (so < 10)
            {
                ma = "CV00" + ma;
            }
            else if (so >= 10 && so < 100)
            {
                ma = "CV0" + ma;
            }
            else ma = "CV" + ma;
            return ma;
        }

        private List<string> Getdanhsachnhanvien(string manhanvien)
        {
            List<string> ls = new List<string>();
            SqlDataAdapter da = new SqlDataAdapter(manhanvien, StrConn);
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

        void loadchucvu()
        {
            SqlCommand command = new SqlCommand(@"select * from chucvu", StrConn);
            SqlDataAdapter data = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            data.Fill(table);
            gridControl1.DataSource = table;
            gridView1.Columns["machucvu"].Caption = "Mã chức vụ";
            gridView1.Columns["tenchucvu"].Caption = "Tên chức vụ";
            gridView1.Columns["mota"].Caption = "Mô tả";

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            txtChucvu.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "machucvu").ToString();
            txtTenChucVu.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "tenchucvu").ToString();
            txtMota.Text = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "mota").ToString();

            txtChucvu.Enabled = false;
            txtTenChucVu.Enabled = false;

            if (!KiemTraQuyenTruyCap())
            {
                btn_Sua.Enabled = false;
                btn_Xoa.Enabled = false;
            }
            else
            {
                btn_Sua.Enabled = true;
                btn_Xoa.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTenChucVu.Text.Equals(""))
                XtraMessageBox.Show("Bạn chưa nhập tên chức vụ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
            {
                DialogResult dialog = XtraMessageBox.Show("Bạn có muốn thêm chức vụ mới không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        SqlCommand command = new SqlCommand("SP_ThemChucvu", StrConn);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@machucvu", txtChucvu.Text));
                        command.Parameters.Add(new SqlParameter("@tenchucvu", txtTenChucVu.Text));
                        command.Parameters.Add(new SqlParameter("@mota", txtMota.Text));

                        command.ExecuteNonQuery();
                        XtraMessageBox.Show("Thêm mới phòng ban thành công", "Thông báo", MessageBoxButtons.OK);
                        loadchucvu();
                    }
                    catch
                    {
                        XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            txtChucvu.Text = TaoMaChucvu();
            txtTenChucVu.Text = "";
            txtMota.Text = "";
            txtTenChucVu.Enabled = true;
            txtMota.Enabled = true;
            button1.Visible = true;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn thay đổi thông tin chức vụ không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    string ma = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "machucvu").ToString();
                    SqlCommand command = new SqlCommand("SP_Capnhatchucvu", StrConn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@machucvu", ma));
                    command.Parameters.Add(new SqlParameter("@tenchucvu", txtTenChucVu.Text));
                    command.Parameters.Add(new SqlParameter("@mota", txtMota.Text));

                    command.ExecuteNonQuery();
                    XtraMessageBox.Show("Sửa phòng ban thành công", "Thông báo", MessageBoxButtons.OK);
                    loadchucvu();
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn xóa chức vụ", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    string ma = gridView1.GetRowCellValue(gridView1.FocusedRowHandle, "machucvu").ToString();
                    SqlCommand command = new SqlCommand("SP_Xoachucvu", StrConn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@machucvu", ma));

                    command.ExecuteNonQuery();
                    XtraMessageBox.Show("Đã xóa phòng ban", "Thông báo", MessageBoxButtons.OK);
                    loadchucvu();
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            TaoSTT_GridView(gridView1, e);
        }
    }
}



