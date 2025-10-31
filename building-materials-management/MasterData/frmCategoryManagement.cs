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
using Postgrest;
using Excel = Microsoft.Office.Interop.Excel;

namespace building_materials_management.MasterData
{
    public partial class frmCategoryManagement : Form
    {
        private Category currentCategory = null;
        private bool isAddingNew = false;
        public frmCategoryManagement()
        {
            InitializeComponent();
            LoadCategories();
            SetupDataGridView();
            InitializeUIState();
        }
        private void InitializeUIState()
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
            btnThoat.Enabled = true;

            txtMaDM.Enabled = false;
            txtTenDanhMuc.Enabled = false;
            txtMoTa.Enabled = false;
        }
        private async void LoadCategories()
        {
            try
            {
                var categories = await SupabaseService.Client
                    .From<Category>()
                    .Select("*")
                    .Get();
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = categories.Models.OrderByDescending(c => c.CreatedAt).ToList();
                dgvDanhMuc.DataSource = bindingSource;

                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void ClearInputFields()
        {
            txtMaDM.Text = "";
            txtTenDanhMuc.Text = "";
            txtMoTa.Text = "";
            currentCategory = null;
        }

        private void SetupDataGridView()
        {
            dgvDanhMuc.AutoGenerateColumns = false;
            dgvDanhMuc.Columns.Clear();

            dgvDanhMuc.Columns.Add("Id", "Mã Danh Mục");
            dgvDanhMuc.Columns.Add("TenDanhMuc", "Tên Danh Mục");
            dgvDanhMuc.Columns.Add("MoTa", "Mô Tả");

            dgvDanhMuc.Columns["Id"].DataPropertyName = "Id";
            dgvDanhMuc.Columns["TenDanhMuc"].DataPropertyName = "TenDanhMuc";
            dgvDanhMuc.Columns["MoTa"].DataPropertyName = "MoTa";

            dgvDanhMuc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDanhMuc.MultiSelect = false;
        }

        private void frmCategoryManagement_Load(object sender, EventArgs e)
        {
            InitializeUIState();
        }

        private async void btnThem_Click(object sender, EventArgs e)
        {
            isAddingNew = true;
            currentCategory = null;

            txtMaDM.Text = "";
            txtTenDanhMuc.Text = "";
            txtMoTa.Text = "";

            string generatedCode = await GenerateCategoryCodeAsync();
            if (!string.IsNullOrEmpty(generatedCode))
            {
                txtMaDM.Text = generatedCode;
            }

            txtMaDM.Enabled = false;
            txtTenDanhMuc.Enabled = true;
            txtMoTa.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThoat.Enabled = true;

            txtTenDanhMuc.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (currentCategory == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            isAddingNew = false;

            txtMaDM.Enabled = false;
            txtTenDanhMuc.Enabled = true;
            txtMoTa.Enabled = true;

            btnThem.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
            btnThoat.Enabled = true;

            txtTenDanhMuc.Focus();
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (currentCategory == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa danh mục '{currentCategory.TenDanhMuc}' không?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    await SupabaseService.Client
                        .From<Category>()
                        .Where(x => x.Id == currentCategory.Id)
                        .Delete();

                    MessageBox.Show("Xóa danh mục thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCategories();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa danh mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
                return;

            try
            {
                if (isAddingNew)
                {
                    var newCategory = new Category
                    {
                        Id = string.IsNullOrWhiteSpace(txtMaDM.Text) ? 0 : long.Parse(txtMaDM.Text.Trim()),
                        TenDanhMuc = txtTenDanhMuc.Text.Trim(),
                        MoTa = txtMoTa.Text.Trim(),
                        CreatedAt = DateTime.Now
                    };

                    await SupabaseService.Client
                        .From<Category>()
                        .Insert(newCategory);

                    MessageBox.Show("Thêm danh mục thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (currentCategory == null)
                    {
                        MessageBox.Show("Vui lòng chọn danh mục cần sửa trước khi lưu.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var updatedCategory = new Category
                    {
                        Id = currentCategory.Id,
                        TenDanhMuc = txtTenDanhMuc.Text.Trim(),
                        MoTa = txtMoTa.Text.Trim(),
                        CreatedAt = currentCategory.CreatedAt
                    };

                    await SupabaseService.Client
                        .From<Category>()
                        .Update(updatedCategory);

                    MessageBox.Show("Cập nhật danh mục thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                LoadCategories();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu danh mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            InitializeUIState();
            isAddingNew = false;
        }

        private async void btnTimKiem_Click(object sender, EventArgs e)
        {
            string searchTerm = txtTimKiem.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                LoadCategories();
                return;
            }

            try
            {
                var categories = await SupabaseService.Client
                    .From<Category>()
                    .Select("*")
                    .Get();

                var filtered = categories.Models
                    .Where(c => c.TenDanhMuc.ToLower().Contains(searchTerm))
                    .OrderByDescending(c => c.CreatedAt)
                    .ToList();

                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = filtered;
                dgvDanhMuc.DataSource = bindingSource;

                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtTenDanhMuc.Text))
            {
                MessageBox.Show("Vui lòng nhập tên danh mục.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDanhMuc.Focus();
                return false;
            }

            if (txtTenDanhMuc.Text.Trim().Length > 100)
            {
                MessageBox.Show("Tên danh mục không được vượt quá 100 ký tự.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenDanhMuc.Focus();
                return false;
            }

            if (txtMoTa.Text.Trim().Length > 500)
            {
                MessageBox.Show("Mô tả không được vượt quá 500 ký tự.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMoTa.Focus();
                return false;
            }

            return true;
        }

        private async Task<string> GenerateCategoryCodeAsync()
        {
            try
            {
                var categories = await SupabaseService.Client
                    .From<Category>()
                    .Select("*")
                    .Get();

                long maxId = categories.Models.Count > 0
                    ? categories.Models.Max(c => c.Id)
                    : 0;

                long newId = maxId + 1;

                return newId.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi sinh mã danh mục: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void dgvDanhMuc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDanhMuc.Rows.Count)
            {
                DataGridViewRow row = dgvDanhMuc.Rows[e.RowIndex];

                currentCategory = new Category
                {
                    Id = (long)row.Cells["Id"].Value,
                    TenDanhMuc = row.Cells["TenDanhMuc"].Value?.ToString() ?? "",
                    MoTa = row.Cells["MoTa"].Value?.ToString() ?? ""
                };

                txtMaDM.Text = currentCategory.Id.ToString();
                txtTenDanhMuc.Text = currentCategory.TenDanhMuc;
                txtMoTa.Text = currentCategory.MoTa;

                txtMaDM.Enabled = false;
                txtTenDanhMuc.Enabled = false;
                txtMoTa.Enabled = false;

                btnThem.Enabled = false;
                btnSua.Enabled = true;
                btnXoa.Enabled = true;
                btnLuu.Enabled = false;
                btnHuy.Enabled = true;
                btnThoat.Enabled = true;

                isAddingNew = false;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exMaterials = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exMaterials.Worksheets[1];
            Excel.Range tenTruong = (Excel.Range)exSheet.Cells[1, 1]; 

            tenTruong.Range["B2"].Font.Size = 25;
            tenTruong.Range["B2"].Font.Name = "Times New Roman";
            tenTruong.Range["B2"].Font.Color = Color.Red;
            tenTruong.Range["B2"].Value = "DANH SÁCH DANH MỤC VẬT TƯ";

            tenTruong.Range["A4:F4"].Font.Size = 13;
            tenTruong.Range["A4:F4"].Font.Name = "Times New Roman";
            //tenTruong.Range["B2"].Font.Color = Color.Black;
            tenTruong.Range["A4:F4"].Font.Bold = true;
            tenTruong.Range["A4"].Value = "Mã danh mục vật tư";
            tenTruong.Range["B4"].Value = "Tên danh mục";
            tenTruong.Range["C4"].Value = "Mô tả";

            int hang = 5;
            for (int i = 0; i < dgvDanhMuc.Rows.Count - 1; i++)
            {
                tenTruong.Range["A" + hang.ToString()].Value = dgvDanhMuc.Rows[i].Cells[0].Value.ToString();
                tenTruong.Range["B" + hang.ToString()].Value = dgvDanhMuc.Rows[i].Cells[1].Value.ToString();
                tenTruong.Range["C" + hang.ToString()].Value = dgvDanhMuc.Rows[i].Cells[2].Value.ToString();
                hang++;
            }
            exSheet.Name = "Danh sách danh mục vật tư";

            exMaterials.Activate();

            SaveFileDialog dlFile = new SaveFileDialog();
            if (dlFile.ShowDialog() == DialogResult.OK)
            {
                exMaterials.SaveAs(dlFile.FileName.ToString());
            }

            exApp.Quit();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
