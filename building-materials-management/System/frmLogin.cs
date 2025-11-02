using building_materials_management.Classes;
using building_materials_management.Main;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace building_materials_management.Login
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.CenterToScreen();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.txtPassword.PasswordChar = '*';
            btnLogin_Click(sender, e);
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var email = "admin@test.com";
            var password = "123456";

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập Email và Mật khẩu.");
                return;
            }

            try
            {
                var client = SupabaseService.Client;

                var session = await client.Auth.SignIn(email, password);

                if (session != null && session.User != null)
                {
                    var response = await client.From<User>().Get();
                    var allUsers = response.Models;
                    var profile = allUsers.FirstOrDefault(u => u.Id == Guid.Parse(session.User.Id));

                    if (profile != null)
                    {
                        GlobalState.CurrentUserRole = profile.Role;
                        GlobalState.CurrentUserName = profile.HoTen;

                        MessageBox.Show($"Đăng nhập thành công! Chào mừng {profile.HoTen}.");

                        this.Hide();
                        frmMain formMain = new frmMain(); 
                        formMain.Show();
                    }
                    else
                    {
                        MessageBox.Show("Đăng nhập thành công nhưng không tìm thấy Profile!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message);
            }
        }

        
    }
}
