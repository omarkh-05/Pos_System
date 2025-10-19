using businessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Users
{
    public partial class frmUserLogin : Form
    {
        private UserBLL _usersBussinessObject;
        private User _user;
        public frmUserLogin()
        {
            InitializeComponent();
        }

        private void frmUserLogin_Load(object sender, EventArgs e)
        {
            string savedUsername = "", savedPassword = "";
            UserSession.GetStoredCredential(ref savedUsername, ref savedPassword);
            if (!string.IsNullOrEmpty(savedUsername))
            {
                txtUserName.Text = savedUsername;
                txtPassword.Text = savedPassword;
                cbRememberMe.Checked = true;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string path = ConfigurationManager.AppSettings["LogPath"];

            // تخزين بيانات اليوزر إذا تم التفعيل
            if (cbRememberMe.Checked)
                UserSession.RememberUsernameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());
            else
                UserSession.RememberUsernameAndPassword("", "");


            if (await _CheackLoginInfo())
            {
                using (StreamWriter writer = new StreamWriter(path, true))
                {
                    writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - User {_user.UserName} logged in");
                }

                UserSession.SetUser(_user);

                frmMainPage mainForm = new frmMainPage();
                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("خطأ في اسم المستخدم / كلمة المرور أو المستخدم غير فعال");
            }
        }
        private async Task<bool> _CheackLoginInfo()
        {
            string hashedPassword =UserBLL.ComputeHash(txtPassword.Text.Trim());
            _user = await UserBLL.GetUserForLogin(txtUserName.Text.Trim(), hashedPassword);

            if (_user == null || !_user.IsActive)
            {
                return false;
            }
            return true;

        }

        private void cbShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPass.CheckState == CheckState.Checked)
            {
                txtPassword.Password = false;
            }
            else
            { txtPassword.Password = true; }
        }
    }
}
