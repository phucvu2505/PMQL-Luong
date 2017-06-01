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
    public partial class XtrareportUngtien : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection strCnn;
        string maHD;
        public XtrareportUngtien(SqlConnection str, string ma)
        {
            InitializeComponent();
            strCnn = str;
            maHD = ma;
        }

        private void documentViewer1_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SP_Hienthiungtien", strCnn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@ma", maHD));
            SqlDataAdapter data = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            data.Fill(table);
            command.ExecuteNonQuery();
            ReportUngtien report = new ReportUngtien();
            report.DataSource = table;
            report.BindData();
            documentViewer1.PrintingSystem = report.PrintingSystem;
            report.CreateDocument();
        }

        private void printPreviewBarItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("in hóa đơn thành công!");
            this.Close();
        }
    }
}