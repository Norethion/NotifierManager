namespace NotifierManager.WinForms.Forms
{
    partial class CategoryManagementForm
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
            this.dgvCategories = new System.Windows.Forms.DataGridView();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.gbNewCategory = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlColorPreview = new System.Windows.Forms.Panel();
            this.btnSelectColor = new System.Windows.Forms.Button();
            this.lblCategoryName = new System.Windows.Forms.Label();
            this.lblSelectedColor = new System.Windows.Forms.Label();
            this.txtCategoryName = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.pnlControls.SuspendLayout();
            this.gbNewCategory.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCategories
            // 
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategories.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCategories.Location = new System.Drawing.Point(0, 0);
            this.dgvCategories.MultiSelect = false;
            this.dgvCategories.Name = "dgvCategories";
            this.dgvCategories.ReadOnly = true;
            this.dgvCategories.RowHeadersWidth = 51;
            this.dgvCategories.RowTemplate.Height = 24;
            this.dgvCategories.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.Size = new System.Drawing.Size(482, 353);
            this.dgvCategories.TabIndex = 0;
            // 
            // pnlControls
            // 
            this.pnlControls.Controls.Add(this.gbNewCategory);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControls.Location = new System.Drawing.Point(0, 203);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Padding = new System.Windows.Forms.Padding(10);
            this.pnlControls.Size = new System.Drawing.Size(482, 150);
            this.pnlControls.TabIndex = 1;
            // 
            // gbNewCategory
            // 
            this.gbNewCategory.Controls.Add(this.btnClose);
            this.gbNewCategory.Controls.Add(this.btnDelete);
            this.gbNewCategory.Controls.Add(this.btnAdd);
            this.gbNewCategory.Controls.Add(this.pnlColorPreview);
            this.gbNewCategory.Controls.Add(this.btnSelectColor);
            this.gbNewCategory.Controls.Add(this.lblCategoryName);
            this.gbNewCategory.Controls.Add(this.lblSelectedColor);
            this.gbNewCategory.Controls.Add(this.txtCategoryName);
            this.gbNewCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbNewCategory.Location = new System.Drawing.Point(10, 10);
            this.gbNewCategory.Name = "gbNewCategory";
            this.gbNewCategory.Size = new System.Drawing.Size(462, 130);
            this.gbNewCategory.TabIndex = 3;
            this.gbNewCategory.TabStop = false;
            this.gbNewCategory.Text = "Yeni Kategori";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(180, 90);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Kapat";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(100, 90);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(80, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(20, 90);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Ekle";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlColorPreview
            // 
            this.pnlColorPreview.BackColor = System.Drawing.Color.White;
            this.pnlColorPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlColorPreview.Location = new System.Drawing.Point(110, 56);
            this.pnlColorPreview.Name = "pnlColorPreview";
            this.pnlColorPreview.Size = new System.Drawing.Size(30, 20);
            this.pnlColorPreview.TabIndex = 4;
            // 
            // btnSelectColor
            // 
            this.btnSelectColor.Location = new System.Drawing.Point(320, 26);
            this.btnSelectColor.Name = "btnSelectColor";
            this.btnSelectColor.Size = new System.Drawing.Size(80, 23);
            this.btnSelectColor.TabIndex = 3;
            this.btnSelectColor.Text = "Renk Seç";
            this.btnSelectColor.UseVisualStyleBackColor = true;
            this.btnSelectColor.Click += new System.EventHandler(this.btnSelectColor_Click);
            // 
            // lblCategoryName
            // 
            this.lblCategoryName.Location = new System.Drawing.Point(20, 30);
            this.lblCategoryName.Name = "lblCategoryName";
            this.lblCategoryName.Size = new System.Drawing.Size(83, 19);
            this.lblCategoryName.TabIndex = 0;
            this.lblCategoryName.Text = "Kategori Adı:";
            // 
            // lblSelectedColor
            // 
            this.lblSelectedColor.AutoSize = true;
            this.lblSelectedColor.Location = new System.Drawing.Point(20, 60);
            this.lblSelectedColor.Name = "lblSelectedColor";
            this.lblSelectedColor.Size = new System.Drawing.Size(90, 16);
            this.lblSelectedColor.TabIndex = 2;
            this.lblSelectedColor.Text = "Seçilen Renk:";
            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new System.Drawing.Point(110, 27);
            this.txtCategoryName.Name = "txtCategoryName";
            this.txtCategoryName.Size = new System.Drawing.Size(200, 22);
            this.txtCategoryName.TabIndex = 1;
            // 
            // CategoryManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 353);
            this.Controls.Add(this.pnlControls);
            this.Controls.Add(this.dgvCategories);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CategoryManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kategori Yönetimi";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.pnlControls.ResumeLayout(false);
            this.gbNewCategory.ResumeLayout(false);
            this.gbNewCategory.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCategories;
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.GroupBox gbNewCategory;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.Label lblSelectedColor;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlColorPreview;
        private System.Windows.Forms.Button btnSelectColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}