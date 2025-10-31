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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuMasterData,
            this.menuOperation,
            this.menuReport,
            this.menuClose});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1600, 46);
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
            this.menuMasterData.Size = new System.Drawing.Size(144, 38);
            this.menuMasterData.Text = "Danh mục";
            // 
            // menuSupplierManagement
            // 
            this.menuSupplierManagement.Name = "menuSupplierManagement";
            this.menuSupplierManagement.Size = new System.Drawing.Size(359, 44);
            this.menuSupplierManagement.Text = "Nhà cung cấp";
            this.menuSupplierManagement.Click += new System.EventHandler(this.menuSupplierManagement_Click);
            // 
            // menuCategoryManagement
            // 
            this.menuCategoryManagement.Name = "menuCategoryManagement";
            this.menuCategoryManagement.Size = new System.Drawing.Size(359, 44);
            this.menuCategoryManagement.Text = "Danh mục vật tư";
            this.menuCategoryManagement.Click += new System.EventHandler(this.menuCategoryManagement_Click);
            // 
            // menuMaterialManagement
            // 
            this.menuMaterialManagement.Name = "menuMaterialManagement";
            this.menuMaterialManagement.Size = new System.Drawing.Size(359, 44);
            this.menuMaterialManagement.Text = "Vật tư";
            // 
            // menuUserManagement
            // 
            this.menuUserManagement.Name = "menuUserManagement";
            this.menuUserManagement.Size = new System.Drawing.Size(359, 44);
            this.menuUserManagement.Text = "Người dùng";
            // 
            // menuOperation
            // 
            this.menuOperation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStockReceipt});
            this.menuOperation.Name = "menuOperation";
            this.menuOperation.Size = new System.Drawing.Size(146, 38);
            this.menuOperation.Text = "Nghiệp vụ";
            // 
            // menuStockReceipt
            // 
            this.menuStockReceipt.Name = "menuStockReceipt";
            this.menuStockReceipt.Size = new System.Drawing.Size(315, 44);
            this.menuStockReceipt.Text = "Phiếu nhập kho";
            // 
            // menuReport
            // 
            this.menuReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStatisticsReport,
            this.menuPrintReceipt});
            this.menuReport.Name = "menuReport";
            this.menuReport.Size = new System.Drawing.Size(118, 38);
            this.menuReport.Text = "Báo cáo";
            // 
            // menuStatisticsReport
            // 
            this.menuStatisticsReport.Name = "menuStatisticsReport";
            this.menuStatisticsReport.Size = new System.Drawing.Size(334, 44);
            this.menuStatisticsReport.Text = "Báo cáo thống kê";
            // 
            // menuPrintReceipt
            // 
            this.menuPrintReceipt.Name = "menuPrintReceipt";
            this.menuPrintReceipt.Size = new System.Drawing.Size(334, 44);
            this.menuPrintReceipt.Text = "In hóa đơn ";
            // 
            // menuClose
            // 
            this.menuClose.Name = "menuClose";
            this.menuClose.Size = new System.Drawing.Size(95, 38);
            this.menuClose.Text = "Thoát";
            this.menuClose.Click += new System.EventHandler(this.menuClose_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(1132, 160);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(101, 25);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 865);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
    }
}