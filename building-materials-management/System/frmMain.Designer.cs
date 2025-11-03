namespace building_materials_management.Main
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuMasterData = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSupplierManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCategoryManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMaterialManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUserManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.menuOperation = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStockReceipt = new System.Windows.Forms.ToolStripMenuItem();
            this.menuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStatisticsReport = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPrintReceipt = new System.Windows.Forms.ToolStripMenuItem();
            this.menuClose = new System.Windows.Forms.ToolStripMenuItem();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.chartColumn = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMasterData,
            this.menuOperation,
            this.menuReport,
            this.menuClose});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuMasterData
            // 
            this.menuMasterData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuSupplierManagement,
            this.menuCategoryManagement,
            this.menuMaterialManagement,
            this.menuUserManagement});
            this.menuMasterData.Name = "menuMasterData";
            this.menuMasterData.Size = new System.Drawing.Size(74, 22);
            this.menuMasterData.Text = "Danh mục";
            // 
            // menuSupplierManagement
            // 
            this.menuSupplierManagement.Name = "menuSupplierManagement";
            this.menuSupplierManagement.Size = new System.Drawing.Size(162, 22);
            this.menuSupplierManagement.Text = "Nhà cung cấp";
            this.menuSupplierManagement.Click += new System.EventHandler(this.menuSupplierManagement_Click);
            // 
            // menuCategoryManagement
            // 
            this.menuCategoryManagement.Name = "menuCategoryManagement";
            this.menuCategoryManagement.Size = new System.Drawing.Size(162, 22);
            this.menuCategoryManagement.Text = "Danh mục vật tư";
            this.menuCategoryManagement.Click += new System.EventHandler(this.menuCategoryManagement_Click);
            // 
            // menuMaterialManagement
            // 
            this.menuMaterialManagement.Name = "menuMaterialManagement";
            this.menuMaterialManagement.Size = new System.Drawing.Size(162, 22);
            this.menuMaterialManagement.Text = "Vật tư";
            this.menuMaterialManagement.Click += new System.EventHandler(this.menuMaterialManagement_Click);
            // 
            // menuUserManagement
            // 
            this.menuUserManagement.Name = "menuUserManagement";
            this.menuUserManagement.Size = new System.Drawing.Size(162, 22);
            this.menuUserManagement.Text = "Người dùng";
            this.menuUserManagement.Click += new System.EventHandler(this.menuUserManagement_Click);
            // 
            // menuOperation
            // 
            this.menuOperation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStockReceipt});
            this.menuOperation.Name = "menuOperation";
            this.menuOperation.Size = new System.Drawing.Size(74, 22);
            this.menuOperation.Text = "Nghiệp vụ";
            // 
            // menuStockReceipt
            // 
            this.menuStockReceipt.Name = "menuStockReceipt";
            this.menuStockReceipt.Size = new System.Drawing.Size(157, 22);
            this.menuStockReceipt.Text = "Phiếu nhập kho";
            this.menuStockReceipt.Click += new System.EventHandler(this.menuStockReceipt_Click);
            // 
            // menuReport
            // 
            this.menuReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStatisticsReport,
            this.menuPrintReceipt});
            this.menuReport.Name = "menuReport";
            this.menuReport.Size = new System.Drawing.Size(61, 22);
            this.menuReport.Text = "Báo cáo";
            // 
            // menuStatisticsReport
            // 
            this.menuStatisticsReport.Name = "menuStatisticsReport";
            this.menuStatisticsReport.Size = new System.Drawing.Size(166, 22);
            this.menuStatisticsReport.Text = "Báo cáo thống kê";
            // 
            // menuPrintReceipt
            // 
            this.menuPrintReceipt.Name = "menuPrintReceipt";
            this.menuPrintReceipt.Size = new System.Drawing.Size(166, 22);
            this.menuPrintReceipt.Text = "In hóa đơn ";
            this.menuPrintReceipt.Click += new System.EventHandler(this.menuPrintReceipt_Click);
            // 
            // menuClose
            // 
            this.menuClose.Name = "menuClose";
            this.menuClose.Size = new System.Drawing.Size(50, 22);
            this.menuClose.Text = "Thoát";
            this.menuClose.Click += new System.EventHandler(this.menuClose_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(594, 34);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(52, 13);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome";
            // 
            // chartColumn
            // 
            chartArea1.Name = "ChartArea1";
            this.chartColumn.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartColumn.Legends.Add(legend1);
            this.chartColumn.Location = new System.Drawing.Point(12, 99);
            this.chartColumn.Name = "chartColumn";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartColumn.Series.Add(series1);
            this.chartColumn.Size = new System.Drawing.Size(377, 339);
            this.chartColumn.TabIndex = 2;
            this.chartColumn.Text = "chart1";
            // 
            // chartPie
            // 
            chartArea2.Name = "ChartArea1";
            this.chartPie.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartPie.Legends.Add(legend2);
            this.chartPie.Location = new System.Drawing.Point(411, 99);
            this.chartPie.Name = "chartPie";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartPie.Series.Add(series2);
            this.chartPie.Size = new System.Drawing.Size(377, 339);
            this.chartPie.TabIndex = 3;
            this.chartPie.Text = "chart2";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chartPie);
            this.Controls.Add(this.chartColumn);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuMasterData;
        private System.Windows.Forms.ToolStripMenuItem menuSupplierManagement;
        private System.Windows.Forms.ToolStripMenuItem menuCategoryManagement;
        private System.Windows.Forms.ToolStripMenuItem menuMaterialManagement;
        private System.Windows.Forms.ToolStripMenuItem menuUserManagement;
        private System.Windows.Forms.ToolStripMenuItem menuOperation;
        private System.Windows.Forms.ToolStripMenuItem menuStockReceipt;
        private System.Windows.Forms.ToolStripMenuItem menuReport;
        private System.Windows.Forms.ToolStripMenuItem menuStatisticsReport;
        private System.Windows.Forms.ToolStripMenuItem menuPrintReceipt;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.ToolStripMenuItem menuClose;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartColumn;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPie;
    }
}