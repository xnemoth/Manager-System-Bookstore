using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCuaHangSach
{
    public partial class Frm_Login : Form
    {
        public static string ma, ID = "";
        public static int Permission;
        public Frm_Login()
        {
            Splash spl = new Splash();
            spl.ShowDialog();
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            Functions.Connect();
            string userName = tbxUsername.Text;
            string passWord = tbxPassword.Text;
            string id = Functions.checkUser(userName, passWord) ;
            if (id != "")
            {
                string sql = ("SELECT MaNhanVien FROM T02_NhanVien WHERE MaNhanVien ='" + userName + "' and Password='" + passWord + "'");
                ma = Functions.GetFieldValues(sql);
                int L = id.Length;
                ID = id.Substring(0, L - 1);
                Permission = Convert.ToInt32(id.Substring(L - 1));
                MessageBox.Show("Xin chào " + ID + " đã đăng nhập với quyền mức " + Permission, "Đăng nhập thành công!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                Frm_Main Frmain = new Frm_Main();
                Frmain.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
                tbxPassword.Focus();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbxUsername.Text = "";
            tbxPassword.Text = "";
        }

        private void txtUsername_Keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{TAB}");
        }

        private void txtPassword_Keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogin.Focus();
        }

        private void FrmLogin_Closing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlr = MessageBox.Show("Bạn có muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlr == DialogResult.No)
                e.Cancel = true;
        }

        private void cbSP_CC(object sender, EventArgs e)
        {
            if (cbSP.Checked == true)
                tbxPassword.UseSystemPasswordChar = false;
            else
                tbxPassword.UseSystemPasswordChar = true;
        }

        private void tbxPW_TC(object sender, EventArgs e)
        {
            if (cbSP.Checked == true)
                tbxPassword.UseSystemPasswordChar = false;
            else
                tbxPassword.UseSystemPasswordChar = true;
        }

        private void btnUM_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = "C:\\Users\\CNC\\Documents\\Visual Studio 2010\\Projects\\QuanLyCuaHangSach\\QuanLyCuaHangSach\\Resource\\NDNL.docx";
            prc.Start();
        }
    }
}
