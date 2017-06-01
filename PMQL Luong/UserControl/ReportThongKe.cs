using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace PMQL_Luong.UserControl
{
    public partial class ReportThongKe : DevExpress.XtraReports.UI.XtraReport
    {
        
        public ReportThongKe()
        {
            InitializeComponent();
            
        }
        public void BindData()
        {
            xrTablema.DataBindings.Add("Text", DataSource, "manhanvien");
            xrTableTen.DataBindings.Add("Text", DataSource, "tennhanvien");
            xrTableNgay.DataBindings.Add("Text", DataSource, "ngayvaolam");
            xrTableSDT.DataBindings.Add("Text", DataSource, "SDT");
            xrTableCv.DataBindings.Add("Text", DataSource, "tenchucvu");
            xrTablePb.DataBindings.Add("Text", DataSource, "tenphongban");
            xrTableLuong.DataBindings.Add("Text", DataSource, "luong");
        }
    }
}
