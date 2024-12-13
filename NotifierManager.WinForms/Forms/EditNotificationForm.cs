using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NotifierManager.Core.Interfaces;
using NotifierManager.Core.Models;
using NotifierManager.Data.Context;
using NotifierManager.Data.Services;

namespace NotifierManager.WinForms.Forms
{
    public partial class EditNotificationForm : Form
    {
        private readonly ICategoryService _categoryService;
        private readonly NotifierDbContext _dbContext;
        public Notification Notification { get; private set; }
        private string selectedSoundPath;

        public EditNotificationForm(Notification notification)
        {
            InitializeComponent();

            _dbContext = new NotifierDbContext();
            _categoryService = new CategoryService(_dbContext);

            Notification = notification;
            selectedSoundPath = notification.SoundPath;
            LoadCategories();
            LoadPriorities();
            LoadNotificationData();
            InitializeSoundControls();
        }
        private void InitializeSoundControls()
        {
            chkEnableSound.Checked = Notification.EnableSound;
            btnSelectSound.Enabled = chkEnableSound.Checked;
            lblSelectedSound.Text = "Seçili Ses: " +
                (string.IsNullOrEmpty(Notification.SoundPath) ? "Yok" : Path.GetFileName(Notification.SoundPath));
        }
        private void LoadCategories()
        {
            var categories = _categoryService.GetAllCategories().ToList();
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "Id";
        }

        private void LoadPriorities()
        {
            cmbPriority.DataSource = Enum.GetValues(typeof(NotificationPriority));
        }

        private void LoadNotificationData()
        {
            txtTitle.Text = Notification.Title;
            txtMessage.Text = Notification.Message;
            dtpNotificationTime.Value = Notification.NotificationTime;
            cmbCategory.SelectedValue = Notification.CategoryId;
            cmbPriority.SelectedItem = Notification.Priority;

            // Tekrarlama ayarlarını yükle
            chkRepeat.Checked = Notification.IsRepeating;
            if (Notification.IsRepeating && !string.IsNullOrEmpty(Notification.RepeatPattern))
            {
                cmbRepeatPattern.SelectedItem = Notification.RepeatPattern;
            }

            // Ses ayarlarını güncelle
            chkEnableSound.Checked = Notification.EnableSound;
            if (Notification.EnableSound && !string.IsNullOrEmpty(Notification.SoundPath))
            {
                selectedSoundPath = Notification.SoundPath;
                lblSelectedSound.Text = "Seçili Ses: " + Path.GetFileName(Notification.SoundPath);
            }

            UpdateNextRepeatDate(); // Sonraki tekrar tarihini güncelle
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                Notification.Title = txtTitle.Text.Trim();
                Notification.Message = txtMessage.Text.Trim();
                Notification.NotificationTime = dtpNotificationTime.Value;
                Notification.CategoryId = (int)cmbCategory.SelectedValue;
                Notification.Priority = (NotificationPriority)cmbPriority.SelectedItem;
                Notification.EnableSound = chkEnableSound.Checked;
                Notification.SoundPath = selectedSoundPath;
                Notification.IsRepeating = chkRepeat.Checked;
                if (chkRepeat.Checked)
                    Notification.RepeatPattern = cmbRepeatPattern.SelectedItem.ToString();

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Lütfen bir başlık girin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                MessageBox.Show("Lütfen bir mesaj girin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMessage.Focus();
                return false;
            }

            if (dtpNotificationTime.Value < DateTime.Now)
            {
                MessageBox.Show("Bildirim zamanı geçmiş bir zaman olamaz.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNotificationTime.Focus();
                return false;
            }

            if (cmbCategory.SelectedValue == null)
            {
                MessageBox.Show("Lütfen bir kategori seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCategory.Focus();
                return false;
            }

            return true;
        }
        private void chkEnableSound_CheckedChanged(object sender, EventArgs e)
        {
            btnSelectSound.Enabled = chkEnableSound.Checked;
            if (!chkEnableSound.Checked)
            {
                selectedSoundPath = null;
                lblSelectedSound.Text = "Seçili Ses: Yok";
            }
        }
        private void btnSelectSound_Click(object sender, EventArgs e)
        {
            if (ofdSound.ShowDialog() == DialogResult.OK)
            {
                selectedSoundPath = ofdSound.FileName;
                lblSelectedSound.Text = "Seçili Ses: " + Path.GetFileName(selectedSoundPath);

                // Sesi test et
                using (var player = new System.Media.SoundPlayer(selectedSoundPath))
                {
                    try
                    {
                        player.Play();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ses dosyası oynatılırken hata oluştu: " + ex.Message,
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void chkRepeat_CheckedChanged(object sender, EventArgs e)
        {
            cmbRepeatPattern.Enabled = chkRepeat.Checked;
            if (chkRepeat.Checked && cmbRepeatPattern.SelectedIndex == -1)
                cmbRepeatPattern.SelectedIndex = 0;
            UpdateNextRepeatDate();
        }

        private void cmbRepeatPattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateNextRepeatDate();
        }

        private void UpdateNextRepeatDate()
        {
            if (!chkRepeat.Checked)
            {
                lblNextRepeat.Text = "Sonraki tekrar: -";
                return;
            }

            DateTime nextDate = dtpNotificationTime.Value;
            switch (cmbRepeatPattern.SelectedItem?.ToString())
            {
                case "Her Gün":
                    nextDate = nextDate.AddDays(1);
                    break;
                case "Her Hafta":
                    nextDate = nextDate.AddDays(7);
                    break;
                case "Her Ay":
                    nextDate = nextDate.AddMonths(1);
                    break;
            }

            lblNextRepeat.Text = $"Sonraki tekrar: {nextDate:dd.MM.yyyy HH:mm}";
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            _dbContext.Dispose();
        }
    }
}
