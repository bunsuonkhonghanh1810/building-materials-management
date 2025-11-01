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
                var client = SupabaseService.Client;

                var response = await client.From<User>().Get();

                var users = response.Models;

                dgvUsers.DataSource = users;

                dgvUsers.RowHeadersVisible = false;
                dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvUsers.AllowUserToResizeColumns = false;
                dgvUsers.AllowUserToResizeRows = false;

                if (dgvUsers.Columns["Id"] != null)
                {
                    dgvUsers.Columns["Id"].HeaderText = "STT";
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
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
