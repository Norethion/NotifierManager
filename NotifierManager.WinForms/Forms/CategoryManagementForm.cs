using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using NotifierManager.Core.Interfaces;
using NotifierManager.Core.Models;
using NotifierManager.Data.Context;
using NotifierManager.Data.Services;

namespace NotifierManager.WinForms.Forms
{
    public partial class CategoryManagementForm : Form
    {
        private readonly ICategoryService _categoryService;
        private readonly NotifierDbContext _dbContext;
        private Color selectedColor = Color.White;

        public CategoryManagementForm()
        {
            InitializeComponent();
            _dbContext = new NotifierDbContext();
            _categoryService = new CategoryService(_dbContext);

            InitializeDataGridView();
            LoadCategories();
        }

        private void InitializeDataGridView()
        {
            dgvCategories.AutoGenerateColumns = false;

            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Name",
                HeaderText = "Kategori Adı",
                Name = "colName",
                Width = 200
            });

            dgvCategories.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ColorHex",
                HeaderText = "Renk Kodu",
                Name = "colColor",
                Width = 100
            });

            // Renk önizleme kolonu
            var colorPreviewColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Renk",
                Name = "colColorPreview",
                Width = 60
            };
            dgvCategories.Columns.Add(colorPreviewColumn);
            dgvCategories.CellPainting += DgvCategories_CellPainting;
        }

        private void DgvCategories_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dgvCategories.Columns["colColorPreview"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);
                using (var brush = new SolidBrush(ColorTranslator.FromHtml(dgvCategories.Rows[e.RowIndex].Cells["colColor"].Value.ToString())))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds.X + 2, e.CellBounds.Y + 2,
                        e.CellBounds.Width - 4, e.CellBounds.Height - 4);
                }
                e.Handled = true;
            }
        }

        private void LoadCategories()
        {
            dgvCategories.DataSource = _categoryService.GetAllCategories().ToList();
        }

        private void btnSelectColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedColor = colorDialog1.Color;
                pnlColorPreview.BackColor = selectedColor;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Lütfen kategori adı girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var category = new Category
            {
                Name = txtCategoryName.Text.Trim(),
                ColorHex = ColorTranslator.ToHtml(selectedColor)
            };

            if (_categoryService.CreateCategory(category))
            {
                LoadCategories();
                ClearInputs();
                MessageBox.Show("Kategori başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kategori eklenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count > 0)
            {
                var category = (Category)dgvCategories.SelectedRows[0].DataBoundItem;
                if (MessageBox.Show($"{category.Name} kategorisini silmek istediğinize emin misiniz?",
                    "Kategori Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_categoryService.DeleteCategory(category.Id))
                    {
                        LoadCategories();
                        MessageBox.Show("Kategori başarıyla silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Kategori silinirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ClearInputs()
        {
            txtCategoryName.Clear();
            selectedColor = Color.White;
            pnlColorPreview.BackColor = selectedColor;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _dbContext.Dispose();
        }
    }
}
