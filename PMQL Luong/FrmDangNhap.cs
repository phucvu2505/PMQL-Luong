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
using System.Text.RegularExpressions;
using PMQL_Luong.Entities;
using System.IO;

namespace PMQL_Luong
{
    public partial class FrmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        private SqlConnection strConnect;
        private bool checkId;
        private bool checkPass;
        public ICallBack ICall { get; set; }

        public FrmDangNhap(SqlConnection strConnect)
        {
            InitializeComponent();
            this.strConnect = strConnect;
            checkId = false;
            checkPass = false;
        }

        private void lbNoAcc_MouseHover(object sender, EventArgs e)
        {
            lbNoAcc.Appearance.ForeColor = Color.BlueViolet;
        }

        private void lbNoAcc_MouseLeave(object sender, EventArgs e)
        {
            lbNoAcc.Appearance.ForeColor = Color.Red;
        }

        private void lbNoAcc_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Liên hệ với người quản trị để được cấp tài khoản.", "Thông báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lbLossPW_MouseHover(object sender, EventArgs e)
        {
            lbLossPW.Appearance.Font = lbLossPW.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
        }

        private void lbLossPW_MouseLeave(object sender, EventArgs e)
        {
            lbLossPW.Appearance.Font = lbLossPW.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F);
        }

        private void lbLossPW_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Liên hệ với người quản trị để lấy lại mật khẩu.", "Thông báo hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtAcc_EditValueChanged(object sender, EventArgs e)
        {
            if (!checkID(txtAcc.Text))
            {
                errID.Icon = Properties.Resources.ic_nook;
                errID.SetError(txtAcc, "Tài khoản chưa đúng định dạng");
            }
            else
            {
                errID.Icon = Properties.Resources.ic_ok;
                errID.SetError(txtAcc, "Tài khoản đúng định dạng");
            }
        }

        public bool checkID(String userName)
        {
            bool check = false;

            string USERNAME_PATTERN = "^[a-zA-Z0-9]{3,15}$";
            check = Regex.IsMatch(userName, USERNAME_PATTERN);
            return check;
        }

        public bool checkPassWord(String userName)
        {
            bool check = false;
            string USERNAME_PATTERN = "((?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[@#$%]).{6,20})";
            check = Regex.IsMatch(userName, USERNAME_PATTERN);
            return check;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            User userLoginSuccess = new User();
            checkId = txtAcc.Text == "" ? false : true;
            checkPass = txtPass.Text == "" ? false : true;
            if (checkSavePW.Checked)
            {
                DialogResult result = XtraMessageBox.Show("Bạn có muốn lưu mật khẩu không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    checkSavePW.Checked = false;
                }
            }
            if (!checkId || !checkPass)
            {
                XtraMessageBox.Show("Không được bỏ trống ID hoặc PassWord", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                List<User> listUser = listAcc();
                bool check = false;
                foreach (User us in listUser)
                {

                    if (us.Id == txtAcc.Text && us.PassWord == txtPass.Text)
                    {
                        userLoginSuccess = us;
                        check = true;
                        break;
                    }
                }
                if (check)
                {
                    if (checkSavePW.Checked)
                    {

                        FileStream file = File.OpenWrite("save.txt");
                        file.Close();
                        StreamWriter write = new StreamWriter("save.txt");
                        write.WriteLine(txtAcc.Text);
                        write.WriteLine(txtPass.Text);
                        write.Close();
                    }
                    ICall.loginSuccess(userLoginSuccess);
                    this.Dispose();
                }
                else
                {
                    XtraMessageBox.Show("Đăng nhập thất bại id hoặc password không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtPass_EditValueChanged(object sender, EventArgs e)
        {
            if (!checkID(txtPass.Text))
            {
                errPassWord.Icon = Properties.Resources.ic_nook;
                errPassWord.SetError(txtPass, "Tài khoản chưa đúng định dạng");
            }
            else
            {
                errPassWord.Icon = Properties.Resources.ic_ok;
                errPassWord.SetError(txtPass, "Tài khoản đúng định dạng");
            }
        }

        public List<User> listAcc()
        {
            List<User> list = new List<User>();
            User user = new User();
            SqlCommand sqlCommand = new SqlCommand(@"select tk.mataikhoan, tk.matkhau, nv.tennhanvien, tk.quyentruycap from taikhoan tk, nhanvien nv
                                                        where tk.mataikhoan = nv.mataikhoan", strConnect);
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable table = new DataTable();

            adapter.Fill(table);
            object[] objList;
            DataRowCollection rowList = table.Rows;
            for (int i = 0; i < rowList.Count; i++)
            {
                objList = rowList[i].ItemArray;
                user = new User();
                user.Id = objList[0].ToString();
                user.PassWord = objList[1].ToString();
                user.Name = objList[2].ToString();
                user.Permission = objList[3].ToString();
                list.Add(user);
            }
            return list;
        }

        private void txtAcc_Leave(object sender, EventArgs e)
        {
            if (txtAcc.Text == "")
            {
                errID.Icon = Properties.Resources.ic_nook;
                errID.SetError(txtAcc, "Không được bỏ trống id");
                checkId = false;
            }
            else
            {
                checkId = true;
                String[] str = new String[2];
                if (File.Exists("save.txt"))
                {
                    StreamReader read = File.OpenText("save.txt");
                    String input;
                    int i = 0;
                    while ((input = read.ReadLine()) != null)
                    {
                        str[i] = input;
                        i++;
                    }
                    read.Close();
                    if (txtAcc.Text == str[0])
                    {
                        txtPass.Text = str[1];
                    }
                }
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                errPassWord.Icon = Properties.Resources.ic_nook;
                errPassWord.SetError(txtAcc, "Không được bỏ trống id");
                checkPass = false;
            }
            else
            {
                checkPass = true;
            }
        }

        private void FrmDangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult drs = XtraMessageBox.Show("Bạn có muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drs == DialogResult.Yes)
            {
                ICall.formClosing();
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}