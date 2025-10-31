namespace building_materials_management.MasterData
{
    partial class frmMaterialManagement
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
            this.txtmavattu = new System.Windows.Forms.TextBox();
            this.txttenvattu = new System.Windows.Forms.TextBox();
            this.cbbdonvitinh = new System.Windows.Forms.ComboBox();
            this.txttonkho = new System.Windows.Forms.TextBox();
            this.cbbdanhmuc = new System.Windows.Forms.ComboBox();
            this.lblmavattu = new System.Windows.Forms.Label();
            this.lbltenvattu = new System.Windows.Forms.Label();
            this.lbldonvitinh = new System.Windows.Forms.Label();
            this.lbltonkho = new System.Windows.Forms.Label();
            this.lbldanhmuc = new System.Windows.Forms.Label();
            this.btnAnh = new System.Windows.Forms.Button();
            this.picAnh = new System.Windows.Forms.PictureBox();
            this.dgvMaterials = new System.Windows.Forms.DataGridView();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnBoQua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThemMoi = new System.Windows.Forms.Button();
            this.btn_Excel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).BeginInit();
            this.SuspendLayout();
            // 
            // txtmavattu
            // 
            this.txtmavattu.Location = new System.Drawing.Point(145, 37);
            this.txtmavattu.Name = "txtmavattu";
            this.txtmavattu.Size = new System.Drawing.Size(100, 22);
            this.txtmavattu.TabIndex = 0;
            // 
            // txttenvattu
            // 
            this.txttenvattu.Location = new System.Drawing.Point(145, 90);
            this.txttenvattu.Name = "txttenvattu";
            this.txttenvattu.Size = new System.Drawing.Size(100, 22);
            this.txttenvattu.TabIndex = 1;
            // 
            // cbbdonvitinh
            // 
            this.cbbdonvitinh.FormattingEnabled = true;
            this.cbbdonvitinh.Location = new System.Drawing.Point(145, 141);
            this.cbbdonvitinh.Name = "cbbdonvitinh";
            this.cbbdonvitinh.Size = new System.Drawing.Size(121, 24);
            this.cbbdonvitinh.TabIndex = 2;
            // 
            // txttonkho
            // 
            this.txttonkho.Location = new System.Drawing.Point(145, 189);
            this.txttonkho.Name = "txttonkho";
            this.txttonkho.Size = new System.Drawing.Size(100, 22);
            this.txttonkho.TabIndex = 3;
            // 
            // cbbdanhmuc
            // 
            this.cbbdanhmuc.FormattingEnabled = true;
            this.cbbdanhmuc.Location = new System.Drawing.Point(552, 10);
            this.cbbdanhmuc.Name = "cbbdanhmuc";
            this.cbbdanhmuc.Size = new System.Drawing.Size(253, 24);
            this.cbbdanhmuc.TabIndex = 4;
            // 
            // lblmavattu
            // 
            this.lblmavattu.AutoSize = true;
            this.lblmavattu.Location = new System.Drawing.Point(26, 37);
            this.lblmavattu.Name = "lblmavattu";
            this.lblmavattu.Size = new System.Drawing.Size(60, 16);
            this.lblmavattu.TabIndex = 5;
            this.lblmavattu.Text = "Mã vật tư";
            // 
            // lbltenvattu
            // 
            this.lbltenvattu.AutoSize = true;
            this.lbltenvattu.Location = new System.Drawing.Point(26, 90);
            this.lbltenvattu.Name = "lbltenvattu";
            this.lbltenvattu.Size = new System.Drawing.Size(65, 16);
            this.lbltenvattu.TabIndex = 6;
            this.lbltenvattu.Text = "Tên vật tư";
            // 
            // lbldonvitinh
            // 
            this.lbldonvitinh.AutoSize = true;
            this.lbldonvitinh.Location = new System.Drawing.Point(26, 141);
            this.lbldonvitinh.Name = "lbldonvitinh";
            this.lbldonvitinh.Size = new System.Drawing.Size(67, 16);
            this.lbldonvitinh.TabIndex = 7;
            this.lbldonvitinh.Text = "Đơn vị tính";
            // 
            // lbltonkho
            // 
            this.lbltonkho.AutoSize = true;
            this.lbltonkho.Location = new System.Drawing.Point(26, 189);
            this.lbltonkho.Name = "lbltonkho";
            this.lbltonkho.Size = new System.Drawing.Size(56, 16);
            this.lbltonkho.TabIndex = 8;
            this.lbltonkho.Text = "Tồn kho";
            // 
            // lbldanhmuc
            // 
            this.lbldanhmuc.AutoSize = true;
            this.lbldanhmuc.Location = new System.Drawing.Point(441, 18);
            this.lbldanhmuc.Name = "lbldanhmuc";
            this.lbldanhmuc.Size = new System.Drawing.Size(67, 16);
            this.lbldanhmuc.TabIndex = 9;
            this.lbldanhmuc.Text = "Danh mục";
            // 
            // btnAnh
            // 
            this.btnAnh.Location = new System.Drawing.Point(436, 69);
            this.btnAnh.Name = "btnAnh";
            this.btnAnh.Size = new System.Drawing.Size(93, 23);
            this.btnAnh.TabIndex = 21;
            this.btnAnh.Text = "Ảnh";
            this.btnAnh.UseVisualStyleBackColor = true;
            this.btnAnh.Click += new System.EventHandler(this.btnAnh_Click);
            // 
            // picAnh
            // 
            this.picAnh.Location = new System.Drawing.Point(552, 56);
            this.picAnh.Name = "picAnh";
            this.picAnh.Size = new System.Drawing.Size(253, 155);
            this.picAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAnh.TabIndex = 22;
            this.picAnh.TabStop = false;
            // 
            // dgvMaterials
            // 
            this.dgvMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterials.Location = new System.Drawing.Point(29, 226);
            this.dgvMaterials.Name = "dgvMaterials";
            this.dgvMaterials.RowHeadersWidth = 51;
            this.dgvMaterials.RowTemplate.Height = 24;
            this.dgvMaterials.Size = new System.Drawing.Size(805, 234);
            this.dgvMaterials.TabIndex = 23;
            this.dgvMaterials.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMaterials_CellClick);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(688, 496);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(81, 23);
            this.btnThoat.TabIndex = 29;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnBoQua
            // 
            this.btnBoQua.Location = new System.Drawing.Point(464, 496);
            this.btnBoQua.Name = "btnBoQua";
            this.btnBoQua.Size = new System.Drawing.Size(82, 23);
            this.btnBoQua.TabIndex = 28;
            this.btnBoQua.Text = "Bỏ qua";
            this.btnBoQua.UseVisualStyleBackColor = true;
            this.btnBoQua.Click += new System.EventHandler(this.btnBoQua_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(350, 496);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(82, 23);
            this.btnXoa.TabIndex = 27;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(234, 496);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(72, 23);
            this.btnSua.TabIndex = 26;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(127, 496);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(77, 23);
            this.btnLuu.TabIndex = 25;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThemMoi
            // 
            this.btnThemMoi.Location = new System.Drawing.Point(31, 496);
            this.btnThemMoi.Name = "btnThemMoi";
            this.btnThemMoi.Size = new System.Drawing.Size(77, 23);
            this.btnThemMoi.TabIndex = 24;
            this.btnThemMoi.Text = "Thêm mới";
            this.btnThemMoi.UseVisualStyleBackColor = true;
            this.btnThemMoi.Click += new System.EventHandler(this.btnThemMoi_Click);
            // 
            // btn_Excel
            // 
            this.btn_Excel.Location = new System.Drawing.Point(590, 496);
            this.btn_Excel.Name = "btn_Excel";
            this.btn_Excel.Size = new System.Drawing.Size(82, 23);
            this.btn_Excel.TabIndex = 30;
            this.btn_Excel.Text = "Xuất Excel";
            this.btn_Excel.UseVisualStyleBackColor = true;
            // 
            // frmMaterialManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 570);
            this.Controls.Add(this.btn_Excel);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnBoQua);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnThemMoi);
            this.Controls.Add(this.dgvMaterials);
            this.Controls.Add(this.picAnh);
            this.Controls.Add(this.btnAnh);
            this.Controls.Add(this.lbldanhmuc);
            this.Controls.Add(this.lbltonkho);
            this.Controls.Add(this.lbldonvitinh);
            this.Controls.Add(this.lbltenvattu);
            this.Controls.Add(this.lblmavattu);
            this.Controls.Add(this.cbbdanhmuc);
            this.Controls.Add(this.txttonkho);
            this.Controls.Add(this.cbbdonvitinh);
            this.Controls.Add(this.txttenvattu);
            this.Controls.Add(this.txtmavattu);
            this.Name = "frmMaterialManagement";
            this.Text = "frmMaterialManagement";
            this.Load += new System.EventHandler(this.frmMaterialManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picAnh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtmavattu;
        private System.Windows.Forms.TextBox txttenvattu;
        private System.Windows.Forms.ComboBox cbbdonvitinh;
        private System.Windows.Forms.TextBox txttonkho;
        private System.Windows.Forms.ComboBox cbbdanhmuc;
        private System.Windows.Forms.Label lblmavattu;
        private System.Windows.Forms.Label lbltenvattu;
        private System.Windows.Forms.Label lbldonvitinh;
        private System.Windows.Forms.Label lbltonkho;
        private System.Windows.Forms.Label lbldanhmuc;
        private System.Windows.Forms.Button btnAnh;
        private System.Windows.Forms.PictureBox picAnh;
        private System.Windows.Forms.DataGridView dgvMaterials;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnBoQua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThemMoi;
        private System.Windows.Forms.Button btn_Excel;
    }
}