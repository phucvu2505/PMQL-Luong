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
    public partial class UcTimkiem : DevExpress.XtraEditors.XtraUserControl
    {
        SqlConnection StrCnn;
        
        public UcTimkiem(SqlConnection Str)
        {
            InitializeComponent();
            StrCnn = Str;
            loadData();
            loadcbn_chucvu();
            loadcbn_phongban();
        }

        void loadData()
        {
            SqlCommand command = new SqlCommand(@"select nv.manhanvien,nv.tennhanvien,nv.ngayvaolam,
                                                   nv.SDT,pb.tenphongban,cv.tenchucvu,nv.luong 
                                                   from nhanvien nv join phongban pb on nv.maphongban = pb.maphongban 
                                                   join chucvu cv on cv.machucvu = nv.machucvu", StrCnn);
            SqlDataAdapter data = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            data.Fill(table);
            gC_danhsach.DataSource = table;
            gridView1.Columns["manhanvien"].Caption = "Mã nhân viên";
            gridView1.Columns["tennhanvien"].Caption = "Tên nhân viên";
            gridView1.Columns["ngayvaolam"].Caption="Ngày vào làm";
            gridView1.Columns["SDT"].Caption = "Số điện thoại";
            gridView1.Columns["tenchucvu"].Caption = "Chức vụ";
            gridView1.Columns["tenphongban"].Caption = "Phòng ban";
            gridView1.Columns["luong"].Caption = "Lương";
        }
        void loadDatatheoPhongban()
        {
            SqlCommand command = new SqlCommand("SP_timkiemnhanvien", StrCnn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@maphongban", cbnphongban.SelectedValue));
            SqlDataAdapter data = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            data.Fill(table);
            gC_danhsach.DataSource = table;
            gridView1.Columns["manhanvien"].Caption = "Mã nhân viên";
            gridView1.Columns["tennhanvien"].Caption = "Tên nhân viên";
            gridView1.Columns["ngayvaolam"].Caption = "Ngày vào làm";
            gridView1.Columns["SDT"].Caption = "Số điện thoại";
            gridView1.Columns["tenchucvu"].Caption = "Chức vụ";
            gridView1.Columns["tenphongban"].Caption = "Phòng ban";
            gridView1.Columns["luong"].Caption = "Lương";
        }
        void loadDatatheoChucvu()
        {
            SqlCommand command = new SqlCommand("SP_timkiemnhanvientheochucvu", StrCnn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@machucvu", cbnChucvu.SelectedValue));
            SqlDataAdapter data = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            data.Fill(table);
            gC_danhsach.DataSource = table;
            gridView1.Columns["manhanvien"].Caption = "Mã nhân viên";
            gridView1.Columns["tennhanvien"].Caption = "Tên nhân viên";
            gridView1.Columns["ngayvaolam"].Caption = "Ngày vào làm";
            gridView1.Columns["SDT"].Caption = "Số điện thoại";
            gridView1.Columns["tenchucvu"].Caption = "Chức vụ";
            gridView1.Columns["tenphongban"].Caption = "Phòng ban";
            gridView1.Columns["luong"].Caption = "Lương";
        }
        void loadDatatheotenNhanvien()
        {
            SqlCommand command = new SqlCommand("SP_timkiemnhanvientheotennhanvien", StrCnn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@tennhanvien", txtNhanvien.Text));
            SqlDataAdapter data = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            data.Fill(table);
            gC_danhsach.DataSource = table;
            gridView1.Columns["manhanvien"].Caption = "Mã nhân viên";
            gridView1.Columns["tennhanvien"].Caption = "Tên nhân viên";
            gridView1.Columns["ngayvaolam"].Caption = "Ngày vào làm";
            gridView1.Columns["SDT"].Caption = "Số điện thoại";
            gridView1.Columns["tenchucvu"].Caption = "Chức vụ";
            gridView1.Columns["tenphongban"].Caption = "Phòng ban";
            gridView1.Columns["luong"].Caption = "Lương";
        }
        void loadcbn_phongban()
        {
            SqlCommand com = new SqlCommand(@"select * from phongban", StrCnn);
            SqlDataAdapter dt = new SqlDataAdapter(com);
            DataTable tb = new DataTable();
            dt.Fill(tb);
            cbnphongban.DataSource = tb;
            cbnphongban.DisplayMember = "tenphongban";
            cbnphongban.ValueMember = "maphongban";
        }
        void loadcbn_chucvu()
        {
            SqlCommand com = new SqlCommand(@"select * from chucvu", StrCnn);
            SqlDataAdapter dt = new SqlDataAdapter(com);
            DataTable tb = new DataTable();
            dt.Fill(tb);
            cbnChucvu.DataSource = tb;
            cbnChucvu.DisplayMember = "tenchucvu";
            cbnChucvu.ValueMember = "machucvu";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            loadDatatheoChucvu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadDatatheoPhongban();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadDatatheotenNhanvien();
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
