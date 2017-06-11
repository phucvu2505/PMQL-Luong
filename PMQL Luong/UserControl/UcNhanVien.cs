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
using Microsoft.VisualBasic;
using System.Text.RegularExpressions;

namespace PMQL_Luong.UserControl
{
    public partial class UcNhanVien : DevExpress.XtraEditors.XtraUserControl
    {
        private User user;
        private SqlConnection strConnect;
        private float x = 0;
        private float ngaylamviec = 0;
        private string chuoi = "";
        private string maheso = "";
        private float luongcoban = 0;

        public UcNhanVien(SqlConnection strConnect, User user)
        {
            InitializeComponent();
            this.strConnect = strConnect;
            this.user = user;
        }

        private void UcNhanVien_Load(object sender, EventArgs e)
        {
            Load_DanhSachNhanVien();
            Load_ChucVu_cmb();
            Load_PhongBan_cmb();
            if ("user".Equals(user.Permission))
            {
                btn_Them.Visible = false;
                btn_Xoa.Visible = false;
                txt_TimKiem.Text = user.Id;
                txt_TimKiem.Enabled = false;
                cmb_PhongBan.Enabled = false;
                cmb_HocVan.Enabled = false;
                cmb_ChucVu.Enabled = false;
                dtp_Ngay.Enabled = false;
                Load_DanhSachNhanVien();
                dtp_Ngay.Text = grv_DSnhanvien.GetRowCellValue(grv_DSnhanvien.FocusedRowHandle, "ngayvaolam").ToString();
                txt_MaNV.Text = grv_DSnhanvien.GetRowCellValue(grv_DSnhanvien.FocusedRowHandle, "manhanvien").ToString();
                txt_TenNV.Text = grv_DSnhanvien.GetRowCellValue(grv_DSnhanvien.FocusedRowHandle, "tennhanvien").ToString();
                txt_SDT.Text = grv_DSnhanvien.GetRowCellValue(grv_DSnhanvien.FocusedRowHandle, "SDT").ToString();
                txt_ThuongTru.Text = grv_DSnhanvien.GetRowCellValue(grv_DSnhanvien.FocusedRowHandle, "noio").ToString();
                cmb_ChucVu.Text = grv_DSnhanvien.GetRowCellValue(grv_DSnhanvien.FocusedRowHandle, "tenchucvu").ToString();
                cmb_HocVan.Text = grv_DSnhanvien.GetRowCellValue(grv_DSnhanvien.FocusedRowHandle, "trinhdo").ToString();
                cmb_PhongBan.Text = grv_DSnhanvien.GetRowCellValue(grv_DSnhanvien.FocusedRowHandle, "tenphongban").ToString();
                txt_HeSoLuong.Text = grv_DSnhanvien.GetRowCellValue(grv_DSnhanvien.FocusedRowHandle, "giatri").ToString();
                txt_LuongNV.Text = grv_DSnhanvien.GetRowCellValue(grv_DSnhanvien.FocusedRowHandle, "luong").ToString();

                if ("Nam".Equals(grv_DSnhanvien.GetRowCellValue(grv_DSnhanvien.FocusedRowHandle, "gioitinh").ToString()))
                {
                    rdio_Nam.Checked = true;
                }
                else if ("Nữ".Equals(grv_DSnhanvien.GetRowCellValue(grv_DSnhanvien.FocusedRowHandle, "gioitinh").ToString()))
                {
                    rdio_Nu.Checked = true;
                }

            }
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
                ketqua = "NV001";
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
                        ketqua = "NV00" + x;
                    else if (x >= 10 && x < 100)
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
                                ketqua = "NV00" + x;
                            else if (x >= 10 && x < 100)
                                ketqua = "NV0" + x;
                            else
                                ketqua = "NV" + x;
                        }

                    }
                }

            }

            return ketqua;
        }

        private void Load_DanhSachNhanVien()
        {
            try
            {
                SqlCommand comm = new SqlCommand("SP_HienThi_DS_NhanVien", strConnect);
                comm.CommandType = CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@chuoi", txt_TimKiem.Text));
                comm.Parameters.Add(new SqlParameter("@so", x));
                comm.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grc_DSnhanvien.DataSource = dt;
                grv_DSnhanvien.Columns["manhanvien"].Caption = "Mã nhân viên";
                grv_DSnhanvien.Columns["tennhanvien"].Caption = "Tên nhân viên";
                grv_DSnhanvien.Columns["ngayvaolam"].Caption = "Ngày vào làm";
                grv_DSnhanvien.Columns["noio"].Caption = "Thường trú";
                grv_DSnhanvien.Columns["SDT"].Caption = "Số điện thoại";
                grv_DSnhanvien.Columns["trinhdo"].Caption = "Trình độ";
                grv_DSnhanvien.Columns["tenphongban"].Caption = "Phòng ban";
                grv_DSnhanvien.Columns["tenchucvu"].Caption = "Chức vụ";
                grv_DSnhanvien.Columns["giatri"].Caption = "Hệ số lương";
                grv_DSnhanvien.Columns["luong"].Caption = "Lương nhân viên";
                grv_DSnhanvien.Columns["gioitinh"].Caption = "Giới tính";

                grv_DSnhanvien.Columns["manhanvien"].BestFit();
                grv_DSnhanvien.Columns["tennhanvien"].BestFit();
                grv_DSnhanvien.Columns["ngayvaolam"].BestFit();
                grv_DSnhanvien.Columns["noio"].BestFit();
                grv_DSnhanvien.Columns["SDT"].BestFit();
                grv_DSnhanvien.Columns["trinhdo"].BestFit();
                grv_DSnhanvien.Columns["tenphongban"].BestFit();
                grv_DSnhanvien.Columns["tenchucvu"].BestFit();
                grv_DSnhanvien.Columns["giatri"].BestFit();
                grv_DSnhanvien.Columns["luong"].BestFit();
                grv_DSnhanvien.Columns["gioitinh"].BestFit();
            }
            catch
            {

            }
        }

        private void txt_TimKiem_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                x = float.Parse(txt_TimKiem.Text);
            }
            catch
            {
                x = 0;
            }
            Load_DanhSachNhanVien();
        }

        private long TinhSoNam()
        {
            DateTime date = DateTime.Today;
            long i = DateAndTime.DateDiff(DateInterval.Day, dtp_Ngay.DateTime, date, FirstDayOfWeek.System, FirstWeekOfYear.System);
            return i;
        }

        private void dtp_Ngay_EditValueChanged(object sender, EventArgs e)
        {
            ngaylamviec = TinhSoNam();
            txt_HeSoLuong.Text = HienThiHeSoLuong();
        }

        private List<string> ChuoitHeSoLuong()
        {
            List<string> list = new List<string>();
            SqlCommand command = new SqlCommand("select * from hesoluong", strConnect);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();

            string temp;
            da.Fill(dt);
            Object[] obj;
            DataRowCollection rowList = dt.Rows;
            for (int i = 0; i < rowList.Count; i++)
            {
                obj = rowList[i].ItemArray;
                temp = obj[2].ToString() + " - " + obj[1].ToString() + " -" + obj[0].ToString();
                list.Add(temp);
            }
            return list;
        }

        private void GetLuongCoBan()
        {
            SqlCommand comm = new SqlCommand("select top 1 luongcoban from nhanvien", strConnect);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            Object[] obj;
            DataRowCollection rowList = dt.Rows;
            obj = rowList[0].ItemArray;
            luongcoban = float.Parse(obj[0].ToString());
        }
        private List<HeSoLuong> GetListHeSoLuong()
        {
            List<HeSoLuong> listHS = new List<HeSoLuong>();
            List<string> listDS = ChuoitHeSoLuong();

            for (int i = 0; i < listDS.Count; i++)
            {
                HeSoLuong objHSL = new HeSoLuong();
                string[] A = listDS[i].Split('-');
                if (A.Length == 5)
                {
                    objHSL.hocvan = A[0].ToString();
                    objHSL.chucvu = A[1].ToString();
                    objHSL.time = A[2].ToString();
                    objHSL.giatri = float.Parse(A[3].ToString());
                    objHSL.ma = A[4].ToString();
                }
                else if (A.Length == 3)
                {
                    objHSL.chucvu = A[0].ToString();
                    objHSL.giatri = float.Parse(A[1].ToString());
                    objHSL.ma = A[2].ToString();
                }
                listHS.Add(objHSL);
            }
            return listHS;
        }

        private string HienThiHeSoLuong()
        {
            float hesoluong = 0;
            HeSoLuong objHSL = new HeSoLuong();
            objHSL.giatri = 0;
            List<HeSoLuong> listHS = GetListHeSoLuong();

            if (ngaylamviec < 730 && ngaylamviec >= 0) chuoi = " Dưới 2 năm ";
            else if (ngaylamviec >= 730 && ngaylamviec < 1460) chuoi = " Từ 2 năm đến 3 năm ";
            else if (ngaylamviec >= 1460 && ngaylamviec < 2190) chuoi = " Từ 4 năm đến 5 năm ";
            else if (ngaylamviec >= 2190 && ngaylamviec < 2920) chuoi = " Từ 6 năm đến 7 năm ";
            else if (ngaylamviec >= 2920) chuoi = " Trên 8 năm ";
            else chuoi = "Sai";

            for (int i = 0; i < listHS.Count; i++)
            {
                if (listHS[i].hocvan == null)
                {
                    if ("Sai".Equals(chuoi)) hesoluong = 0;
                    else if (cmb_ChucVu.Text.Equals(listHS[i].chucvu))
                    {
                        hesoluong = listHS[i].giatri;
                        maheso = listHS[i].ma;
                        break;
                    }
                }
                else
                {
                    try
                    {
                        if (listHS[i].chucvu.Equals(cmb_ChucVu.Text) && listHS[i].hocvan.Equals(cmb_HocVan.SelectedItem.ToString()) && listHS[i].time.Equals(chuoi))
                        {
                            hesoluong = listHS[i].giatri;
                            maheso = listHS[i].ma;
                            break;
                        }
                    }
                    catch
                    {

                    }
                }
            }

            try
            {
                GetLuongCoBan();
                txt_LuongNV.Text = double.Parse((hesoluong * luongcoban).ToString()).ToString("#,###");
            }
            catch
            {
                txt_LuongNV.Text = "";
            }
            return hesoluong.ToString();
        }

        private void cmb_HocVan_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_HeSoLuong.Text = HienThiHeSoLuong();
        }

        private void cmb_ChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_HeSoLuong.Text = HienThiHeSoLuong();
        }

        private void Load_PhongBan_cmb()
        {
            SqlCommand comm = new SqlCommand("select maphongban,tenphongban from phongban", strConnect);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmb_PhongBan.DataSource = dt;
            cmb_PhongBan.DisplayMember = "tenphongban";
            cmb_PhongBan.ValueMember = "maphongban";
            cmb_PhongBan.SelectedIndex = -1;
        }

        private void Load_ChucVu_cmb()
        {
            SqlCommand comm = new SqlCommand("select machucvu,tenchucvu from chucvu", strConnect);
            SqlDataAdapter da = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmb_ChucVu.DataSource = dt;
            cmb_ChucVu.DisplayMember = "tenchucvu";
            cmb_ChucVu.ValueMember = "machucvu";
            cmb_ChucVu.SelectedIndex = -1;
        }

        private bool checkSDT(string sdt)
        {
            bool check;
            string MaNV = "(\\+84|0)\\d{9,10}$";
            check = Regex.IsMatch(sdt, MaNV);
            return check;
        }

        private void txt_SDT_EditValueChanged(object sender, EventArgs e)
        {
            if ("".Equals(txt_SDT.Text))
            {
                error_SDT.SetError(txt_SDT, "");
            }
            else
            {
                if (!checkSDT(txt_SDT.Text))
                {
                    error_SDT.Icon = Properties.Resources.ic_nook;
                    error_SDT.SetError(txt_SDT, "Số điện thoại không hợp lệ");
                }
                else
                {
                    error_SDT.Icon = Properties.Resources.ic_ok;
                    error_SDT.SetError(txt_SDT, "Số điện thoại hợp lệ");
                }
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            btn_Luu.Visible = true;
            btn_Huy.Visible = true;
            btn_CapNhat.Enabled = false;
            btn_Xoa.Enabled = false;

            txt_MaNV.Text = TaoMaNhanVien();
            txt_TenNV.Text = "";
            rdio_Nam.Checked = rdio_Nu.Checked = false;
            dtp_Ngay.Text = DateTime.Today.ToString();
            txt_SDT.Text = "";
            txt_ThuongTru.Text = "";
            cmb_ChucVu.SelectedIndex = -1;
            cmb_HocVan.SelectedIndex = -1;
            cmb_PhongBan.SelectedIndex = -1;
            txt_LuongNV.Text = "";
            txt_HeSoLuong.Text = "";
        }

        private void ThemNhanVien(object sender, EventArgs e)
        {
            int i = 1;
            if (rdio_Nam.Checked == true) i = 1;
            else if (rdio_Nu.Checked == true) i = 0;
            if (rdio_Nam.Checked == false && rdio_Nu.Checked == false)
            {
                XtraMessageBox.Show("Bạn chưa chọn giới tính cho nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ("".Equals(txt_TenNV.Text))
            {
                XtraMessageBox.Show("Bạn chưa điền tên nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ("".Equals(txt_SDT.Text))
            {
                XtraMessageBox.Show("Bạn chưa điền số điện thoại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ("".Equals(txt_LuongNV.Text) || "0".Equals(txt_HeSoLuong.Text))
            {
                XtraMessageBox.Show("Ngày vào làm không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult dialog = XtraMessageBox.Show("Bạn có chắc chắn muốn thêm nhân viên", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        SqlCommand comm = new SqlCommand("SP_ThemNhanVien", strConnect);
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.Add(new SqlParameter("@manv", txt_MaNV.Text));
                        comm.Parameters.Add(new SqlParameter("@tennv", txt_TenNV.Text));
                        comm.Parameters.Add(new SqlParameter("@gioitinh", i));
                        comm.Parameters.Add(new SqlParameter("@ngay", dtp_Ngay.DateTime.Date));
                        comm.Parameters.Add(new SqlParameter("@noio", txt_ThuongTru.Text));
                        comm.Parameters.Add(new SqlParameter("@SDT", txt_SDT.Text));
                        comm.Parameters.Add(new SqlParameter("@mahs", maheso));
                        comm.Parameters.Add(new SqlParameter("@maphongban", cmb_PhongBan.SelectedValue.ToString()));
                        comm.Parameters.Add(new SqlParameter("@machucvu", cmb_ChucVu.SelectedValue.ToString()));
                        comm.Parameters.Add(new SqlParameter("@trinhdo", cmb_HocVan.SelectedItem.ToString()));
                        comm.Parameters.Add(new SqlParameter("@heso", txt_HeSoLuong.Text));
                        comm.ExecuteNonQuery();
                        Load_DanhSachNhanVien();
                        btn_Huy_Click(sender, e);
                        XtraMessageBox.Show("Thêm mới nhân viên thành công", "Thông báo", MessageBoxButtons.OK);
                    }
                    catch
                    {
                        XtraMessageBox.Show("Bạn chưa điền đẩy đủ thông tin nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (btn_Them.Enabled == true)
            {
                ThemNhanVien(sender, e);
            }
            else if (btn_CapNhat.Enabled == true)
            {
                SuaThongTinNhanVien(sender, e);
            }
        }

        private void SuaThongTinNhanVien(object sender, EventArgs e)
        {
            int i = 1;
            if (rdio_Nam.Checked == true) i = 1;
            else if (rdio_Nu.Checked == true) i = 0;

            DialogResult dialog = XtraMessageBox.Show("Bạn có chắc chắn muốn sửa thông tin nhân viên", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                try
                {
                    SqlCommand comm = new SqlCommand("SP_SuaThongTinNhanVien", strConnect);
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Parameters.Add(new SqlParameter("@manv", txt_MaNV.Text));
                    comm.Parameters.Add(new SqlParameter("@tennv", txt_TenNV.Text));
                    comm.Parameters.Add(new SqlParameter("@gioitinh", i));
                    comm.Parameters.Add(new SqlParameter("@ngay", dtp_Ngay.DateTime.Date));
                    comm.Parameters.Add(new SqlParameter("@noio", txt_ThuongTru.Text));
                    comm.Parameters.Add(new SqlParameter("@SDT", txt_SDT.Text));
                    comm.Parameters.Add(new SqlParameter("@mahs", maheso));
                    comm.Parameters.Add(new SqlParameter("@maphongban", cmb_PhongBan.SelectedValue.ToString()));
                    comm.Parameters.Add(new SqlParameter("@machucvu", cmb_ChucVu.SelectedValue.ToString()));
                    comm.Parameters.Add(new SqlParameter("@trinhdo", cmb_HocVan.SelectedItem.ToString()));
                    comm.ExecuteNonQuery();
                    Load_DanhSachNhanVien();
                    btn_Huy_Click(sender, e);
                    XtraMessageBox.Show("Sửa thông tin nhân viên thành công", "Thông báo", MessageBoxButtons.OK);
                }
                catch
                {
                    XtraMessageBox.Show("Bạn chưa điền đẩy đủ thông tin nhân viên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_CapNhat_Click(object sender, EventArgs e)
        {
            btn_Luu.Visible = true;
            btn_Huy.Visible = true;
            btn_Them.Enabled = false;
            btn_Xoa.Enabled = false;
        }

        private void btn_Huy_Click(object sender, EventArgs e)
        {
            btn_Them.Enabled = true;
            btn_CapNhat.Enabled = true;
            btn_Xoa.Enabled = true;
            btn_Luu.Visible = false;
            btn_Huy.Visible = false;
        }

        private void grc_DSnhanvien_Click(object sender, EventArgs e)
        {
            try
            {
                dtp_Ngay.Text = grv_DSnhanvien.GetRowCellValue(grv_DSnhanvien.FocusedRowHandle, "ngayvaolam").ToString();
                txt_MaNV.Text = grv_DSnhanvien.GetRowCellValue(grv_DSnhanvien.FocusedRowHandle, "manhanvien").ToString();
                txt_TenNV.Text = grv_DSnhanvien.GetRowCellValue(grv_DSnhanvien.FocusedRowHandle, "tennhanvien").ToString();
                txt_SDT.Text = grv_DSnhanvien.GetRowCellValue(grv_DSnhanvien.FocusedRowHandle, "SDT").ToString();
                txt_ThuongTru.Text = grv_DSnhanvien.GetRowCellValue(grv_DSnhanvien.FocusedRowHandle, "noio").ToString();
                cmb_ChucVu.Text = grv_DSnhanvien.GetRowCellValue(grv_DSnhanvien.FocusedRowHandle, "tenchucvu").ToString();
                cmb_HocVan.Text = grv_DSnhanvien.GetRowCellValue(grv_DSnhanvien.FocusedRowHandle, "trinhdo").ToString();
                cmb_PhongBan.Text = grv_DSnhanvien.GetRowCellValue(grv_DSnhanvien.FocusedRowHandle, "tenphongban").ToString();
                txt_HeSoLuong.Text = grv_DSnhanvien.GetRowCellValue(grv_DSnhanvien.FocusedRowHandle, "giatri").ToString();
                txt_LuongNV.Text = grv_DSnhanvien.GetRowCellValue(grv_DSnhanvien.FocusedRowHandle, "luong").ToString();
                if ("Nam".Equals(grv_DSnhanvien.GetRowCellValue(grv_DSnhanvien.FocusedRowHandle, "gioitinh").ToString()))
                {
                    rdio_Nam.Checked = true;
                }
                else if ("Nữ".Equals(grv_DSnhanvien.GetRowCellValue(grv_DSnhanvien.FocusedRowHandle, "gioitinh").ToString()))
                {
                    rdio_Nu.Checked = true;
                }
                btn_Huy_Click(sender, e);
            }
            catch
            {

            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                string manv = grv_DSnhanvien.GetRowCellValue(grv_DSnhanvien.FocusedRowHandle, "manhanvien").ToString();
                DialogResult dia = XtraMessageBox.Show("Bạn có chắc muốn xóa nhân viên " + manv, "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dia == DialogResult.Yes)
                {
                    try
                    {
                        SqlCommand comm = new SqlCommand("SP_XoaNhanVien", strConnect);
                        comm.CommandType = CommandType.StoredProcedure;
                        comm.Parameters.Add(new SqlParameter("@ma", manv));
                        comm.ExecuteNonQuery();
                        XtraMessageBox.Show("Xóa nhân viên thành công", "Thông báo", MessageBoxButtons.OK);
                        Load_DanhSachNhanVien();
                    }
                    catch
                    {
                        XtraMessageBox.Show("Xóa nhân viên thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            catch
            {
                XtraMessageBox.Show("Chọn nhân viên cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
