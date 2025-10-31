using building_materials_management.Classes;
using ImageMagick;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Supabase.Postgrest.Constants;

namespace building_materials_management.MasterData
{
    public partial class frmMaterialManagement : Form
    {
        Function ft = new Function();
        string fileAnh = "";

        private enum FormMode { View, Add, Edit }
        private FormMode currentMode = FormMode.View;
        private bool isRowSelected = false;

        public frmMaterialManagement()
        {
            InitializeComponent();
        }

        // ✅ Form Load
        private async void frmMaterialManagement_Load(object sender, EventArgs e)
        {
            await OInit();
            SetFormState(FormMode.View);
        }

        // ✅ Load dữ liệu
        private async Task OInit()
        {
            try
            {
                ClearInputFields();

                var materials = (await SupabaseService.Client
                    .From<Material>()
                    .Select("*, danhmucvattu(ten_danh_muc)")
                    .Filter("is_deleted", Operator.Equals, "false")
                    .Order(x => x.Id, Ordering.Ascending)
                    .Get()).Models;

                var flat = materials.Select(m => new
                {
                    m.Id,
                    m.MaVatTu,
                    m.TenVatTu,
                    m.DonViTinh,
                    m.TonKho,
                    m.LinkAnh,
                    TenDanhMuc = m.Categories?.TenDanhMuc
                }).ToList();

                dgvMaterials.DataSource = flat;

                // Ẩn cột không cần hiển thị
                if (dgvMaterials.Columns["LinkAnh"] != null)
                    dgvMaterials.Columns["LinkAnh"].Visible = false;
                if (dgvMaterials.Columns["Id"] != null)
                    dgvMaterials.Columns["Id"].Visible = false;

                // Load danh mục
                var categories = (await SupabaseService.Client
                    .From<Category>()
                    .Filter("is_deleted", Operator.Equals, "false")
                    .Get()).Models;

                ft.FillCombox(cbbdanhmuc,
                    categories.Select(c => new { c.Id, c.TenDanhMuc }).ToList(),
                    "TenDanhMuc", "Id");

                // Load đơn vị tính
                ft.FillCombox(cbbdonvitinh,
                    materials.Select(m => new { m.DonViTinh }).Distinct().ToList(),
                    "DonViTinh", "DonViTinh");

                dgvMaterials.ClearSelection();
                isRowSelected = false;
                SetFormState(FormMode.View);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ Xóa nội dung control
        private void ClearInputFields(Control parent = null)
        {
            if (parent == null)
                parent = this;

            foreach (Control control in parent.Controls)
            {
                if (control is TextBox txt)
                    txt.Clear();
                else if (control is ComboBox cb)
                {
                    cb.SelectedIndex = -1;
                    cb.Text = "";
                }
                else if (control is PictureBox pic)
                    pic.Image = null;

                if (control.HasChildren)
                    ClearInputFields(control);
            }
        }

        // ✅ Bật/tắt điều khiển
        private void SetFormState(FormMode mode)
        {
            currentMode = mode;
            bool editable = (mode == FormMode.Add || mode == FormMode.Edit);

            foreach (Control ctl in this.Controls)
            {
                if (ctl is TextBox txt)
                    txt.ReadOnly = !editable;
                else if (ctl is ComboBox cb)
                    cb.Enabled = editable;
            }

            // dgv luôn xem được, nhưng không cho click khi đang thêm/sửa
            dgvMaterials.Enabled = true;

            btnThemMoi.Enabled = (mode == FormMode.View);
            btnSua.Enabled = (mode == FormMode.View && isRowSelected);
            btnXoa.Enabled = (mode == FormMode.View && isRowSelected);
            btnLuu.Enabled = editable;
            btnBoQua.Enabled = editable;
            btnAnh.Enabled = editable;
        }

        // ✅ Khi click dgv
        private void dgvMaterials_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nếu đang thêm hoặc sửa thì không cho click chọn dòng khác
            if (currentMode == FormMode.Add || currentMode == FormMode.Edit)
            {
                MessageBox.Show("Đang trong chế độ thêm hoặc sửa. Vui lòng lưu hoặc hủy trước khi chọn vật tư khác!",
                                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (e.RowIndex < 0) return;

            try
            {
                var row = dgvMaterials.Rows[e.RowIndex];
                txtmavattu.Text = row.Cells["MaVatTu"].Value?.ToString();
                txttenvattu.Text = row.Cells["TenVatTu"].Value?.ToString();
                txttonkho.Text = row.Cells["TonKho"].Value?.ToString();
                cbbdonvitinh.Text = row.Cells["DonViTinh"].Value?.ToString();
                cbbdanhmuc.Text = row.Cells["TenDanhMuc"].Value?.ToString();
                fileAnh = row.Cells["LinkAnh"].Value?.ToString();

                ShowImageFromLocal(fileAnh);

                isRowSelected = true;
                SetFormState(FormMode.View);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi hiển thị vật tư: " + ex.Message);
            }
        }

        // ✅ Nút thêm mới
        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            ClearInputFields();
            fileAnh = "";
            isRowSelected = false;
            SetFormState(FormMode.Add);
        }

        // ✅ Nút sửa
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!isRowSelected || dgvMaterials.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn vật tư cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SetFormState(FormMode.Edit);
        }

        // ✅ Nút bỏ qua
        private async void btnBoQua_Click(object sender, EventArgs e)
        {
            await OInit();
            isRowSelected = false;
            SetFormState(FormMode.View);
        }

        // ✅ Xóa mềm
        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (!isRowSelected || dgvMaterials.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn vật tư cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var id = Convert.ToInt64(dgvMaterials.CurrentRow.Cells["Id"].Value);
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa vật tư này?",
                                          "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                await SupabaseService.Client
                    .From<Material>()
                    .Where(x => x.Id == id)
                    .Set(x => x.IsDeleted, true)
                    .Update();

                MessageBox.Show("Đã chuyển vật tư sang trạng thái xóa.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await OInit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa vật tư: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ✅ Chọn ảnh
        private void btnAnh_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Tất cả ảnh|*.png;*.jpg;*.jpeg;*.webp;*.bmp";
                dlg.Title = "Chọn ảnh vật tư";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    string src = dlg.FileName;
                    string folder = Path.Combine(Application.StartupPath, "Images", "Vattu");
                    Directory.CreateDirectory(folder);

                    string dest = Path.Combine(folder, Path.GetFileNameWithoutExtension(src) + ".png");
                    try
                    {
                        using (var img = new MagickImage(src))
                        {
                            img.Format = MagickFormat.Png;
                            img.Write(dest);
                        }

                        fileAnh = Path.Combine("Images", "Vattu", Path.GetFileName(dest)).Replace("\\", "/");
                        ShowImageFromLocal(fileAnh);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Không thể lưu ảnh: " + ex.Message);
                    }
                }
            }
        }

        // ✅ Hiển thị ảnh từ local
        private void ShowImageFromLocal(string relativePath)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(relativePath))
                {
                    picAnh.Image = null;
                    return;
                }

                string full = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
                if (!File.Exists(full))
                {
                    picAnh.Image = null;
                    return;
                }

                using (var fs = new FileStream(full, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (var img = Image.FromStream(fs))
                {
                    picAnh.Image = new Bitmap(img);
                }
            }
            catch
            {
                picAnh.Image = null;
            }
        }

        // ✅ Lưu dữ liệu
        private async void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string maVatTu = txtmavattu.Text.Trim();
                string tenVatTu = txttenvattu.Text.Trim();
                string donViTinh = cbbdonvitinh.Text.Trim();
                string tonKhoText = txttonkho.Text.Trim();

                if (string.IsNullOrWhiteSpace(maVatTu) ||
                    string.IsNullOrWhiteSpace(tenVatTu) ||
                    string.IsNullOrWhiteSpace(donViTinh) ||
                    string.IsNullOrWhiteSpace(tonKhoText) ||
                    cbbdanhmuc.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(tonKhoText, out int tonKho))
                {
                    MessageBox.Show("Tồn kho phải là số!", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                long idDanhMuc = Convert.ToInt64(cbbdanhmuc.SelectedValue);

                if (currentMode == FormMode.Add)
                {
                    // ✅ Kiểm tra trùng mã vật tư
                    var existing = (await SupabaseService.Client
                        .From<Material>()
                        .Filter("ma_vat_tu", Operator.Equals, maVatTu)
                        .Filter("is_deleted", Operator.Equals, "false")
                        .Get()).Models.FirstOrDefault();

                    if (existing != null)
                    {
                        MessageBox.Show("Mã vật tư đã tồn tại!", "Lỗi trùng mã", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var newMat = new Material
                    {
                        MaVatTu = maVatTu,
                        TenVatTu = tenVatTu,
                        DonViTinh = donViTinh,
                        TonKho = tonKho,
                        LinkAnh = fileAnh,
                        IdDanhMuc = idDanhMuc,
                        IsDeleted = false
                    };

                    await SupabaseService.Client.From<Material>().Insert(newMat);
                    MessageBox.Show("Thêm vật tư thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (currentMode == FormMode.Edit)
                {
                    if (dgvMaterials.CurrentRow == null)
                    {
                        MessageBox.Show("Vui lòng chọn dòng để sửa!");
                        return;
                    }

                    long id = Convert.ToInt64(dgvMaterials.CurrentRow.Cells["Id"].Value);

                    await SupabaseService.Client
                        .From<Material>()
                        .Where(x => x.Id == id)
                        .Set(x => x.TenVatTu, tenVatTu)
                        .Set(x => x.DonViTinh, donViTinh)
                        .Set(x => x.TonKho, tonKho)
                        .Set(x => x.LinkAnh, fileAnh)
                        .Set(x => x.IdDanhMuc, idDanhMuc)
                        .Update();

                    MessageBox.Show("Cập nhật vật tư thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await OInit();
                SetFormState(FormMode.View);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu vật tư: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
