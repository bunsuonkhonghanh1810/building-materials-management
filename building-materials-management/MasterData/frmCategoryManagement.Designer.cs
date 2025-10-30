namespace building_materials_management.MasterData
{
    partial class frmCategoryManagement
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbDMVT = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExcel = new System.Windows.Forms.Button();
            this.txtMaDM = new System.Windows.Forms.TextBox();
            this.lblMaDM = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.txtTenDanhMuc = new System.Windows.Forms.TextBox();
            this.lblMoTa = new System.Windows.Forms.Label();
            this.lblTenDM = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvDanhMuc = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbDMVT);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1742, 112);
            this.panel1.TabIndex = 0;
            // 
            // lbDMVT
            // 
            this.lbDMVT.AutoSize = true;
            this.lbDMVT.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDMVT.Location = new System.Drawing.Point(573, 28);
            this.lbDMVT.Name = "lbDMVT";
            this.lbDMVT.Size = new System.Drawing.Size(551, 51);
            this.lbDMVT.TabIndex = 0;
            this.lbDMVT.Text = "Quản Lý Danh Mục Vật Tư";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExcel);
            this.panel2.Controls.Add(this.txtMaDM);
            this.panel2.Controls.Add(this.lblMaDM);
            this.panel2.Controls.Add(this.btnTimKiem);
            this.panel2.Controls.Add(this.txtTimKiem);
            this.panel2.Controls.Add(this.lblTimKiem);
            this.panel2.Controls.Add(this.txtMoTa);
            this.panel2.Controls.Add(this.txtTenDanhMuc);
            this.panel2.Controls.Add(this.lblMoTa);
            this.panel2.Controls.Add(this.lblTenDM);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 112);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1742, 217);
            this.panel2.TabIndex = 1;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(1488, 138);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(145, 56);
            this.btnExcel.TabIndex = 9;
            this.btnExcel.Text = "Xuất Excel";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // txtMaDM
            // 
            this.txtMaDM.Location = new System.Drawing.Point(699, 16);
            this.txtMaDM.Name = "txtMaDM";
            this.txtMaDM.Size = new System.Drawing.Size(134, 31);
            this.txtMaDM.TabIndex = 8;
            // 
            // lblMaDM
            // 
            this.lblMaDM.AutoSize = true;
            this.lblMaDM.Location = new System.Drawing.Point(539, 19);
            this.lblMaDM.Name = "lblMaDM";
            this.lblMaDM.Size = new System.Drawing.Size(154, 25);
            this.lblMaDM.TabIndex = 7;
            this.lblMaDM.Text = "Mã danh mục: ";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(1488, 69);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(145, 48);
            this.btnTimKiem.TabIndex = 6;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(1158, 15);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(475, 31);
            this.txtTimKiem.TabIndex = 5;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(1026, 18);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(98, 25);
            this.lblTimKiem.TabIndex = 4;
            this.lblTimKiem.Text = "Tìm kiếm";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(211, 78);
            this.txtMoTa.Multiline = true;
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(622, 127);
            this.txtMoTa.TabIndex = 3;
            // 
            // txtTenDanhMuc
            // 
            this.txtTenDanhMuc.Location = new System.Drawing.Point(211, 16);
            this.txtTenDanhMuc.Name = "txtTenDanhMuc";
            this.txtTenDanhMuc.Size = new System.Drawing.Size(301, 31);
            this.txtTenDanhMuc.TabIndex = 2;
            // 
            // lblMoTa
            // 
            this.lblMoTa.AutoSize = true;
            this.lblMoTa.Location = new System.Drawing.Point(124, 78);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(72, 25);
            this.lblMoTa.TabIndex = 2;
            this.lblMoTa.Text = "Mô tả:";
            // 
            // lblTenDM
            // 
            this.lblTenDM.AutoSize = true;
            this.lblTenDM.Location = new System.Drawing.Point(41, 22);
            this.lblTenDM.Name = "lblTenDM";
            this.lblTenDM.Size = new System.Drawing.Size(155, 25);
            this.lblTenDM.TabIndex = 2;
            this.lblTenDM.Text = "Tên danh mục:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.dgvDanhMuc);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 329);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1742, 638);
            this.panel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "Danh mục vật tư";
            // 
            // dgvDanhMuc
            // 
            this.dgvDanhMuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhMuc.Location = new System.Drawing.Point(32, 61);
            this.dgvDanhMuc.Name = "dgvDanhMuc";
            this.dgvDanhMuc.RowHeadersWidth = 82;
            this.dgvDanhMuc.RowTemplate.Height = 33;
            this.dgvDanhMuc.Size = new System.Drawing.Size(1676, 395);
            this.dgvDanhMuc.TabIndex = 3;
            this.dgvDanhMuc.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhMuc_CellClick);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnThoat);
            this.panel4.Controls.Add(this.btnHuy);
            this.panel4.Controls.Add(this.btnLuu);
            this.panel4.Controls.Add(this.btnXoa);
            this.panel4.Controls.Add(this.btnSua);
            this.panel4.Controls.Add(this.btnThem);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 813);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1742, 154);
            this.panel4.TabIndex = 3;
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(1479, 60);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(154, 48);
            this.btnThoat.TabIndex = 5;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(722, 60);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(111, 48);
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(573, 59);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(103, 49);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(429, 60);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(96, 48);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(265, 60);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(110, 48);
            this.btnSua.TabIndex = 1;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(108, 60);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(107, 48);
            this.btnThem.TabIndex = 0;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // frmCategoryManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1742, 967);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmCategoryManagement";
            this.Text = "frmCategoryManagement";
            this.Load += new System.EventHandler(this.frmCategoryManagement_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhMuc)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbDMVT;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTenDM;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.TextBox txtTenDanhMuc;
        private System.Windows.Forms.Label lblMoTa;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDanhMuc;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label lblMaDM;
        private System.Windows.Forms.TextBox txtMaDM;
        private System.Windows.Forms.Button btnExcel;
    }
}