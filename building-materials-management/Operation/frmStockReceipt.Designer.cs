namespace building_materials_management.Operation
{
    partial class frmStockReceipt
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
            this.grbGeneralInfo = new System.Windows.Forms.GroupBox();
            this.dtpCreateAt = new System.Windows.Forms.DateTimePicker();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.txtReceiptId = new System.Windows.Forms.TextBox();
            this.lblCreatedAt = new System.Windows.Forms.Label();
            this.lblReceiptId = new System.Windows.Forms.Label();
            this.grbSupplierInfo = new System.Windows.Forms.GroupBox();
            this.cbbSupplierName = new System.Windows.Forms.ComboBox();
            this.txtSupplierTaxNumber = new System.Windows.Forms.TextBox();
            this.txtSupplierPhoneNumber = new System.Windows.Forms.TextBox();
            this.txtSupplierEmail = new System.Windows.Forms.TextBox();
            this.lblSupplierTaxNumber = new System.Windows.Forms.Label();
            this.lblSupplierPhoneNumber = new System.Windows.Forms.Label();
            this.lblSupplierEmail = new System.Windows.Forms.Label();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grbReceiptInfo = new System.Windows.Forms.GroupBox();
            this.dgvMaterials = new System.Windows.Forms.DataGridView();
            this.lblMaterialUnit = new System.Windows.Forms.Label();
            this.cbbMaterialName = new System.Windows.Forms.ComboBox();
            this.cbbMaterialId = new System.Windows.Forms.ComboBox();
            this.txtMaterialPrice = new System.Windows.Forms.TextBox();
            this.lblMaterialPrice = new System.Windows.Forms.Label();
            this.txtMaterialTotal = new System.Windows.Forms.TextBox();
            this.lblMaterialTotal = new System.Windows.Forms.Label();
            this.txtMaterialQuantity = new System.Windows.Forms.TextBox();
            this.lblMaterialQuantity = new System.Windows.Forms.Label();
            this.lblMaterialName = new System.Windows.Forms.Label();
            this.lblMaterialId = new System.Windows.Forms.Label();
            this.grbNote = new System.Windows.Forms.GroupBox();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddMaterial = new System.Windows.Forms.Button();
            this.btnCancelMaterial = new System.Windows.Forms.Button();
            this.btnDeleteMaterial = new System.Windows.Forms.Button();
            this.grbGeneralInfo.SuspendLayout();
            this.grbSupplierInfo.SuspendLayout();
            this.grbReceiptInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).BeginInit();
            this.grbNote.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbGeneralInfo
            // 
            this.grbGeneralInfo.Controls.Add(this.dtpCreateAt);
            this.grbGeneralInfo.Controls.Add(this.txtUserName);
            this.grbGeneralInfo.Controls.Add(this.txtUserId);
            this.grbGeneralInfo.Controls.Add(this.lblUserName);
            this.grbGeneralInfo.Controls.Add(this.lblUserId);
            this.grbGeneralInfo.Controls.Add(this.txtReceiptId);
            this.grbGeneralInfo.Controls.Add(this.lblCreatedAt);
            this.grbGeneralInfo.Controls.Add(this.lblReceiptId);
            this.grbGeneralInfo.Location = new System.Drawing.Point(39, 58);
            this.grbGeneralInfo.Name = "grbGeneralInfo";
            this.grbGeneralInfo.Size = new System.Drawing.Size(346, 129);
            this.grbGeneralInfo.TabIndex = 0;
            this.grbGeneralInfo.TabStop = false;
            this.grbGeneralInfo.Text = "Thông tin chung";
            // 
            // dtpCreateAt
            // 
            this.dtpCreateAt.Location = new System.Drawing.Point(125, 51);
            this.dtpCreateAt.Name = "dtpCreateAt";
            this.dtpCreateAt.Size = new System.Drawing.Size(197, 20);
            this.dtpCreateAt.TabIndex = 1;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(125, 95);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(197, 20);
            this.txtUserName.TabIndex = 23;
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(125, 73);
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(197, 20);
            this.txtUserId.TabIndex = 22;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(17, 98);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(76, 13);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "Tên người tạo:";
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Location = new System.Drawing.Point(17, 76);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(72, 13);
            this.lblUserId.TabIndex = 2;
            this.lblUserId.Text = "Mã người tạo:";
            // 
            // txtReceiptId
            // 
            this.txtReceiptId.Location = new System.Drawing.Point(125, 28);
            this.txtReceiptId.Name = "txtReceiptId";
            this.txtReceiptId.Size = new System.Drawing.Size(197, 20);
            this.txtReceiptId.TabIndex = 20;
            // 
            // lblCreatedAt
            // 
            this.lblCreatedAt.AutoSize = true;
            this.lblCreatedAt.Location = new System.Drawing.Point(17, 54);
            this.lblCreatedAt.Name = "lblCreatedAt";
            this.lblCreatedAt.Size = new System.Drawing.Size(53, 13);
            this.lblCreatedAt.TabIndex = 1;
            this.lblCreatedAt.Text = "Ngày tạo:";
            // 
            // lblReceiptId
            // 
            this.lblReceiptId.AutoSize = true;
            this.lblReceiptId.Location = new System.Drawing.Point(17, 31);
            this.lblReceiptId.Name = "lblReceiptId";
            this.lblReceiptId.Size = new System.Drawing.Size(54, 13);
            this.lblReceiptId.TabIndex = 0;
            this.lblReceiptId.Text = "Mã phiếu:";
            // 
            // grbSupplierInfo
            // 
            this.grbSupplierInfo.Controls.Add(this.cbbSupplierName);
            this.grbSupplierInfo.Controls.Add(this.txtSupplierTaxNumber);
            this.grbSupplierInfo.Controls.Add(this.txtSupplierPhoneNumber);
            this.grbSupplierInfo.Controls.Add(this.txtSupplierEmail);
            this.grbSupplierInfo.Controls.Add(this.lblSupplierTaxNumber);
            this.grbSupplierInfo.Controls.Add(this.lblSupplierPhoneNumber);
            this.grbSupplierInfo.Controls.Add(this.lblSupplierEmail);
            this.grbSupplierInfo.Controls.Add(this.lblSupplierName);
            this.grbSupplierInfo.Location = new System.Drawing.Point(413, 58);
            this.grbSupplierInfo.Name = "grbSupplierInfo";
            this.grbSupplierInfo.Size = new System.Drawing.Size(346, 129);
            this.grbSupplierInfo.TabIndex = 1;
            this.grbSupplierInfo.TabStop = false;
            this.grbSupplierInfo.Text = "Thông tin nhà cung cấp";
            // 
            // cbbSupplierName
            // 
            this.cbbSupplierName.FormattingEnabled = true;
            this.cbbSupplierName.Location = new System.Drawing.Point(126, 28);
            this.cbbSupplierName.Name = "cbbSupplierName";
            this.cbbSupplierName.Size = new System.Drawing.Size(197, 21);
            this.cbbSupplierName.TabIndex = 1;
            this.cbbSupplierName.SelectedIndexChanged += new System.EventHandler(this.cbbSupplierName_SelectedIndexChanged);
            // 
            // txtSupplierTaxNumber
            // 
            this.txtSupplierTaxNumber.Location = new System.Drawing.Point(126, 95);
            this.txtSupplierTaxNumber.Name = "txtSupplierTaxNumber";
            this.txtSupplierTaxNumber.Size = new System.Drawing.Size(197, 20);
            this.txtSupplierTaxNumber.TabIndex = 19;
            // 
            // txtSupplierPhoneNumber
            // 
            this.txtSupplierPhoneNumber.Location = new System.Drawing.Point(126, 73);
            this.txtSupplierPhoneNumber.Name = "txtSupplierPhoneNumber";
            this.txtSupplierPhoneNumber.Size = new System.Drawing.Size(197, 20);
            this.txtSupplierPhoneNumber.TabIndex = 18;
            // 
            // txtSupplierEmail
            // 
            this.txtSupplierEmail.Location = new System.Drawing.Point(126, 51);
            this.txtSupplierEmail.Name = "txtSupplierEmail";
            this.txtSupplierEmail.Size = new System.Drawing.Size(197, 20);
            this.txtSupplierEmail.TabIndex = 17;
            // 
            // lblSupplierTaxNumber
            // 
            this.lblSupplierTaxNumber.AutoSize = true;
            this.lblSupplierTaxNumber.Location = new System.Drawing.Point(22, 98);
            this.lblSupplierTaxNumber.Name = "lblSupplierTaxNumber";
            this.lblSupplierTaxNumber.Size = new System.Drawing.Size(63, 13);
            this.lblSupplierTaxNumber.TabIndex = 7;
            this.lblSupplierTaxNumber.Text = "Mã số thuế:";
            // 
            // lblSupplierPhoneNumber
            // 
            this.lblSupplierPhoneNumber.AutoSize = true;
            this.lblSupplierPhoneNumber.Location = new System.Drawing.Point(22, 78);
            this.lblSupplierPhoneNumber.Name = "lblSupplierPhoneNumber";
            this.lblSupplierPhoneNumber.Size = new System.Drawing.Size(73, 13);
            this.lblSupplierPhoneNumber.TabIndex = 6;
            this.lblSupplierPhoneNumber.Text = "Số điện thoại:";
            // 
            // lblSupplierEmail
            // 
            this.lblSupplierEmail.AutoSize = true;
            this.lblSupplierEmail.Location = new System.Drawing.Point(22, 54);
            this.lblSupplierEmail.Name = "lblSupplierEmail";
            this.lblSupplierEmail.Size = new System.Drawing.Size(35, 13);
            this.lblSupplierEmail.TabIndex = 5;
            this.lblSupplierEmail.Text = "Email:";
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Location = new System.Drawing.Point(22, 31);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(98, 13);
            this.lblSupplierName.TabIndex = 4;
            this.lblSupplierName.Text = "Tên nhà cung cấp:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblTitle.Location = new System.Drawing.Point(299, 21);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(170, 24);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "PHIẾU NHẬP KHO";
            this.lblTitle.Click += new System.EventHandler(this.label1_Click);
            // 
            // grbReceiptInfo
            // 
            this.grbReceiptInfo.Controls.Add(this.dgvMaterials);
            this.grbReceiptInfo.Controls.Add(this.lblMaterialUnit);
            this.grbReceiptInfo.Controls.Add(this.cbbMaterialName);
            this.grbReceiptInfo.Controls.Add(this.cbbMaterialId);
            this.grbReceiptInfo.Controls.Add(this.txtMaterialPrice);
            this.grbReceiptInfo.Controls.Add(this.lblMaterialPrice);
            this.grbReceiptInfo.Controls.Add(this.txtMaterialTotal);
            this.grbReceiptInfo.Controls.Add(this.lblMaterialTotal);
            this.grbReceiptInfo.Controls.Add(this.txtMaterialQuantity);
            this.grbReceiptInfo.Controls.Add(this.lblMaterialQuantity);
            this.grbReceiptInfo.Controls.Add(this.lblMaterialName);
            this.grbReceiptInfo.Controls.Add(this.lblMaterialId);
            this.grbReceiptInfo.Location = new System.Drawing.Point(39, 337);
            this.grbReceiptInfo.Name = "grbReceiptInfo";
            this.grbReceiptInfo.Size = new System.Drawing.Size(720, 254);
            this.grbReceiptInfo.TabIndex = 2;
            this.grbReceiptInfo.TabStop = false;
            this.grbReceiptInfo.Text = "Thông tin hóa đơn";
            // 
            // dgvMaterials
            // 
            this.dgvMaterials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterials.Location = new System.Drawing.Point(20, 98);
            this.dgvMaterials.Name = "dgvMaterials";
            this.dgvMaterials.Size = new System.Drawing.Size(677, 135);
            this.dgvMaterials.TabIndex = 21;
            // 
            // lblMaterialUnit
            // 
            this.lblMaterialUnit.AutoSize = true;
            this.lblMaterialUnit.Location = new System.Drawing.Point(154, 58);
            this.lblMaterialUnit.Name = "lblMaterialUnit";
            this.lblMaterialUnit.Size = new System.Drawing.Size(38, 13);
            this.lblMaterialUnit.TabIndex = 20;
            this.lblMaterialUnit.Text = "Đơn vị";
            // 
            // cbbMaterialName
            // 
            this.cbbMaterialName.FormattingEnabled = true;
            this.cbbMaterialName.Location = new System.Drawing.Point(446, 24);
            this.cbbMaterialName.Name = "cbbMaterialName";
            this.cbbMaterialName.Size = new System.Drawing.Size(251, 21);
            this.cbbMaterialName.TabIndex = 19;
            this.cbbMaterialName.SelectedIndexChanged += new System.EventHandler(this.cbbMaterialName_SelectedIndexChanged);
            // 
            // cbbMaterialId
            // 
            this.cbbMaterialId.FormattingEnabled = true;
            this.cbbMaterialId.Location = new System.Drawing.Point(78, 24);
            this.cbbMaterialId.Name = "cbbMaterialId";
            this.cbbMaterialId.Size = new System.Drawing.Size(251, 21);
            this.cbbMaterialId.TabIndex = 18;
            this.cbbMaterialId.SelectedIndexChanged += new System.EventHandler(this.cbbMaterialId_SelectedIndexChanged);
            // 
            // txtMaterialPrice
            // 
            this.txtMaterialPrice.Location = new System.Drawing.Point(294, 55);
            this.txtMaterialPrice.Name = "txtMaterialPrice";
            this.txtMaterialPrice.Size = new System.Drawing.Size(137, 20);
            this.txtMaterialPrice.TabIndex = 17;
            // 
            // lblMaterialPrice
            // 
            this.lblMaterialPrice.AutoSize = true;
            this.lblMaterialPrice.Location = new System.Drawing.Point(241, 58);
            this.lblMaterialPrice.Name = "lblMaterialPrice";
            this.lblMaterialPrice.Size = new System.Drawing.Size(47, 13);
            this.lblMaterialPrice.TabIndex = 16;
            this.lblMaterialPrice.Text = "Đơn giá:";
            // 
            // txtMaterialTotal
            // 
            this.txtMaterialTotal.Location = new System.Drawing.Point(560, 55);
            this.txtMaterialTotal.Name = "txtMaterialTotal";
            this.txtMaterialTotal.Size = new System.Drawing.Size(137, 20);
            this.txtMaterialTotal.TabIndex = 15;
            // 
            // lblMaterialTotal
            // 
            this.lblMaterialTotal.AutoSize = true;
            this.lblMaterialTotal.Location = new System.Drawing.Point(497, 58);
            this.lblMaterialTotal.Name = "lblMaterialTotal";
            this.lblMaterialTotal.Size = new System.Drawing.Size(55, 13);
            this.lblMaterialTotal.TabIndex = 14;
            this.lblMaterialTotal.Text = "Tổng tiền:";
            // 
            // txtMaterialQuantity
            // 
            this.txtMaterialQuantity.Location = new System.Drawing.Point(78, 55);
            this.txtMaterialQuantity.Name = "txtMaterialQuantity";
            this.txtMaterialQuantity.Size = new System.Drawing.Size(70, 20);
            this.txtMaterialQuantity.TabIndex = 13;
            // 
            // lblMaterialQuantity
            // 
            this.lblMaterialQuantity.AutoSize = true;
            this.lblMaterialQuantity.Location = new System.Drawing.Point(17, 58);
            this.lblMaterialQuantity.Name = "lblMaterialQuantity";
            this.lblMaterialQuantity.Size = new System.Drawing.Size(52, 13);
            this.lblMaterialQuantity.TabIndex = 12;
            this.lblMaterialQuantity.Text = "Số lượng:";
            // 
            // lblMaterialName
            // 
            this.lblMaterialName.AutoSize = true;
            this.lblMaterialName.Location = new System.Drawing.Point(378, 27);
            this.lblMaterialName.Name = "lblMaterialName";
            this.lblMaterialName.Size = new System.Drawing.Size(59, 13);
            this.lblMaterialName.TabIndex = 9;
            this.lblMaterialName.Text = "Tên vật tư:";
            // 
            // lblMaterialId
            // 
            this.lblMaterialId.AutoSize = true;
            this.lblMaterialId.Location = new System.Drawing.Point(17, 27);
            this.lblMaterialId.Name = "lblMaterialId";
            this.lblMaterialId.Size = new System.Drawing.Size(55, 13);
            this.lblMaterialId.TabIndex = 8;
            this.lblMaterialId.Text = "Mã vật tư:";
            // 
            // grbNote
            // 
            this.grbNote.Controls.Add(this.txtNote);
            this.grbNote.Location = new System.Drawing.Point(39, 204);
            this.grbNote.Name = "grbNote";
            this.grbNote.Size = new System.Drawing.Size(720, 117);
            this.grbNote.TabIndex = 3;
            this.grbNote.TabStop = false;
            this.grbNote.Text = "Ghi chú";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(20, 24);
            this.txtNote.Multiline = true;
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(677, 74);
            this.txtNote.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(479, 597);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(135, 23);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Lưu hóa đơn";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(624, 597);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(135, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Thoát";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddMaterial
            // 
            this.btnAddMaterial.Location = new System.Drawing.Point(331, 597);
            this.btnAddMaterial.Name = "btnAddMaterial";
            this.btnAddMaterial.Size = new System.Drawing.Size(135, 23);
            this.btnAddMaterial.TabIndex = 6;
            this.btnAddMaterial.Text = "Thêm vật tư";
            this.btnAddMaterial.UseVisualStyleBackColor = true;
            this.btnAddMaterial.Click += new System.EventHandler(this.btnAddMaterial_Click);
            // 
            // btnCancelMaterial
            // 
            this.btnCancelMaterial.Location = new System.Drawing.Point(184, 597);
            this.btnCancelMaterial.Name = "btnCancelMaterial";
            this.btnCancelMaterial.Size = new System.Drawing.Size(135, 23);
            this.btnCancelMaterial.TabIndex = 7;
            this.btnCancelMaterial.Text = "Hủy vật tư";
            this.btnCancelMaterial.UseVisualStyleBackColor = true;
            this.btnCancelMaterial.Click += new System.EventHandler(this.btnCancelMaterial_Click);
            // 
            // btnDeleteMaterial
            // 
            this.btnDeleteMaterial.Location = new System.Drawing.Point(39, 597);
            this.btnDeleteMaterial.Name = "btnDeleteMaterial";
            this.btnDeleteMaterial.Size = new System.Drawing.Size(135, 23);
            this.btnDeleteMaterial.TabIndex = 8;
            this.btnDeleteMaterial.Text = "Xóa vật tư";
            this.btnDeleteMaterial.UseVisualStyleBackColor = true;
            this.btnDeleteMaterial.Click += new System.EventHandler(this.btnDeleteMaterial_Click_1);
            // 
            // frmStockReceipt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 644);
            this.Controls.Add(this.btnDeleteMaterial);
            this.Controls.Add(this.btnCancelMaterial);
            this.Controls.Add(this.btnAddMaterial);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.grbNote);
            this.Controls.Add(this.grbReceiptInfo);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grbSupplierInfo);
            this.Controls.Add(this.grbGeneralInfo);
            this.Name = "frmStockReceipt";
            this.Text = "frmStockReceipt";
            this.Load += new System.EventHandler(this.frmStockReceipt_Load);
            this.grbGeneralInfo.ResumeLayout(false);
            this.grbGeneralInfo.PerformLayout();
            this.grbSupplierInfo.ResumeLayout(false);
            this.grbSupplierInfo.PerformLayout();
            this.grbReceiptInfo.ResumeLayout(false);
            this.grbReceiptInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterials)).EndInit();
            this.grbNote.ResumeLayout(false);
            this.grbNote.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbGeneralInfo;
        private System.Windows.Forms.GroupBox grbSupplierInfo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox grbReceiptInfo;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label lblCreatedAt;
        private System.Windows.Forms.Label lblReceiptId;
        private System.Windows.Forms.Label lblSupplierTaxNumber;
        private System.Windows.Forms.Label lblSupplierPhoneNumber;
        private System.Windows.Forms.Label lblSupplierEmail;
        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.GroupBox grbNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Label lblMaterialName;
        private System.Windows.Forms.Label lblMaterialId;
        private System.Windows.Forms.TextBox txtMaterialQuantity;
        private System.Windows.Forms.Label lblMaterialQuantity;
        private System.Windows.Forms.TextBox txtMaterialTotal;
        private System.Windows.Forms.Label lblMaterialTotal;
        private System.Windows.Forms.DateTimePicker dtpCreateAt;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtUserId;
        private System.Windows.Forms.TextBox txtReceiptId;
        private System.Windows.Forms.TextBox txtSupplierTaxNumber;
        private System.Windows.Forms.TextBox txtSupplierPhoneNumber;
        private System.Windows.Forms.TextBox txtSupplierEmail;
        private System.Windows.Forms.ComboBox cbbSupplierName;
        private System.Windows.Forms.TextBox txtMaterialPrice;
        private System.Windows.Forms.Label lblMaterialPrice;
        private System.Windows.Forms.ComboBox cbbMaterialName;
        private System.Windows.Forms.ComboBox cbbMaterialId;
        private System.Windows.Forms.Label lblMaterialUnit;
        private System.Windows.Forms.DataGridView dgvMaterials;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAddMaterial;
        private System.Windows.Forms.Button btnCancelMaterial;
        private System.Windows.Forms.Button btnDeleteMaterial;
    }
}