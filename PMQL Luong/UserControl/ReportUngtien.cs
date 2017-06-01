using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace PMQL_Luong.UserControl
{
    public partial class ReportUngtien : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportUngtien()
        {
            InitializeComponent();
        }

        public void BindData()
        {
            lbnhanvien.DataBindings.Add("Text", DataSource, "tennhanvien");
            lbngayung.DataBindings.Add("Text", DataSource, "ngayung");
            lbngaynhan.DataBindings.Add("Text", DataSource, "ngaynhantien");
            lbGiatri.DataBindings.Add("Text", DataSource, "giatri");
        }
    }
}
