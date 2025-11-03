using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using building_materials_management.Classes;
using Excel = Microsoft.Office.Interop.Excel;

namespace building_materials_management.Report
{
    public partial class frmPrintReceipt : Form
    {
        public frmPrintReceipt()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ControlBox = false;
            this.CenterToScreen();
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.Load += frmPrintReceipt_Load;
        }

        private async void frmPrintReceipt_Load(object sender, EventArgs e)
        {
            // Disable all controls except cbbReceipt, btnClose, btnExport
            foreach (Control ctl in this.Controls)
            {
                if (ctl.Name != "cbbReceipt" && ctl.Name != "btnClose" && ctl.Name != "btnExport")
                    ctl.Enabled = false;
            }
            cbbReceipt.Enabled = true;
            btnClose.Enabled = true;
            btnExport.Enabled = true;

            // Clear fields
            txtReceiptId.Text = string.Empty;
            txtUserId.Text = string.Empty;
            txtUserName.Text = string.Empty;
            dtpCreateAt.Value = DateTime.Now;
            txtNote.Text = string.Empty;
            cbbSupplierName.Text = string.Empty;
            txtSupplierEmail.Text = string.Empty;
            txtSupplierPhoneNumber.Text = string.Empty;
            txtSupplierTaxNumber.Text = string.Empty;
            dgvMaterials.DataSource = null;

            // Load all receipt codes to cbbReceipt (but do not auto-load details)
            var receipts = await SupabaseService.Client.From<Receipt>().Get();
            cbbReceipt.DataSource = receipts.Models;
            cbbReceipt.DisplayMember = "MaPhieu";
            cbbReceipt.ValueMember = "Id";
            cbbReceipt.SelectedIndex = -1;

            // Attach SelectionChangeCommitted so it only fires on user selection
            cbbReceipt.SelectionChangeCommitted -= cbbReceipt_SelectionChangeCommitted;
            cbbReceipt.SelectionChangeCommitted += cbbReceipt_SelectionChangeCommitted;
        }

        private async void cbbReceipt_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbbReceipt.SelectedItem == null) return;
            var receipt = (Receipt)cbbReceipt.SelectedItem;
            // Load general info
            txtReceiptId.Text = receipt.MaPhieu;
            dtpCreateAt.Value = receipt.NgayNhap;
            txtUserId.Text = receipt.IdNguoiTao.ToString();
            txtNote.Text = receipt.GhiChu ?? string.Empty;

            try
            {
                // Lấy tên người tạo
                try
                {
                    var userResp = await SupabaseService.Client.From<User>().Where(u => u.Id == receipt.IdNguoiTao).Single();
                    if (userResp != null)
                        txtUserName.Text = userResp.HoTen ?? string.Empty;
                    else
                        txtUserName.Text = string.Empty;
                }
                catch
                {
                    txtUserName.Text = string.Empty;
                }

                long idCuaNCC = receipt.IdNCC;

                // Load supplier info
                var supplierResp = await SupabaseService.Client.From<Supplier>().Where(x => x.Id == idCuaNCC).Single();
                var supplier = supplierResp;
                cbbSupplierName.Text = supplier?.TenNCC ?? string.Empty;
                txtSupplierEmail.Text = supplier?.Email ?? string.Empty;
                txtSupplierPhoneNumber.Text = supplier?.SoDienThoai ?? string.Empty;
                txtSupplierTaxNumber.Text = supplier?.MaSoThue ?? string.Empty;

                long idCuaPhieu = receipt.Id;

                // Load details
                var detailsResp = await SupabaseService.Client.From<ReceiptDetails>().Where(x => x.IdPhieuNhap == idCuaPhieu).Get();
                var details = detailsResp.Models;
                var materialIds = details.Select(x => x.IdVatTu).Distinct().ToList();
                var materialsResp = await SupabaseService.Client.From<Material>().Get();
                var materials = materialsResp.Models.Where(m => materialIds.Contains(m.Id)).ToList();
                dgvMaterials.DataSource = details.Select(d => new
                {
                    MaVatTu = materials.FirstOrDefault(m => m.Id == d.IdVatTu)?.MaVatTu,
                    TenVatTu = materials.FirstOrDefault(m => m.Id == d.IdVatTu)?.TenVatTu,
                    DonViTinh = materials.FirstOrDefault(m => m.Id == d.IdVatTu)?.DonViTinh,
                    SoLuong = d.SoLuong,
                    DonGiaNhap = d.DonGiaNhap,
                    ThanhTien = d.ThanhTien
                }).ToList();
                dgvMaterials.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvMaterials.DataSource == null)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Excel.Application exApp = new Excel.Application();
            Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
            Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];
            exSheet.Name = "Phiếu nhập";

            int row = 1;
            // Title
            exSheet.Cells[row, 1] = "PHIẾU NHẬP KHO";
            ((Excel.Range)exSheet.Cells[row, 1]).Font.Size = 16;
            ((Excel.Range)exSheet.Cells[row, 1]).Font.Bold = true;

            row += 2;
            // Receipt meta
            exSheet.Cells[row, 1] = "Mã phiếu:";
            exSheet.Cells[row, 2] = txtReceiptId.Text;
            exSheet.Cells[row, 4] = "Ngày nhập:";
            exSheet.Cells[row, 5] = dtpCreateAt.Value.ToString("dd/MM/yyyy HH:mm");

            row++;
            exSheet.Cells[row, 1] = "Người tạo:";
            exSheet.Cells[row, 2] = string.IsNullOrWhiteSpace(txtUserName.Text) ? txtUserId.Text : txtUserName.Text + (string.IsNullOrWhiteSpace(txtUserId.Text) ? "" : " (" + txtUserId.Text + ")");

            // calculate total
            decimal total = 0;
            for (int r = 0; r < dgvMaterials.Rows.Count; r++)
            {
                var gridRow = dgvMaterials.Rows[r];
                if (gridRow.IsNewRow) continue;
                // Try find ThanhTien column by header
                object cell = null;
                for (int c = 0; c < dgvMaterials.Columns.Count; c++)
                {
                    var header = dgvMaterials.Columns[c].HeaderText?.Trim().ToLower();
                    if (header == "thanhtien" || header == "thành tiền" || header == "thanh tien")
                    {
                        cell = gridRow.Cells[c].Value;
                        break;
                    }
                }
                // fallback to last column
                if (cell == null && gridRow.Cells.Count > 0) cell = gridRow.Cells[gridRow.Cells.Count - 1].Value;
                if (cell != null)
                {
                    if (decimal.TryParse(cell.ToString(), out decimal v)) total += v;
                }
            }
            exSheet.Cells[row, 4] = "Tổng tiền:";
            exSheet.Cells[row, 5] = total.ToString("N0");

            row += 2;
            // Supplier
            exSheet.Cells[row, 1] = "Nhà cung cấp:";
            exSheet.Cells[row, 2] = cbbSupplierName.Text;
            exSheet.Cells[row, 4] = "Email:";
            exSheet.Cells[row, 5] = txtSupplierEmail.Text;

            row++;
            exSheet.Cells[row, 1] = "Số điện thoại:";
            exSheet.Cells[row, 2] = txtSupplierPhoneNumber.Text;
            exSheet.Cells[row, 4] = "Mã số thuế:";
            exSheet.Cells[row, 5] = txtSupplierTaxNumber.Text;

            row += 2;
            // Note
            exSheet.Cells[row, 1] = "Ghi chú:";
            exSheet.Cells[row, 2] = txtNote.Text;

            row += 2;
            // Table headers
            int headerRow = row;
            for (int c = 0; c < dgvMaterials.Columns.Count; c++)
            {
                exSheet.Cells[headerRow, c + 1] = dgvMaterials.Columns[c].HeaderText;
                ((Excel.Range)exSheet.Cells[headerRow, c + 1]).Font.Bold = true;
                ((Excel.Range)exSheet.Cells[headerRow, c + 1]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
            }

            // Table data
            int dataRow = headerRow + 1;
            for (int r = 0; r < dgvMaterials.Rows.Count; r++)
            {
                var gridRow = dgvMaterials.Rows[r];
                if (gridRow.IsNewRow) continue;
                for (int c = 0; c < gridRow.Cells.Count; c++)
                {
                    exSheet.Cells[dataRow, c + 1] = gridRow.Cells[c].Value;
                }
                dataRow++;
            }

            // Footer (total)
            exSheet.Cells[dataRow + 1, 4] = "Tổng:";
            exSheet.Cells[dataRow + 1, 5] = total.ToString("N0");

            exSheet.Columns.AutoFit();
            exApp.Visible = true;
        }
    }
}
