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
    public partial class UcThongkeNhanvien : DevExpress.XtraEditors.XtraUserControl
    {
        SqlConnection StrCnn;
        public UcThongkeNhanvien(SqlConnection str)
        {
            InitializeComponent();
            StrCnn = str;
            loadData();
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
            gridControl1.DataSource = table;
            gridView1.Columns["manhanvien"].Caption = "Mã nhân viên";
            gridView1.Columns["tennhanvien"].Caption = "Tên nhân viên";
            gridView1.Columns["ngayvaolam"].Caption = "Ngày vào làm";
            gridView1.Columns["SDT"].Caption = "Số điện thoại";
            gridView1.Columns["tenchucvu"].Caption = "Chức vụ";
            gridView1.Columns["tenphongban"].Caption = "Phòng ban";
            gridView1.Columns["luong"].Caption = "Lương";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XtrareprtThongke report = new XtrareprtThongke(StrCnn);
            report.ShowDialog();
        }
    }
}
