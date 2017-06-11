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
    public partial class UcPhongBan : DevExpress.XtraEditors.XtraUserControl
    {
        private SqlConnection strConnect;
        private User user;

        public UcPhongBan(SqlConnection strConnect, User user)
        {
            InitializeComponent();
            this.strConnect = strConnect;
            this.user = user;
            if (!KiemTraQuyenTruyCap())
                btn_them.Enabled = false;
            else
                btn_them.Enabled = true;
            btn_xoa.Enabled = false;
            btn_sua.Enabled = false;
            btn_luu.Visible = false;
            btn_huy.Visible = false;
        }

        private void UcPhongBan_Load(object sender, EventArgs e)
        {
            loadDataPhongban();
            loadDiadiem();
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

        private void loadDataPhongban()
        {
            SqlCommand command = new SqlCommand("SP_HienthiPhongban", strConnect);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da_phongban = new SqlDataAdapter(command);
            DataTable dt_phongban = new DataTable();
            da_phongban.Fill(dt_phongban);
            grid_phongban.DataSource = dt_phongban;
            grv_phongban.Columns["maphongban"].Caption = "Mã phòng ban";
            grv_phongban.Columns["tenphongban"].Caption = "Tên phòng ban";
            grv_phongban.Columns["diadiem"].Caption = "Địa điểm";
            grv_phongban.BestFitColumns();
        }

        private void loadDiadiem()
        {
            SqlCommand command = new SqlCommand("select * from phongban", strConnect);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmp_diadiem.DataSource = dt;
            cmp_diadiem.DisplayMember = "diadiem";
            cmp_diadiem.ValueMember = "diadiem";
            cmp_diadiem.SelectedIndex = -1;
        }

        private void grv_phongban_Click(object sender, EventArgs e)
        {
            try
            {
                txt_mapb.Text = grv_phongban.GetRowCellValue(grv_phongban.FocusedRowHandle, "maphongban").ToString();
                txt_tenpb.Text = grv_phongban.GetRowCellValue(grv_phongban.FocusedRowHandle, "tenphongban").ToString();
                cmp_diadiem.Text = grv_phongban.GetRowCellValue(grv_phongban.FocusedRowHandle, "diadiem").ToString();

                txt_mapb.Enabled = false;

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
            catch { }
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

        private void grv_phongban_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            TaoSTT_GridView(grv_phongban, e);
        }

        private List<string> Getdanhsachphongban(string sql)
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

        private string TaoMaPhongBan()
        {
            List<string> dsma = Getdanhsachphongban("select pb.maphongban from phongban pb order by pb.maphongban");
            string ma = dsma[dsma.Count - 1];
            ma = ma.Substring(2);
            int so = int.Parse(ma);
            so = so + 1;
            ma = so.ToString();
            if (so < 10)
            {
                ma = "PB00" + ma;
            }
            else if (so >= 10 && so < 100)
            {
                ma = "PB0" + ma;
            }
            else ma = "PB" + ma;
            return ma;
        }

        private void btn_them_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txt_mapb.Text = TaoMaPhongBan();
            txt_tenpb.Text = "";
            cmp_diadiem.Text = "";

            btn_luu.Visible = true;
            btn_huy.Visible = true;
            btn_sua.Enabled = false;
            btn_xoa.Enabled = false;
        }

        private void btn_sua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn thay đổi thông tin phòng ban không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    SqlCommand command = new SqlCommand("SP_CapnhatPhongban", strConnect);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@maphongban", txt_mapb.Text));
                    command.Parameters.Add(new SqlParameter("@tenphongban", txt_tenpb.Text));
                    command.Parameters.Add(new SqlParameter("@diadiem", cmp_diadiem.SelectedValue));

                    command.ExecuteNonQuery();
                    XtraMessageBox.Show("Thay đổi thông tin phòng ban thành công", "Thông báo", MessageBoxButtons.OK);
                    loadDataPhongban();
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_xoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn xóa phòng ban", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    SqlCommand command = new SqlCommand("SP_XoaPhongban", strConnect);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@maphongban", txt_mapb.Text));

                    command.ExecuteNonQuery();
                    XtraMessageBox.Show("Đã xóa phòng ban", "Thông báo", MessageBoxButtons.OK);
                    loadDataPhongban();
                }
                catch
                {
                    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_luu_Click(object sender, EventArgs e)
        {
            if (txt_tenpb.Text.Equals(""))
                XtraMessageBox.Show("Bạn chưa nhập tên phòng ban", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else if (cmp_diadiem.Text.Equals(""))
                XtraMessageBox.Show("Bạn chưa chọn địa điểm của phòng ban", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            else
            {
                DialogResult dialog = XtraMessageBox.Show("Bạn có muốn thêm phòng ban mới không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        SqlCommand command = new SqlCommand("SP_ThemPhongban", strConnect);
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add(new SqlParameter("@maphongban", txt_mapb.Text));
                        command.Parameters.Add(new SqlParameter("@tenphongban", txt_tenpb.Text));
                        command.Parameters.Add(new SqlParameter("@diadiem", cmp_diadiem.SelectedValue));

                        command.ExecuteNonQuery();
                        XtraMessageBox.Show("Thêm mới phòng ban thành công", "Thông báo", MessageBoxButtons.OK);
                        loadDataPhongban();
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
            DialogResult dialog = XtraMessageBox.Show("Bạn có muốn hủy thao tác này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                txt_mapb.Text = "";
                cmp_diadiem.Text = "";
                txt_tenpb.Text = "";
                btn_luu.Visible = false;
                btn_huy.Visible = false;
            }
        }
    }
}
