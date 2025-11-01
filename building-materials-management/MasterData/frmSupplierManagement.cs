using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using building_materials_management.Classes;

namespace building_materials_management.MasterData
{
    public partial class frmSupplierManagement : Form
    {
        public frmSupplierManagement()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ControlBox = false;
            this.CenterToScreen();
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.Load += frmSupplierManagement_Load;
        }

        private async void frmSupplierManagement_Load(object sender, EventArgs e)
        {
            await LoadSuppliersAsync();
        }

        private void SetButtonEnabled(string name, bool enabled)
        {
            var ctl = this.Controls.Find(name, true).FirstOrDefault() as Button;
            if (ctl != null) ctl.Enabled = enabled;
        }

        private void SetButtonText(string name, string text)
        {
            var ctl = this.Controls.Find(name, true).FirstOrDefault() as Button;
            if (ctl != null) ctl.Text = text;
        }

        private async Task LoadSuppliersAsync()
        {
            var response = await SupabaseService.Client.From<Supplier>().Get();

            var list = response.Models
                .Where(x => !x.IsDeleted)
                .Select(x => new
                {
                    x.Id,
                    x.TenNCC,
                    x.DiaChi,
                    x.Email,
                    x.SoDienThoai,
                    x.MaSoThue
                }).ToList();

            dgvSupplier.DataSource = list;

            dgvSupplier.RowHeadersVisible = false;
            dgvSupplier.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvSupplier.AllowUserToResizeColumns = false;
            dgvSupplier.AllowUserToResizeRows = false;
            
            if (dgvSupplier.Columns.Contains("Id"))
                dgvSupplier.Columns["Id"].HeaderText = "STT";
            if (dgvSupplier.Columns.Contains("TenNCC"))
                dgvSupplier.Columns["TenNCC"].HeaderText = "Tên nhà cung cấp";
            if (dgvSupplier.Columns.Contains("DiaChi"))
                dgvSupplier.Columns["DiaChi"].HeaderText = "Địa chỉ";
            if (dgvSupplier.Columns.Contains("Email"))
                dgvSupplier.Columns["Email"].HeaderText = "Email";
            if (dgvSupplier.Columns.Contains("SoDienThoai"))
                dgvSupplier.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
            if (dgvSupplier.Columns.Contains("MaSoThue"))
                dgvSupplier.Columns["MaSoThue"].HeaderText = "Mã số thuế";

            txtSupplierName.Text = string.Empty;
            txtSupplierAddress.Text = string.Empty;
            txtSupplierEmail.Text = string.Empty;
            txtSupplierPhoneNumber.Text = string.Empty;
            txtTaxNumber.Text = string.Empty;

            txtSupplierName.Enabled = false;
            txtSupplierAddress.Enabled = false;
            txtSupplierEmail.Enabled = false;
            txtSupplierPhoneNumber.Enabled = false;
            txtTaxNumber.Enabled = false;

            btnAdd.Text = "Thêm";
            btnEdit.Text = "Sửa";

            SetButtonEnabled("btnAdd", true);
            SetButtonText("btnAdd", "Thêm");
            SetButtonEnabled("btnEdit", false);
            SetButtonEnabled("btnDelete", false);
            SetButtonEnabled("btnCancel", false);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dgvSupplier.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSupplier.DefaultCellStyle.SelectionBackColor = Color.Gold;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvSupplier.Rows[e.RowIndex].Selected = true;

                SetButtonEnabled("btnEdit", true);
                SetButtonEnabled("btnDelete", true);
                SetButtonEnabled("btnCancel", true);
                SetButtonEnabled("btnAdd", false);

                var row = dgvSupplier.Rows[e.RowIndex];
                txtSupplierName.Text = row.Cells["TenNCC"].Value?.ToString();
                txtSupplierAddress.Text = row.Cells["DiaChi"].Value?.ToString();
                txtSupplierEmail.Text = row.Cells["Email"].Value?.ToString();
                txtSupplierPhoneNumber.Text = row.Cells["SoDienThoai"].Value?.ToString();
                txtTaxNumber.Text = row.Cells["MaSoThue"].Value?.ToString();

                txtSupplierName.Enabled = false;
                txtSupplierAddress.Enabled = false;
                txtSupplierEmail.Enabled = false;
                txtSupplierPhoneNumber.Enabled = false;
                txtTaxNumber.Enabled = false;
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "Thêm")
            {
                txtSupplierName.Enabled = true;
                txtSupplierAddress.Enabled = true;
                txtSupplierEmail.Enabled = true;
                txtSupplierPhoneNumber.Enabled = true;
                txtTaxNumber.Enabled = true;

                txtSupplierName.Text = string.Empty;
                txtSupplierAddress.Text = string.Empty;
                txtSupplierEmail.Text = string.Empty;
                txtSupplierPhoneNumber.Text = string.Empty;
                txtTaxNumber.Text = string.Empty;

                btnAdd.Text = "Lưu";
                SetButtonEnabled("btnEdit", false);
                SetButtonEnabled("btnDelete", false);
                SetButtonEnabled("btnCancel", true);

                txtSupplierName.Focus();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtSupplierName.Text))
                {
                    MessageBox.Show("Tên nhà cung cấp không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSupplierName.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtSupplierAddress.Text))
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ nhà cung cấp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSupplierAddress.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtSupplierEmail.Text) || !txtSupplierEmail.Text.Contains("@"))
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ email hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSupplierEmail.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtSupplierPhoneNumber.Text))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSupplierPhoneNumber.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtTaxNumber.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã số thuế.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTaxNumber.Focus();
                    return;
                }

                var supplier = new Supplier
                {
                    TenNCC = txtSupplierName.Text.Trim(),
                    DiaChi = txtSupplierAddress.Text.Trim(),
                    Email = txtSupplierEmail.Text.Trim(),
                    SoDienThoai = txtSupplierPhoneNumber.Text.Trim(),
                    MaSoThue = txtTaxNumber.Text.Trim(),
                    CreatedAt = DateTime.Now
                };

                try
                {
                    var client = SupabaseService.Client;
                    await client.From<Supplier>().Insert(supplier);

                    MessageBox.Show("Thêm nhà cung cấp thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    frmSupplierManagement_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thêm nhà cung cấp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSupplierPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtSupplierPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            var tb = sender as TextBox;
            if (tb == null) return;

            var digits = new string(tb.Text.Where(char.IsDigit).ToArray());
            if (tb.Text != digits)
            {
                var selStart = tb.SelectionStart;
                tb.Text = digits;
                tb.SelectionStart = Math.Min(selStart, tb.Text.Length);
            }
        }

        private int? GetSelectedSupplierId()
        {
            if (dgvSupplier.SelectedRows.Count > 0)
            {
                var row = dgvSupplier.SelectedRows[0];
                if (row.Cells["Id"].Value != null && int.TryParse(row.Cells["Id"].Value.ToString(), out int id))
                    return id;
            }
            return null;
        }

        private async void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "Sửa")
            {
                txtSupplierName.Enabled = true;
                txtSupplierAddress.Enabled = true;
                txtSupplierEmail.Enabled = true;
                txtSupplierPhoneNumber.Enabled = true;
                txtTaxNumber.Enabled = true;

                btnEdit.Text = "Lưu";
                SetButtonEnabled("btnAdd", false);
                SetButtonEnabled("btnDelete", false);
                SetButtonEnabled("btnCancel", true);
            }
            else // Lưu
            {
                var id = GetSelectedSupplierId();
                if (id == null)
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtSupplierName.Text))
                {
                    MessageBox.Show("Tên nhà cung cấp không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSupplierName.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtSupplierAddress.Text))
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ nhà cung cấp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSupplierAddress.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtSupplierEmail.Text) || !txtSupplierEmail.Text.Contains("@"))
                {
                    MessageBox.Show("Vui lòng nhập địa chỉ email hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSupplierEmail.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtSupplierPhoneNumber.Text))
                {
                    MessageBox.Show("Vui lòng nhập số điện thoại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSupplierPhoneNumber.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(txtTaxNumber.Text))
                {
                    MessageBox.Show("Vui lòng nhập mã số thuế.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTaxNumber.Focus();
                    return;
                }
                var supplierUpdate = new Supplier
                {
                    Id = id.Value,
                    TenNCC = txtSupplierName.Text.Trim(),
                    DiaChi = txtSupplierAddress.Text.Trim(),
                    Email = txtSupplierEmail.Text.Trim(),
                    SoDienThoai = txtSupplierPhoneNumber.Text.Trim(),
                    MaSoThue = txtTaxNumber.Text.Trim(),
                    // preserve or set CreatedAt as needed; setting to current time
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                };
                try
                {
                    var client = SupabaseService.Client;
                    await client.From<Supplier>().Update(supplierUpdate);
                    MessageBox.Show("Cập nhật nhà cung cấp thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnEdit.Text = "Sửa";
                    await LoadSuppliersAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật nhà cung cấp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var id = GetSelectedSupplierId();
            if (id == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa nhà cung cấp này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var client = SupabaseService.Client;
                    // soft-delete: set is_deleted = true by updating Supplier.IsDeleted
                    var supplier = await client
                        .From<Supplier>()
                        .Where(s => s.Id == id)
                        .Single();

                    supplier.IsDeleted = true;

                    await client.From<Supplier>().Update(supplier);

                    MessageBox.Show("Xóa nhà cung cấp thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadSuppliersAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa nhà cung cấp: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            frmSupplierManagement_Load(sender, e);
        }
    }
}
