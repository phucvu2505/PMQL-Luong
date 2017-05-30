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
using PMQL_Luong.Entities;
using System.Data.SqlClient;
using DevExpress.XtraGrid.Views.Grid;

namespace PMQL_Luong.UserControl
{
    public partial class UcNhanVien : DevExpress.XtraEditors.XtraUserControl
    {
        private User user;
        private SqlConnection strConnect;

        public UcNhanVien(SqlConnection strConnect,User user)
        {
            InitializeComponent();
            this.strConnect = strConnect;
            this.user = user;
        }

        private void UcNhanVien_Load(object sender, EventArgs e)
        {

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

        private void grv_DSnhanvien_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            TaoSTT_GridView(grv_DSnhanvien, e);
        }

        private List<string> List_MaNhanVien()
        {
            List<string> list = new List<string>();
            SqlCommand command = new SqlCommand("select manhanvien from nhanvien", strConnect);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();

            string mahoadon;
            da.Fill(dt);
            Object[] obj;
            DataRowCollection rowList = dt.Rows;
            for (int i = 0; i < rowList.Count; i++)
            {
                obj = rowList[i].ItemArray;
                mahoadon = obj[0].ToString();
                list.Add(mahoadon);
            }
            return list;
        }

        private string TaoMaNhanVien()
        {
            string ketqua = "";
            List<string> listHD = List_MaNhanVien();
            List<int> listSo = new List<int>();
            listSo.Add(0);
            for (int i = 0; i < listHD.Count; i++)
            {
                string temp = listHD[i].Remove(0, 2);
                int a = int.Parse(temp);
                listSo.Add(a);
            }

            if (listSo.Count == 1)
            {
                ketqua = "NV0001";
            }
            else
            {
                bool trangthai = true;
                for (int i = 0; i < listSo.Count - 1; i++)
                {
                    if ((listSo[i + 1] - listSo[i]) > 1) trangthai = false;

                }
                int x;
                if (trangthai)
                {
                    x = listSo[listSo.Count - 1] + 1;
                    if (x < 10)
                        ketqua = "NV000" + x;
                    else if (x >= 10 && x < 100)
                        ketqua = "NV00" + x;
                    else if (x >= 100 && x < 1000)
                        ketqua = "NV0" + x;
                    else
                        ketqua = "NV" + x;
                }
                else
                {
                    for (int i = 0; i < listSo.Count; i++)
                    {
                        if ((listSo[i + 1] - listSo[i]) > 1)
                        {
                            x = listSo[i] + 1;
                            if (x < 10)
                                ketqua = "NV000" + x;
                            else if (x >= 10 && x < 100)
                                ketqua = "NV00" + x;
                            else if (x >= 100 && x < 1000)
                                ketqua = "NV0" + x;
                            else
                                ketqua = "NV" + x;
                        }

                    }
                }

            }

            return ketqua;
        }
    }
}
