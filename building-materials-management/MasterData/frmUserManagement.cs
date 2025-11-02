using building_materials_management.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace building_materials_management.MasterData
{
    public partial class frmUserManagement : Form
    {
        private string selectedUserId;
        private string supabaseServiceKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6InRzZ21zenRsaXlhZGNqenZvcGF5Iiwicm9sZSI6InNlcnZpY2Vfcm9sZSIsImlhdCI6MTc2MTY0MTE2MCwiZXhwIjoyMDc3MjE3MTYwfQ.0hS4X6jfOyEKOgRDGGLybCbo786x4XK5JG6RtZylOOE";

        public frmUserManagement()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ControlBox = false;
            this.CenterToScreen();
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.Load += frmUserManagement_Load;
        }

        private async void frmUserManagement_Load(object sender, EventArgs e)
        {
            await LoadUsersAsync();
        }

        private async Task LoadUsersAsync()
        {
            try
            {
                var response = await SupabaseService.Client.From<User>().Get();

                var users = response.Models
                    .Select((x, index) => new
                    {
                        STT = index + 1,
                        Id = x.Id,
                        HoTen = x.HoTen,
                        Email = x.Email,
                        Role = x.Role,
                    }).ToList();

                dgvUsers.DataSource = users;

                dgvUsers.RowHeadersVisible = false;
                dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvUsers.AllowUserToResizeColumns = false;
                dgvUsers.AllowUserToResizeRows = false;

                if (dgvUsers.Columns["Id"] != null)
                {
                    dgvUsers.Columns["Id"].Visible = false;
                }
                if (dgvUsers.Columns["STT"] != null)
                {
                    dgvUsers.Columns["STT"].HeaderText = "STT";
                    dgvUsers.Columns["STT"].Width = 50;
                    dgvUsers.Columns["STT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                }
                if (dgvUsers.Columns["HoTen"] != null)
                {
                    dgvUsers.Columns["HoTen"].HeaderText = "Họ Tên";
                }
                if (dgvUsers.Columns["Role"] != null)
                {
                    dgvUsers.Columns["Role"].HeaderText = "Quyền";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách người dùng: " + ex.Message);
            }

            txtEmail.Text = string.Empty;
            txtName.Text = string.Empty;
            txtPassword.Text = string.Empty;

            txtEmail.Enabled = false;
            txtName.Enabled = false;
            txtPassword.Enabled = false;
            cbbRole.Enabled = false;

            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnCancel.Enabled = false;

            btnAdd.Text = "Thêm";
            btnEdit.Text = "Sửa";

            cbbRole.Items.Clear();
            cbbRole.Items.Add("-- Vui lòng chọn quyền --");
            cbbRole.Items.Add("admin");
            cbbRole.Items.Add("quan_ly");
            cbbRole.Items.Add("nhan_vien");
            cbbRole.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Thêm")
            {
                txtEmail.Enabled = true;
                txtName.Enabled = true;
                txtPassword.Enabled = true;
                cbbRole.Enabled = true;
                btnAdd.Text = "Lưu";
                btnEdit.Enabled = false;
                btnCancel.Enabled = true;

                txtEmail.Focus();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtEmail.Text) ||
                    string.IsNullOrWhiteSpace(txtName.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                    return;
                }
                if (cbbRole.SelectedIndex == 0)
                {
                    MessageBox.Show("Vui lòng chọn quyền cho người dùng.");
                    return;
                }

                var client = SupabaseService.Client;
                string email = txtEmail.Text;
                string password = txtPassword.Text;
                string hoTen = txtName.Text;
                string role = cbbRole.SelectedItem.ToString();

                try
                {
                    var adminAuth = client.AdminAuth(supabaseServiceKey);

                    var userAttributes = new Supabase.Gotrue.AdminUserAttributes
                    {
                        Email = email,
                        Password = password,
                        EmailConfirm = true
                    };

                    var newUser = await adminAuth.CreateUser(userAttributes);

                    if (newUser != null)
                    {
                        await client.From<User>()
                            .Where(u => u.Email == email)
                            .Set(u => u.HoTen, hoTen)
                            .Set(u => u.Role, role)
                            .Update();

                        MessageBox.Show("Tạo người dùng mới thành công!");

                        await LoadUsersAsync();
                    }
                    else
                    {
                        MessageBox.Show("Không thể tạo người dùng. Vui lòng thử lại.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tạo người dùng: " + ex.Message);
                    return;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmUserManagement_Load(sender, e);
        }

        private void dgvUsers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedRow = dgvUsers.Rows[e.RowIndex];
                selectedUserId = selectedRow.Cells["Id"].Value.ToString();
                txtName.Text = selectedRow.Cells["HoTen"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                cbbRole.SelectedItem = selectedRow.Cells["Role"].Value.ToString();
                txtEmail.Enabled = false;
                txtName.Enabled = false;
                txtPassword.Enabled = false;
                cbbRole.Enabled = false;
                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnCancel.Enabled = false;
                btnAdd.Text = "Thêm";
                btnEdit.Text = "Sửa";
            }
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Sửa")
            {
                txtName.Enabled = true;
                txtPassword.Enabled = true;
                cbbRole.Items.Add("Gỡ quyền");
                cbbRole.Enabled = true;

                btnEdit.Text = "Lưu";
                btnAdd.Enabled = false;
                btnCancel.Enabled = true;
                txtName.Focus();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtName.Text))
                {
                    MessageBox.Show("Vui lòng không để trống Họ Tên.");
                    return;
                }
                if (cbbRole.SelectedIndex == 0)
                {
                    MessageBox.Show("Vui lòng chọn quyền cho người dùng.");
                    return;
                }

                try
                {
                    var client = SupabaseService.Client;

                    string hoTen = txtName.Text;
                    string role = cbbRole.SelectedItem.ToString();

                    await client.From<User>()
                        .Where(u => u.Id == Guid.Parse(selectedUserId))
                        .Set(u => u.HoTen, hoTen)
                        .Set(u => u.Role, role)
                        .Update();

                    string newPassword = txtPassword.Text;
                    if (!string.IsNullOrWhiteSpace(newPassword))
                    {
                        var adminAuth = client.AdminAuth(supabaseServiceKey);

                        var attributesToUpdate = new Supabase.Gotrue.AdminUserAttributes
                        {
                            Password = newPassword
                        };

                        await adminAuth.UpdateUserById(selectedUserId, attributesToUpdate);
                    }

                    MessageBox.Show("Cập nhật thông tin người dùng thành công!");
                    await LoadUsersAsync(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi cập nhật người dùng:\n\n" + ex.ToString());

                }
            }
        }
    }
}