﻿namespace NotifierManager.WinForms.Forms
{
    partial class AddNotificationForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpSound = new System.Windows.Forms.GroupBox();
            this.lblSelectedSound = new System.Windows.Forms.Label();
            this.btnSelectSound = new System.Windows.Forms.Button();
            this.chkEnableSound = new System.Windows.Forms.CheckBox();
            this.dtpNotificationTime = new System.Windows.Forms.DateTimePicker();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblPriority = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.lblNotificationTime = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.ofdSound = new System.Windows.Forms.OpenFileDialog();
            this.grpRepeat = new System.Windows.Forms.GroupBox();
            this.chkRepeat = new System.Windows.Forms.CheckBox();
            this.cmbRepeatPattern = new System.Windows.Forms.ComboBox();
            this.lblNextRepeat = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpSound.SuspendLayout();
            this.panel1.SuspendLayout();
            this.grpRepeat.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.grpSound, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.dtpNotificationTime, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtTitle, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblPriority, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblMessage, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbCategory, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtMessage, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblCategory, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbPriority, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblNotificationTime, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.grpRepeat, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(582, 553);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grpSound
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grpSound, 2);
            this.grpSound.Controls.Add(this.lblSelectedSound);
            this.grpSound.Controls.Add(this.btnSelectSound);
            this.grpSound.Controls.Add(this.chkEnableSound);
            this.grpSound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSound.Location = new System.Drawing.Point(13, 343);
            this.grpSound.Name = "grpSound";
            this.grpSound.Size = new System.Drawing.Size(556, 60);
            this.grpSound.TabIndex = 22;
            this.grpSound.TabStop = false;
            this.grpSound.Text = "Ses Ayarları";
            // 
            // lblSelectedSound
            // 
            this.lblSelectedSound.AutoSize = true;
            this.lblSelectedSound.Location = new System.Drawing.Point(250, 30);
            this.lblSelectedSound.Name = "lblSelectedSound";
            this.lblSelectedSound.Size = new System.Drawing.Size(97, 16);
            this.lblSelectedSound.TabIndex = 2;
            this.lblSelectedSound.Text = "Seçili Ses: Yok";
            // 
            // btnSelectSound
            // 
            this.btnSelectSound.Enabled = false;
            this.btnSelectSound.Location = new System.Drawing.Point(150, 25);
            this.btnSelectSound.Name = "btnSelectSound";
            this.btnSelectSound.Size = new System.Drawing.Size(80, 30);
            this.btnSelectSound.TabIndex = 1;
            this.btnSelectSound.Text = "Ses Seç";
            this.btnSelectSound.UseVisualStyleBackColor = true;
            this.btnSelectSound.Click += new System.EventHandler(this.btnSelectSound_Click);
            // 
            // chkEnableSound
            // 
            this.chkEnableSound.AutoSize = true;
            this.chkEnableSound.Location = new System.Drawing.Point(20, 30);
            this.chkEnableSound.Name = "chkEnableSound";
            this.chkEnableSound.Size = new System.Drawing.Size(103, 20);
            this.chkEnableSound.TabIndex = 0;
            this.chkEnableSound.Text = "Bildirim Sesi";
            this.chkEnableSound.UseVisualStyleBackColor = true;
            this.chkEnableSound.CheckedChanged += new System.EventHandler(this.chkEnableSound_CheckedChanged);
            // 
            // dtpNotificationTime
            // 
            this.dtpNotificationTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpNotificationTime.CustomFormat = "dd.MM.yyyy HH:mm";
            this.dtpNotificationTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNotificationTime.Location = new System.Drawing.Point(181, 164);
            this.dtpNotificationTime.Name = "dtpNotificationTime";
            this.dtpNotificationTime.ShowUpDown = true;
            this.dtpNotificationTime.Size = new System.Drawing.Size(388, 22);
            this.dtpNotificationTime.TabIndex = 16;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(13, 32);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Padding = new System.Windows.Forms.Padding(3);
            this.lblTitle.Size = new System.Drawing.Size(53, 22);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "Başlık:";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(181, 32);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(388, 22);
            this.txtTitle.TabIndex = 12;
            // 
            // lblPriority
            // 
            this.lblPriority.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPriority.AutoSize = true;
            this.lblPriority.Location = new System.Drawing.Point(13, 296);
            this.lblPriority.Name = "lblPriority";
            this.lblPriority.Padding = new System.Windows.Forms.Padding(3);
            this.lblPriority.Size = new System.Drawing.Size(61, 22);
            this.lblPriority.TabIndex = 19;
            this.lblPriority.Text = "Öncelik:";
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(13, 98);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Padding = new System.Windows.Forms.Padding(3);
            this.lblMessage.Size = new System.Drawing.Size(53, 22);
            this.lblMessage.TabIndex = 13;
            this.lblMessage.Text = "Mesaj:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(181, 229);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(388, 24);
            this.cmbCategory.TabIndex = 18;
            // 
            // txtMessage
            // 
            this.txtMessage.AcceptsReturn = true;
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.Location = new System.Drawing.Point(181, 79);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(388, 60);
            this.txtMessage.TabIndex = 14;
            // 
            // lblCategory
            // 
            this.lblCategory.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(13, 230);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Padding = new System.Windows.Forms.Padding(3);
            this.lblCategory.Size = new System.Drawing.Size(66, 22);
            this.lblCategory.TabIndex = 17;
            this.lblCategory.Text = "Kategori:";
            // 
            // cmbPriority
            // 
            this.cmbPriority.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbPriority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Location = new System.Drawing.Point(181, 295);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(388, 24);
            this.cmbPriority.TabIndex = 20;
            // 
            // lblNotificationTime
            // 
            this.lblNotificationTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNotificationTime.AutoSize = true;
            this.lblNotificationTime.Location = new System.Drawing.Point(13, 164);
            this.lblNotificationTime.Name = "lblNotificationTime";
            this.lblNotificationTime.Padding = new System.Windows.Forms.Padding(3);
            this.lblNotificationTime.Size = new System.Drawing.Size(108, 22);
            this.lblNotificationTime.TabIndex = 15;
            this.lblNotificationTime.Text = "Bildirim Zamanı:";
            // 
            // panel1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel1, 2);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(13, 475);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(556, 65);
            this.panel1.TabIndex = 21;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCancel.Location = new System.Drawing.Point(10, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 45);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "İptal";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.Location = new System.Drawing.Point(438, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(108, 45);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ofdSound
            // 
            this.ofdSound.FileName = "openFileDialog1";
            this.ofdSound.Filter = "Ses Dosyaları (*.wav)|*.wav|Tüm Dosyalar (*.*)|*.*";
            this.ofdSound.Title = "Bildirim Sesi Seç";
            // 
            // grpRepeat
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grpRepeat, 2);
            this.grpRepeat.Controls.Add(this.lblNextRepeat);
            this.grpRepeat.Controls.Add(this.cmbRepeatPattern);
            this.grpRepeat.Controls.Add(this.chkRepeat);
            this.grpRepeat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRepeat.Location = new System.Drawing.Point(13, 409);
            this.grpRepeat.Name = "grpRepeat";
            this.grpRepeat.Size = new System.Drawing.Size(556, 60);
            this.grpRepeat.TabIndex = 23;
            this.grpRepeat.TabStop = false;
            this.grpRepeat.Text = "Tekrarlama";
            // 
            // chkRepeat
            // 
            this.chkRepeat.AutoSize = true;
            this.chkRepeat.Location = new System.Drawing.Point(20, 25);
            this.chkRepeat.Name = "chkRepeat";
            this.chkRepeat.Size = new System.Drawing.Size(142, 20);
            this.chkRepeat.TabIndex = 0;
            this.chkRepeat.Text = "Bu bildirimi tekrarla";
            this.chkRepeat.UseVisualStyleBackColor = true;
            this.chkRepeat.CheckedChanged += new System.EventHandler(this.chkRepeat_CheckedChanged);
            // 
            // cmbRepeatPattern
            // 
            this.cmbRepeatPattern.Enabled = false;
            this.cmbRepeatPattern.FormattingEnabled = true;
            this.cmbRepeatPattern.Items.AddRange(new object[] {
            "Her Gün",
            "Her Hafta",
            "Her Ay"});
            this.cmbRepeatPattern.Location = new System.Drawing.Point(165, 20);
            this.cmbRepeatPattern.Name = "cmbRepeatPattern";
            this.cmbRepeatPattern.Size = new System.Drawing.Size(121, 24);
            this.cmbRepeatPattern.TabIndex = 1;
            this.cmbRepeatPattern.SelectedIndexChanged += new System.EventHandler(this.cmbRepeatPattern_SelectedIndexChanged);
            // 
            // lblNextRepeat
            // 
            this.lblNextRepeat.AutoSize = true;
            this.lblNextRepeat.Location = new System.Drawing.Point(293, 22);
            this.lblNextRepeat.Name = "lblNextRepeat";
            this.lblNextRepeat.Size = new System.Drawing.Size(100, 16);
            this.lblNextRepeat.TabIndex = 2;
            this.lblNextRepeat.Text = "Sonraki tekrar: -";
            // 
            // AddNotificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 553);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddNotificationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Yeni Bildirim";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.grpSound.ResumeLayout(false);
            this.grpSound.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.grpRepeat.ResumeLayout(false);
            this.grpRepeat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DateTimePicker dtpNotificationTime;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblPriority;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.Label lblNotificationTime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpSound;
        private System.Windows.Forms.Label lblSelectedSound;
        private System.Windows.Forms.Button btnSelectSound;
        private System.Windows.Forms.CheckBox chkEnableSound;
        private System.Windows.Forms.OpenFileDialog ofdSound;
        private System.Windows.Forms.GroupBox grpRepeat;
        private System.Windows.Forms.Label lblNextRepeat;
        private System.Windows.Forms.ComboBox cmbRepeatPattern;
        private System.Windows.Forms.CheckBox chkRepeat;
    }
}