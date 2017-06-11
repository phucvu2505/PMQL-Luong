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

namespace PMQL_Luong.UserControl
{
    public partial class UcHuongDan : DevExpress.XtraEditors.XtraUserControl
    {
        public UcHuongDan()
        {
            InitializeComponent();
        }

        private void UcHuongDan_Load(object sender, EventArgs e)
        {
            pdfViewer1.LoadDocument("huongdan.pdf");
        }
    }
}
