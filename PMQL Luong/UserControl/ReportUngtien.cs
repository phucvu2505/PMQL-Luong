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
            xrlbnhanvien.DataBindings.Add("Text", DataSource, "tennhanvien");
            xrlbBophan.DataBindings.Add("Text", DataSource, "tenphongban");
            xrlbNgayung.DataBindings.Add("Text", DataSource, "ngayung");
            xrlbNgaynhan.DataBindings.Add("Text", DataSource, "ngaynhantien");
            xrlbgiatri.DataBindings.Add("Text", DataSource, "giatri");
        }
    }
}
