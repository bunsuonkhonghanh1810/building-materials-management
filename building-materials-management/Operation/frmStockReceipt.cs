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
using Supabase;

namespace building_materials_management.Operation
{
    public partial class frmStockReceipt : Form
    {
        private List<ChiTietNhapKho> receiptDetails = new List<ChiTietNhapKho>();
        private int? editingIndex = null; // null = adding new, otherwise index of editing item
        public frmStockReceipt()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.CenterToScreen();

            this.Load += frmStockReceipt_Load;  
        }

        private async void frmStockReceipt_Load(object sender, EventArgs e)
        {
            dgvMaterials.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            txtReceiptId.Enabled = false;
            dtpCreateAt.Enabled = false;
            txtUserId.Enabled = false;
            txtUserName.Enabled = false;
            txtSupplierEmail.Enabled = false;
            txtSupplierPhoneNumber.Enabled = false;
            txtSupplierTaxNumber.Enabled = false;

            cbbMaterialId.Enabled = false;
            cbbMaterialName.Enabled = false;
            txtMaterialQuantity.Enabled = false;
            txtMaterialPrice.Enabled = false;
            txtMaterialTotal.Enabled = false;
            lblMaterialUnit.Text = string.Empty;

            var receipts = await SupabaseService.Client.From<Receipt>().Get();
            int count = receipts.Models.Count();
            int nextNumber = count + 1;
            string maPhieu = $"PNK{nextNumber:D3}";
            txtReceiptId.Text = maPhieu;

            dtpCreateAt.Value = DateTime.Now;

            txtUserId.Text = GlobalState.CurrentUserId.ToString();
            txtUserName.Text = GlobalState.CurrentUserName;

            try
            {
                var suppliersResp = await SupabaseService.Client.From<Supplier>()
                                                                .Where(x => x.IsDeleted == false)
                                                                .Get();
                cbbSupplierName.DataSource = suppliersResp.Models;
                cbbSupplierName.DisplayMember = "TenNCC";

                cbbSupplierName.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhà cung cấp: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var materialsResp = await SupabaseService.Client.From<Material>()
                                                                .Where(x => x.IsDeleted == false)
                                                                .Get();
                cbbMaterialId.DataSource = materialsResp.Models;
                cbbMaterialId.DisplayMember = "MaVatTu";
                cbbMaterialId.SelectedIndex = -1;

                cbbMaterialName.DataSource = materialsResp.Models.ToList(); // <-- Thêm .ToList()

                cbbMaterialName.DisplayMember = "TenVatTu";
                cbbMaterialName.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách vật tư: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cbbSupplierName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSupplierName.SelectedItem != null)
            {
                Supplier selectedSupplier = (Supplier)cbbSupplierName.SelectedItem;

                txtSupplierEmail.Text = selectedSupplier.Email;
                txtSupplierPhoneNumber.Text = selectedSupplier.SoDienThoai;
                txtSupplierTaxNumber.Text = selectedSupplier.MaSoThue;
            }
            else
            {
                txtSupplierEmail.Text = string.Empty;
                txtSupplierPhoneNumber.Text = string.Empty;
                txtSupplierTaxNumber.Text = string.Empty;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            if (btnAddMaterial.Text == "Thêm vật tư")
            {
                // start adding new
                editingIndex = null;
                cbbMaterialId.Enabled = true;
                cbbMaterialName.Enabled = true;
                txtMaterialQuantity.Enabled = true;
                txtMaterialPrice.Enabled = true;
                btnAddMaterial.Text = "Lưu vật tư";
            }
            else 
            {
                if (cbbMaterialId.SelectedItem == null || cbbMaterialName.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn vật tư.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int quantity = 0;
                decimal price = 0;
                if (!int.TryParse(txtMaterialQuantity.Text, out quantity) || quantity <= 0)
                {
                    MessageBox.Show("Số lượng phải là số > 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!decimal.TryParse(txtMaterialPrice.Text, out price) || price <= 0)
                {
                    MessageBox.Show("Đơn giá phải là số > 0.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Material selectedMaterial = (Material)cbbMaterialId.SelectedItem;

                // If editing existing item
                if (editingIndex.HasValue)
                {
                    // check duplicate except current editing index
                    if (IsMaterialExistsExceptIndex(selectedMaterial.Id, editingIndex))
                    {
                        MessageBox.Show("Vật tư đã có trong danh sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    var existing = receiptDetails[editingIndex.Value];
                    existing.IdVatTu = selectedMaterial.Id;
                    existing.SoLuong = quantity;
                    existing.DonGiaNhap = price;
                    existing.ThanhTien = quantity * price;

                    UpdateReceiptDetailsGrid();

                    // reset editing state
                    editingIndex = null;
                }
                else
                {
                    // adding new
                    if (receiptDetails.Any(x => x.IdVatTu == selectedMaterial.Id))
                    {
                        MessageBox.Show("Vật tư đã có trong danh sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    var detail = new ChiTietNhapKho
                    {
                        IdVatTu = selectedMaterial.Id,
                        SoLuong = quantity,
                        DonGiaNhap = price,
                        ThanhTien = quantity * price
                    };
                    receiptDetails.Add(detail);
                    UpdateReceiptDetailsGrid();
                }
                // Reset input fields and UI
                ClearMaterialInputFields();
                btnAddMaterial.Text = "Thêm vật tư";
                cbbMaterialId.Enabled = false;
                cbbMaterialName.Enabled = false;
                txtMaterialQuantity.Enabled = false;
                txtMaterialPrice.Enabled = false;
            }
        }

        // Sửa lại để dùng dgvMaterials thay vì tạo mới dgvReceiptDetails
        private List<Material> GetMaterialListFromDataSource(object dataSource)
        {
            if (dataSource is List<Material> list) return list;
            if (dataSource is BindingList<Material> blist) return blist.ToList();
            return new List<Material>();
        }

        private void dgvMaterials_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                editingIndex = e.RowIndex; // mark editing index
                var detail = receiptDetails[e.RowIndex];
                var materialList = GetMaterialListFromDataSource(cbbMaterialId.DataSource);
                var material = materialList.FirstOrDefault(m => m.Id == detail.IdVatTu);
                cbbMaterialId.SelectedItem = material;
                cbbMaterialName.SelectedItem = material;
                txtMaterialQuantity.Text = detail.SoLuong?.ToString();
                txtMaterialPrice.Text = detail.DonGiaNhap?.ToString();
                txtMaterialTotal.Text = detail.ThanhTien?.ToString("N0");
                lblMaterialUnit.Text = material?.DonViTinh ?? "";
                btnAddMaterial.Text = "Lưu vật tư";
                cbbMaterialId.Enabled = true;
                cbbMaterialName.Enabled = true;
                txtMaterialQuantity.Enabled = true;
                txtMaterialPrice.Enabled = true;
            }
        }

        private void UpdateReceiptDetailsGrid()
        {
            var materialList = GetMaterialListFromDataSource(cbbMaterialId.DataSource);
            dgvMaterials.DataSource = null;
            dgvMaterials.DataSource = receiptDetails.Select(x => new
            {
                MaVatTu = materialList.FirstOrDefault(m => m.Id == x.IdVatTu)?.MaVatTu,
                TenVatTu = materialList.FirstOrDefault(m => m.Id == x.IdVatTu)?.TenVatTu,
                SoLuong = x.SoLuong,
                DonGiaNhap = x.DonGiaNhap,
                ThanhTien = x.ThanhTien
            }).ToList();
        }

        private bool IsMaterialExistsExceptIndex(long materialId, int? exceptIndex)
        {
            for (int i = 0; i < receiptDetails.Count; i++)
            {
                if (receiptDetails[i].IdVatTu == materialId && (!exceptIndex.HasValue || i != exceptIndex.Value))
                    return true;
            }
            return false;
        }

        private void cbbMaterialId_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMaterialId.SelectedItem != null)
            {
                Material selectedMaterial = (Material)cbbMaterialId.SelectedItem;
                cbbMaterialName.SelectedItem = selectedMaterial;
                lblMaterialUnit.Text = selectedMaterial.DonViTinh;
                // Kiểm tra trùng vật tư trong dgv
                if (IsMaterialExistsExceptIndex(selectedMaterial.Id, editingIndex))
                {
                    MessageBox.Show("Vật tư đã có trong danh sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbbMaterialId.SelectedIndex = -1;
                    cbbMaterialName.SelectedIndex = -1;
                    lblMaterialUnit.Text = string.Empty;
                }
            }
            else
            {
                cbbMaterialName.SelectedIndex = -1;
                lblMaterialUnit.Text = string.Empty;
            }
        }

        private void cbbMaterialName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbMaterialName.SelectedItem != null)
            {
                Material selectedMaterial = (Material)cbbMaterialName.SelectedItem;
                cbbMaterialId.SelectedItem = selectedMaterial;
                lblMaterialUnit.Text = selectedMaterial.DonViTinh;
                // Kiểm tra trùng vật tư trong dgv
                if (IsMaterialExistsExceptIndex(selectedMaterial.Id, editingIndex))
                {
                    MessageBox.Show("Vật tư đã có trong danh sách.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbbMaterialId.SelectedIndex = -1;
                    cbbMaterialName.SelectedIndex = -1;
                    lblMaterialUnit.Text = string.Empty;
                }
            }
            else
            {
                cbbMaterialId.SelectedIndex = -1;
                lblMaterialUnit.Text = string.Empty;
            }
        }

        private async void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate
                if (cbbSupplierName.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (receiptDetails.Count == 0)
                {
                    MessageBox.Show("Danh sách vật tư rỗng. Vui lòng thêm vật tư trước khi lưu hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var supplier = (Supplier)cbbSupplierName.SelectedItem;

                // Tạo object Receipt
                var receipt = new Receipt
                {
                    MaPhieu = txtReceiptId.Text.Trim(),
                    IdNCC = supplier.Id,
                    IdNguoiTao = GlobalState.CurrentUserId,
                    NgayNhap = dtpCreateAt.Value,
                    TongTien = receiptDetails.Sum(x => x.ThanhTien ?? 0),
                    TrangThai = "moi",
                    GhiChu = txtNote.Text?.Trim(),
                    CreatedAt = DateTime.Now,
                    IsDeleted = false
                };

                // Insert receipt
                var resp = await SupabaseService.Client.From<Receipt>().Insert(receipt);
                var inserted = resp.Models.FirstOrDefault();
                if (inserted == null)
                {
                    MessageBox.Show("Không thể lưu phiếu nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                long insertedId = inserted.Id;

                // Prepare details with IdPhieuNhap
                foreach (var d in receiptDetails)
                {
                    d.IdPhieuNhap = insertedId;
                    d.IsDeleted = false;
                }

                // Insert details in batch
                await SupabaseService.Client.From<ChiTietNhapKho>().Insert(receiptDetails);

                // Update material stock for each detail
                var materialList = GetMaterialListFromDataSource(cbbMaterialId.DataSource);
                foreach (var d in receiptDetails)
                {
                    if (!d.IdVatTu.HasValue) continue;
                    var mat = materialList.FirstOrDefault(m => m.Id == d.IdVatTu.Value);
                    if (mat != null)
                    {
                        int newTonKho = mat.TonKho + (d.SoLuong ?? 0);
                        await SupabaseService.Client.From<Material>().Where(x => x.Id == mat.Id).Set(x => x.TonKho, newTonKho).Update();
                    }
                }

                MessageBox.Show("Lưu phiếu nhập thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset form for next receipt
                receiptDetails.Clear();
                UpdateReceiptDetailsGrid();
                ClearMaterialInputFields();
                btnAddMaterial.Text = "Thêm vật tư";
                cbbMaterialId.Enabled = false;
                cbbMaterialName.Enabled = false;
                txtMaterialQuantity.Enabled = false;
                txtMaterialPrice.Enabled = false;
                editingIndex = null;

                // generate new MaPhieu
                var receiptsAll = await SupabaseService.Client.From<Receipt>().Get();
                int countAll = receiptsAll.Models.Count();
                int nextNum = countAll + 1;
                txtReceiptId.Text = $"PNK{nextNum:D3}";
                txtNote.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lưu phiếu nhập: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtMaterialQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMaterialPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtMaterialQuantity_TextChanged(object sender, EventArgs e)
        {
            UpdateMaterialTotal();
        }

        private void txtMaterialPrice_TextChanged(object sender, EventArgs e)
        {
            UpdateMaterialTotal();
        }

        private void UpdateMaterialTotal()
        {
            int quantity = 0;
            decimal price = 0;
            int.TryParse(txtMaterialQuantity.Text, out quantity);
            decimal.TryParse(txtMaterialPrice.Text, out price);
            txtMaterialTotal.Text = (quantity * price).ToString("N0");
        }

        private void btnCancelMaterial_Click(object sender, EventArgs e)
        {
            ClearMaterialInputFields();
            btnAddMaterial.Text = "Thêm vật tư";
            cbbMaterialId.Enabled = false;
            cbbMaterialName.Enabled = false;
            txtMaterialQuantity.Enabled = false;
            txtMaterialPrice.Enabled = false;
            editingIndex = null;
        }

        private void ClearMaterialInputFields()
        {
            cbbMaterialId.SelectedIndex = -1;
            cbbMaterialName.SelectedIndex = -1;
            txtMaterialQuantity.Text = string.Empty;
            txtMaterialPrice.Text = string.Empty;
            txtMaterialTotal.Text = string.Empty;
            lblMaterialUnit.Text = string.Empty;
            editingIndex = null;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            txtMaterialQuantity.KeyPress += txtMaterialQuantity_KeyPress;
            txtMaterialPrice.KeyPress += txtMaterialPrice_KeyPress;
            txtMaterialQuantity.TextChanged += txtMaterialQuantity_TextChanged;
            txtMaterialPrice.TextChanged += txtMaterialPrice_TextChanged;
            dgvMaterials.CellClick += dgvMaterials_CellClick;
        }

        private void btnDeleteMaterial_Click_1(object sender, EventArgs e)
        {
            if (dgvMaterials.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn vật tư muốn xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int rowIndex = dgvMaterials.CurrentRow.Index;
            if (rowIndex < 0 || rowIndex >= receiptDetails.Count)
            {
                MessageBox.Show("Chỉ mục không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa vật tư này khỏi danh sách?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                receiptDetails.RemoveAt(rowIndex);
                UpdateReceiptDetailsGrid();
                ClearMaterialInputFields();
                btnAddMaterial.Text = "Thêm vật tư";
            }
        }
    }
}
