using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace PMQL_Luong.UserControl
{
    public partial class XtrareprtThongke : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection strCnn;
        public XtrareprtThongke(SqlConnection str)
        {
            InitializeComponent();
            strCnn = str;
        }
        private void documentViewer1_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(@"select nv.manhanvien,nv.tennhanvien,nv.ngayvaolam,
                                                   nv.SDT,pb.tenphongban,cv.tenchucvu,nv.luong 
                                                   from nhanvien nv join phongban pb on nv.maphongban = pb.maphongban 
                                                   join chucvu cv on cv.machucvu = nv.machucvu", strCnn);
            SqlDataAdapter data = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            data.Fill(table);
            ReportThongKe report = new ReportThongKe();
            report.DataSource = table;
            report.BindData();
            documentViewer1.PrintingSystem = report.PrintingSystem;
            report.CreateDocument();
        }

        private void printPreviewBarItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
    }
}