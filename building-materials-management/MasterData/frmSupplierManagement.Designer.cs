namespace building_materials_management.MasterData
{
    partial class frmSupplierManagement
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
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.lblSupplierEmail = new System.Windows.Forms.Label();
            this.lblSupplierAddress = new System.Windows.Forms.Label();
            this.lblSupplierPhoneNumber = new System.Windows.Forms.Label();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.txtSupplierEmail = new System.Windows.Forms.TextBox();
            this.txtSupplierAddress = new System.Windows.Forms.TextBox();
            this.txtSupplierPhoneNumber = new System.Windows.Forms.TextBox();
            this.dgvSupplier = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblTaxNumber = new System.Windows.Forms.Label();
            this.txtTaxNumber = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplier)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Location = new System.Drawing.Point(39, 32);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(98, 13);
            this.lblSupplierName.TabIndex = 0;
            this.lblSupplierName.Text = "Tên nhà cung cấp:";
            // 
            // lblSupplierEmail
            // 
            this.lblSupplierEmail.AutoSize = true;
            this.lblSupplierEmail.Location = new System.Drawing.Point(39, 61);
            this.lblSupplierEmail.Name = "lblSupplierEmail";
            this.lblSupplierEmail.Size = new System.Drawing.Size(35, 13);
            this.lblSupplierEmail.TabIndex = 1;
            this.lblSupplierEmail.Text = "Email:";
            // 
            // lblSupplierAddress
            // 
            this.lblSupplierAddress.AutoSize = true;
            this.lblSupplierAddress.Location = new System.Drawing.Point(395, 32);
            this.lblSupplierAddress.Name = "lblSupplierAddress";
            this.lblSupplierAddress.Size = new System.Drawing.Size(112, 13);
            this.lblSupplierAddress.TabIndex = 2;
            this.lblSupplierAddress.Text = "Địa chỉ nhà cung cấp:";
            // 
            // lblSupplierPhoneNumber
            // 
            this.lblSupplierPhoneNumber.AutoSize = true;
            this.lblSupplierPhoneNumber.Location = new System.Drawing.Point(395, 61);
            this.lblSupplierPhoneNumber.Name = "lblSupplierPhoneNumber";
            this.lblSupplierPhoneNumber.Size = new System.Drawing.Size(73, 13);
            this.lblSupplierPhoneNumber.TabIndex = 3;
            this.lblSupplierPhoneNumber.Text = "Số điện thoại:";
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Location = new System.Drawing.Point(166, 29);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(163, 20);
            this.txtSupplierName.TabIndex = 4;
            // 
            // txtSupplierEmail
            // 
            this.txtSupplierEmail.Location = new System.Drawing.Point(166, 58);
            this.txtSupplierEmail.Name = "txtSupplierEmail";
            this.txtSupplierEmail.Size = new System.Drawing.Size(163, 20);
            this.txtSupplierEmail.TabIndex = 5;
            // 
            // txtSupplierAddress
            // 
            this.txtSupplierAddress.Location = new System.Drawing.Point(546, 29);
            this.txtSupplierAddress.Name = "txtSupplierAddress";
            this.txtSupplierAddress.Size = new System.Drawing.Size(163, 20);
            this.txtSupplierAddress.TabIndex = 6;
            // 
            // txtSupplierPhoneNumber
            // 
            this.txtSupplierPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSupplierPhoneNumber.Location = new System.Drawing.Point(546, 58);
            this.txtSupplierPhoneNumber.Name = "txtSupplierPhoneNumber";
            this.txtSupplierPhoneNumber.Size = new System.Drawing.Size(163, 20);
            this.txtSupplierPhoneNumber.TabIndex = 7;
            this.txtSupplierPhoneNumber.TextChanged += new System.EventHandler(this.txtSupplierPhoneNumber_TextChanged);
            this.txtSupplierPhoneNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSupplierPhoneNumber_KeyPress);
            // 
            // dgvSupplier
            // 
            this.dgvSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSupplier.Location = new System.Drawing.Point(42, 124);
            this.dgvSupplier.Name = "dgvSupplier";
            this.dgvSupplier.Size = new System.Drawing.Size(667, 132);
            this.dgvSupplier.TabIndex = 8;
            this.dgvSupplier.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSupplier_CellClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnEdit);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Location = new System.Drawing.Point(42, 289);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(667, 63);
            this.panel1.TabIndex = 9;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(555, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Thoát";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(417, 20);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Bỏ qua";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(288, 20);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = " Xóa";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(157, 20);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(34, 20);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblTaxNumber
            // 
            this.lblTaxNumber.AutoSize = true;
            this.lblTaxNumber.Location = new System.Drawing.Point(39, 91);
            this.lblTaxNumber.Name = "lblTaxNumber";
            this.lblTaxNumber.Size = new System.Drawing.Size(63, 13);
            this.lblTaxNumber.TabIndex = 10;
            this.lblTaxNumber.Text = "Mã số thuế:";
            // 
            // txtTaxNumber
            // 
            this.txtTaxNumber.Location = new System.Drawing.Point(166, 88);
            this.txtTaxNumber.Name = "txtTaxNumber";
            this.txtTaxNumber.Size = new System.Drawing.Size(163, 20);
            this.txtTaxNumber.TabIndex = 11;
            // 
            // frmSupplierManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 384);
            this.Controls.Add(this.txtTaxNumber);
            this.Controls.Add(this.lblTaxNumber);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvSupplier);
            this.Controls.Add(this.txtSupplierPhoneNumber);
            this.Controls.Add(this.txtSupplierAddress);
            this.Controls.Add(this.txtSupplierEmail);
            this.Controls.Add(this.txtSupplierName);
            this.Controls.Add(this.lblSupplierPhoneNumber);
            this.Controls.Add(this.lblSupplierAddress);
            this.Controls.Add(this.lblSupplierEmail);
            this.Controls.Add(this.lblSupplierName);
            this.Name = "frmSupplierManagement";
            this.Text = "frmSupplierManagement";
            this.Load += new System.EventHandler(this.frmSupplierManagement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSupplier)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.Label lblSupplierEmail;
        private System.Windows.Forms.Label lblSupplierAddress;
        private System.Windows.Forms.Label lblSupplierPhoneNumber;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.TextBox txtSupplierEmail;
        private System.Windows.Forms.TextBox txtSupplierAddress;
        private System.Windows.Forms.TextBox txtSupplierPhoneNumber;
        private System.Windows.Forms.DataGridView dgvSupplier;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblTaxNumber;
        private System.Windows.Forms.TextBox txtTaxNumber;
    }
}