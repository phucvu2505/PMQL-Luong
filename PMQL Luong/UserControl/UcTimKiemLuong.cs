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
using DevExpress.XtraGrid.Views.Grid;

namespace PMQL_Luong.UserControl
{
    public partial class UcTimKiemLuong : DevExpress.XtraEditors.XtraUserControl
    {
        private SqlConnection strConnect;
        public UcTimKiemLuong(SqlConnection strConnect)
        {
            InitializeComponent();
            this.strConnect = strConnect;
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

        private void grv_timkiem_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            TaoSTT_GridView(grv_timkiem, e);
        }

        private void loadDataHesoluong()
        {
            grv_timkiem.Columns["tennhanvien"].Caption = "Tên nhân viên";
            grv_timkiem.Columns["maheso"].Caption = "Mã hệ số";
            grv_timkiem.Columns["maheso"].BestFit();
            grv_timkiem.Columns["mota"].Caption = "Mô tả";
            grv_timkiem.Columns["giatri"].Caption = "Hệ số";
            grv_timkiem.Columns["giatri"].Width = 100;
        }

        private void loadDataTienthuong()
        {

            grv_timkiem.Columns["tennhanvien"].Caption = "Tên nhân viên";
            grv_timkiem.Columns["mathuong"].Caption = "Mã thưởng";
            grv_timkiem.Columns["mathuong"].BestFit();
            grv_timkiem.Columns["mota"].Caption = "Mô tả";
            grv_timkiem.Columns["giatri"].Caption = "Tiền thưởng";
            grv_timkiem.Columns["giatri"].Width = 100;
        }

        private void loadDataTienphat()
        {
            grv_timkiem.Columns["tennhanvien"].Caption = "Tên nhân viên";
            grv_timkiem.Columns["maphat"].Caption = "Mã phạt";
            grv_timkiem.Columns["maphat"].BestFit();
            grv_timkiem.Columns["tenmucphat"].Caption = "Mô tả";
            grv_timkiem.Columns["giatri"].Caption = "Tiền phạt";
            grv_timkiem.Columns["giatri"].Width = 100;
        }

        private void cmp_danhmuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmp_danhmuc.Text == "Hệ số lương")
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from hesoluong", strConnect);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmp_timkiem.DataSource = dt;
                cmp_timkiem.DisplayMember = "maheso";
                cmp_timkiem.ValueMember = "maheso";
                cmp_timkiem.SelectedIndex = -1;
            }else if(cmp_danhmuc.Text == "Tiền thưởng")
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from tienthuong", strConnect);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmp_timkiem.DataSource = dt;
                cmp_timkiem.DisplayMember = "mota";
                cmp_timkiem.ValueMember = "mathuong";
                cmp_timkiem.SelectedIndex = -1;
            }else if(cmp_danhmuc.Text == "Tiền phạt")
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from tienphat", strConnect);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmp_timkiem.DataSource = dt;
                cmp_timkiem.ValueMember = "maphat";
                cmp_timkiem.DisplayMember = "tenmucphat";
                cmp_timkiem.SelectedIndex = -1;
            }
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (cmp_danhmuc.Text == "Hệ số lương")
                {
                    string str = @"[SP_TimkiemHesoluong] N'%" + cmp_timkiem.SelectedValue + "%'";
                    SqlDataAdapter da = new SqlDataAdapter(str, strConnect);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    grid_timkiem.DataSource = dt;
                    loadDataHesoluong();
                }
                else if (cmp_danhmuc.Text == "Tiền thưởng")
                {
                    string str = @"[SP_TimkiemTienthuong] N'%" + cmp_timkiem.SelectedValue + "%'";
                    SqlDataAdapter da = new SqlDataAdapter(str, strConnect);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    grid_timkiem.DataSource = dt;
                    loadDataTienthuong();
                }
                else if (cmp_danhmuc.Text == "Tiền phạt")
                {
                    string str = @"[SP_TimkiemTienphat]N'%" + cmp_timkiem.SelectedValue + "%'";
                    SqlDataAdapter da = new SqlDataAdapter(str, strConnect);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    grid_timkiem.DataSource = dt;
                    loadDataTienphat();
                }
            //}
            //catch
            //{
            //    XtraMessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }
    }
}
