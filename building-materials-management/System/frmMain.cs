using building_materials_management.Classes;
using building_materials_management.MasterData;
using building_materials_management.Operation;
using building_materials_management.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace building_materials_management.Main
 
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.ControlBox = false;
            this.CenterToScreen();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Chào, {GlobalState.CurrentUserName}";

            menuMasterData.Visible = false;
            menuOperation.Visible = false;
            menuReport.Visible = false;

            if (GlobalState.CurrentUserRole == "admin")
            {
                menuMasterData.Visible = true;
                menuOperation.Visible = true;
                menuReport.Visible = true;
            }
            else if (GlobalState.CurrentUserRole == "quan_ly")
            {
                menuMasterData.Visible = true;
                menuUserManagement.Visible = false;
                menuOperation.Visible = true;
                menuReport.Visible = true;
            }
            else if (GlobalState.CurrentUserRole == "nhan_vien")
            {
                menuMasterData.Visible = true;
                menuUserManagement.Visible = false;
                menuCategoryManagement.Visible = false;
                menuOperation.Visible = true;
            }

            await VeBieuDoCotNCC();
            await VeBieuDoTronVatTu();
        }

        private async Task VeBieuDoTronVatTu()
        {
            // 1. XÓA DỮ LIỆU CŨ
            chartPie.Series.Clear();
            chartPie.Titles.Clear();
            chartPie.Legends.Clear();
            chartPie.Titles.Add("Top 5 Vật tư nhập nhiều nhất (theo số lượng)");

            // 2. KÍCH HOẠT 3D (Làm đẹp)
            chartPie.ChartAreas[0].Area3DStyle.Enable3D = true;
            chartPie.ChartAreas[0].Area3DStyle.Inclination = 15; // Hơi nghiêng

            // 3. DÙNG BẢNG MÀU (Làm đẹp)
            chartPie.Palette = ChartColorPalette.BrightPastel; // (Thử màu này)

            // 4. TẠO SERIES
            Series pieSeries = new Series("SoLuongVatTu");
            pieSeries.ChartType = SeriesChartType.Pie; // <-- Kiểu Pie

            // 5. THÊM VIỀN VÀ HIỆU ỨNG (Làm đẹp)
            pieSeries.BorderColor = Color.Black;
            pieSeries.BorderWidth = 1;
            pieSeries["PieDrawingStyle"] = "Concave"; // Hiệu ứng 3D (lõm/nổi)

            try
            {
                // 6. LẤY DỮ LIỆU (Code của bạn)
                var response = await SupabaseService.Client.From<ReceiptDetails>()
                    .Select("so_luong, vattu(ten_vat_tu)")
                    .Get();
                var allDetails = response.Models;

                // 7. XỬ LÝ LINQ (Code của bạn)
                var groupedData = allDetails
                    .Where(d => d.VatTu != null) // Lọc ra các vật tư không null
                    .GroupBy(d => d.VatTu.TenVatTu)
                    .Select(group => new
                    {
                        TenVatTu = group.Key,
                        TongSoLuong = group.Sum(d => d.SoLuong)
                    })
                    .OrderByDescending(x => x.TongSoLuong)
                    .Take(5)
                    .ToList();

                // 8. VẼ LÊN BIỂU ĐỒ
                foreach (var item in groupedData)
                {
                    pieSeries.Points.AddXY(item.TenVatTu, item.TongSoLuong);
                }

                // 9. CÀI ĐẶT HIỂN THỊ
                pieSeries.IsValueShownAsLabel = true;
                pieSeries.Label = "#PERCENT{P0}"; // Chỉ hiển thị %

                // Thêm Chú thích (Legend)
                pieSeries.LegendText = "#VALX"; // Chú thích sẽ là Tên Vật tư
                chartPie.Legends.Add(new Legend("DefaultLegend"));
                chartPie.Legends["DefaultLegend"].Docking = Docking.Bottom;

                // 10. THÊM SERIES VÀO CHART
                chartPie.Series.Add(pieSeries);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu biểu đồ tròn: " + ex.Message);
            }
        }

        private async Task VeBieuDoCotNCC()
        {
            // 1. XÓA DỮ LIỆU CŨ
            chartColumn.Series.Clear();
            chartColumn.Titles.Clear();
            chartColumn.Legends.Clear(); // <-- Ẩn chú thích
            chartColumn.Titles.Add("Top 5 NCC có tổng tiền nhập cao nhất");

            // 2. KÍCH HOẠT 3D (Làm đẹp)
            chartColumn.ChartAreas[0].Area3DStyle.Enable3D = true;
            chartColumn.ChartAreas[0].Area3DStyle.Rotation = 10; // Hơi nghiêng 1 chút

            // 3. DÙNG BẢNG MÀU ĐẸP (Làm đẹp)
            // (Excel, Light, Pastel, SeaGreen, BrightPastel...)
            chartColumn.Palette = ChartColorPalette.Excel;

            // 4. ĐỊNH DẠNG TRỤC Y (Làm đẹp)
            // Thêm dấu phẩy (,) vào các số lớn
            chartColumn.ChartAreas[0].AxisY.LabelStyle.Format = "N0";

            // 5. TẠO SERIES
            Series columnSeries = new Series("TongTienNhap");
            columnSeries.ChartType = SeriesChartType.Column;
            columnSeries.IsValueShownAsLabel = true; // Hiển thị số trên đỉnh cột
            columnSeries.LabelFormat = "N0";

            try
            {
                // 6. LẤY DỮ LIỆU (Code của bạn)
                var response = await SupabaseService.Client.From<Receipt>()
                    .Select("tong_tien, nhacungcap(ten_ncc)")
                    .Get();

                var allReceipts = response.Models;

                // 7. XỬ LÝ LINQ (Code của bạn)
                var groupedData = allReceipts
                    .Where(p => p.NhaCungCap != null) // Lọc ra các NCC không bị null
                    .GroupBy(p => p.NhaCungCap.TenNCC)
                    .Select(group => new
                    {
                        TenNCC = group.Key,
                        TongTien = group.Sum(p => p.TongTien)
                    })
                    .OrderByDescending(x => x.TongTien)
                    .Take(5)
                    .ToList();

                // 8. VẼ LÊN BIỂU ĐỒ
                foreach (var item in groupedData)
                {
                    columnSeries.Points.AddXY(item.TenNCC, item.TongTien);
                }

                // 9. THÊM SERIES VÀO CHART
                chartColumn.Series.Add(columnSeries);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu biểu đồ cột: " + ex.Message);
            }
        }

        private void menuClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuMaterialManagement_Click(object sender, EventArgs e)
        {
            this.Hide();

            Form frmMater = new MasterData.frmMaterialManagement();
            frmMater.ShowDialog();

            this.Show();
        }
        private void menuSupplierManagement_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmSupplierManagement formSupplierManagement = new frmSupplierManagement();
            formSupplierManagement.ShowDialog();

            this.Show();
        }
        private void menuCategoryManagement_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmCategoryManagement frm = new frmCategoryManagement();
            frm.ShowDialog();

            this.Show(); 
        }

        private void menuUserManagement_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmUserManagement formUserManagement = new frmUserManagement();
            formUserManagement.ShowDialog();
            
            this.Show();
        }

        private void menuStockReceipt_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmStockReceipt formStockReceipt = new frmStockReceipt();
            formStockReceipt.ShowDialog();

            this.Show();
        }

        private void menuPrintReceipt_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmPrintReceipt formPrintReceipt = new frmPrintReceipt();
            formPrintReceipt.ShowDialog();
            this.Show();
        }
    }
}
