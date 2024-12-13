using System;
using System.Linq;
using System.Windows.Forms;
using NotifierManager.Core.Interfaces;
using NotifierManager.Core.Models;
using NotifierManager.Data.Context;
using NotifierManager.Data.Services;

namespace NotifierManager.WinForms.Forms
{
    public partial class AddNotificationForm : Form
    {
        private readonly ICategoryService _categoryService;
        private readonly NotifierDbContext _dbContext;

        // Notification property'sini public olarak tanımlayalım
        public Notification Notification { get; private set; }

        public AddNotificationForm()
        {
            InitializeComponent();

            // İlk oluştuğunda Notification null olmasın
            Notification = new Notification();

            _dbContext = new NotifierDbContext();
            _categoryService = new CategoryService(_dbContext);

            InitializeForm();
        }

        private void InitializeForm()
        {
            // Öncelik değerlerini doldur
            cmbPriority.DataSource = Enum.GetValues(typeof(NotificationPriority));

            // Kategorileri doldur
            var categories = _categoryService.GetAllCategories().ToList();
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";

            // Varsayılan değerler
            dtpNotificationTime.Value = DateTime.Now.AddMinutes(5);
            cmbPriority.SelectedItem = NotificationPriority.Medium;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateForm())
                {
                    var displaySettings = new DisplaySettings
                    {
                        Position = NotificationPosition.TopRight,
                        DisplayDurationSeconds = 5,
                        EnableAnimation = true,
                        Opacity = 1.0,
                        BackgroundColor = "#FFFFFF"
                    };

                    Notification = new Notification
                    {
                        Title = txtTitle.Text.Trim(),
                        Message = txtMessage.Text.Trim(),
                        NotificationTime = dtpNotificationTime.Value,
                        CreatedAt = DateTime.Now,
                        IsActive = true,
                        Priority = (NotificationPriority)cmbPriority.SelectedItem,
                        CategoryId = (int)cmbCategory.SelectedValue
                    };

                    // DisplaySettings'i ayrı atayalım
                    Notification.DisplaySettings = displaySettings;

                    // Debug için kontrol edelim
                    if (Notification != null)
                    {
                        MessageBox.Show(
                            $"Debug - Notification oluşturuldu:\n" +
                            $"Title: {Notification.Title}\n" +
                            $"CategoryId: {Notification.CategoryId}\n" +
                            $"IsNull: {Notification == null}",
                            "Debug Bilgisi",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Hata Detayı:\n{ex.Message}\n\n" +
                    $"Stack Trace:\n{ex.StackTrace}",
                    "Hata",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Lütfen bir başlık girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                MessageBox.Show("Lütfen bir mesaj girin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMessage.Focus();
                return false;
            }

            if (dtpNotificationTime.Value < DateTime.Now)
            {
                MessageBox.Show("Bildirim zamanı geçmiş bir zaman olamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNotificationTime.Focus();
                return false;
            }

            if (cmbCategory.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir kategori seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _dbContext.Dispose();
        }
    }
}
