namespace NotifierManager.WinForms.Forms
{
    partial class StatisticsForm
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgvGeneralStats = new System.Windows.Forms.DataGridView();
            this.chartCategories = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartPriority = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Metrik = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Değer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabMain.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeneralStats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCategories)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPriority)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPage1);
            this.tabMain.Controls.Add(this.tabPage2);
            this.tabMain.Controls.Add(this.tabPage3);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(582, 553);
            this.tabMain.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvGeneralStats);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(574, 524);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Genel İstatistikler";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chartCategories);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(574, 524);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Kategori Dağılımı";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chartPriority);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(574, 524);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Öncelik Dağılımı";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvGeneralStats
            // 
            this.dgvGeneralStats.AllowUserToAddRows = false;
            this.dgvGeneralStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGeneralStats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Metrik,
            this.Değer});
            this.dgvGeneralStats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGeneralStats.Location = new System.Drawing.Point(3, 3);
            this.dgvGeneralStats.Name = "dgvGeneralStats";
            this.dgvGeneralStats.ReadOnly = true;
            this.dgvGeneralStats.RowHeadersWidth = 51;
            this.dgvGeneralStats.RowTemplate.Height = 24;
            this.dgvGeneralStats.Size = new System.Drawing.Size(568, 518);
            this.dgvGeneralStats.TabIndex = 0;
            // 
            // chartCategories
            // 
            chartArea1.Name = "ChartArea1";
            this.chartCategories.ChartAreas.Add(chartArea1);
            this.chartCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartCategories.Legends.Add(legend1);
            this.chartCategories.Location = new System.Drawing.Point(3, 3);
            this.chartCategories.Name = "chartCategories";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartCategories.Series.Add(series1);
            this.chartCategories.Size = new System.Drawing.Size(568, 518);
            this.chartCategories.TabIndex = 0;
            this.chartCategories.Text = "chart1";
            // 
            // chartPriority
            // 
            chartArea2.Name = "ChartArea1";
            this.chartPriority.ChartAreas.Add(chartArea2);
            this.chartPriority.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chartPriority.Legends.Add(legend2);
            this.chartPriority.Location = new System.Drawing.Point(0, 0);
            this.chartPriority.Name = "chartPriority";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartPriority.Series.Add(series2);
            this.chartPriority.Size = new System.Drawing.Size(574, 524);
            this.chartPriority.TabIndex = 0;
            this.chartPriority.Text = "chart1";
            // 
            // Metrik
            // 
            this.Metrik.HeaderText = "Metrik";
            this.Metrik.MinimumWidth = 6;
            this.Metrik.Name = "Metrik";
            this.Metrik.ReadOnly = true;
            this.Metrik.Width = 200;
            // 
            // Değer
            // 
            this.Değer.HeaderText = "Değer";
            this.Değer.MinimumWidth = 6;
            this.Değer.Name = "Değer";
            this.Değer.ReadOnly = true;
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 553);
            this.Controls.Add(this.tabMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StatisticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Bildirim İstatistikleri";
            this.tabMain.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGeneralStats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartCategories)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartPriority)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgvGeneralStats;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartCategories;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn Metrik;
        private System.Windows.Forms.DataGridViewTextBoxColumn Değer;
    }
}