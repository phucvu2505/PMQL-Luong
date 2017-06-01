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
    }
}
