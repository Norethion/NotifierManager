using System;
using System.Linq;
using System.Windows.Forms;
using NotifierManager.Core.Models;
using NotifierManager.Data.Context;
using NotifierManager.Data.Services;
using System.Drawing;
using NotifierManager.WinForms.Forms;
using NotifierManager.Core.Helpers;
using System.IO;
using NotifierManager.WinForms.Properties;

namespace NotifierManager.WinForms
{
    public partial class Form1 : Form
    {
        private readonly NotificationService _notificationService;
        private readonly CategoryService _categoryService;
        private NotifyIcon _notifyIcon;

        public Form1()
        {
            InitializeComponent();

            var dbContext = new NotifierDbContext();
            _notificationService = new NotificationService(dbContext);
            _categoryService = new CategoryService(dbContext);
            tsbVersion.Text = AppVersion.FullVersion;

            InitializeNotifyIcon();
            InitializeToolStrip();
            InitializeDataGridView();
            InitializeNotificationTimer();
            LoadNotifications();

            this.Resize += Form1_Resize;
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            var settings = Settings.Default;

            if (settings.MinimizeToTray && WindowState == FormWindowState.Minimized)
            {
                Hide();
                _notifyIcon.Visible = true;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                Show();
                _notifyIcon.Visible = false;
            }
        }
        private void InitializeNotifyIcon()
        {
            string imagePath = Path.Combine(Application.StartupPath, "..", "..", "Icons", "notification.ico");
            imagePath = Path.GetFullPath(imagePath);
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Icon = new Icon(imagePath);
            _notifyIcon.Text = "Notifier Manager";
            _notifyIcon.Visible = true;
            _notifyIcon.DoubleClick += NotifyIcon_DoubleClick;

            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Göster", null, (s, e) => { Show(); WindowState = FormWindowState.Normal; });
            contextMenu.Items.Add("Ayarlar", null, TsbSettings_Click);
            contextMenu.Items.Add("-");
            contextMenu.Items.Add("Versiyon: " + AppVersion.Version, null, null).Enabled = false;
            contextMenu.Items.Add("-");
            contextMenu.Items.Add("Çıkış", null, (s, e) => Application.Exit());

            _notifyIcon.ContextMenuStrip = contextMenu;
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }
        private void InitializeDataGridView()
        {
            dgvNotifications.AutoGenerateColumns = false;
            dgvNotifications.RowTemplate.Height = 35;
            dgvNotifications.Font = new Font("Segoe UI", 9F);
            dgvNotifications.Columns.Add(new DataGridViewImageColumn
            {
                Name = "colStatus",
                HeaderText = "",
                Width = 30,
            });

            dgvNotifications.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Title",
                HeaderText = "Başlık",
                Name = "colTitle",
                Width = 150
            });

            dgvNotifications.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Message",
                HeaderText = "Mesaj",
                Name = "colMessage",
                Width = 200
            }); 

            dgvNotifications.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NotificationTime",
                HeaderText = "Bildirim Zamanı",
                Name = "colTime",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy HH:mm" }
            });

            dgvNotifications.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Category.Name",
                HeaderText = "Kategori",
                Name = "colCategory",
                Width = 100
            });

            dgvNotifications.CellPainting += (s, e) =>
            {
                if (e.ColumnIndex == dgvNotifications.Columns["colStatus"].Index && e.RowIndex >= 0)
                {
                    e.PaintBackground(e.CellBounds, true); 
                    var notification = (Notification)dgvNotifications.Rows[e.RowIndex].DataBoundItem;

                    var icon = notification.NotificationTime > DateTime.Now
                        ? SystemIcons.Information
                        : SystemIcons.Exclamation;

                    int iconWidth = e.CellBounds.Width / 2;
                    int iconHeight = e.CellBounds.Height / 2;

                    using (var smallIcon = new Icon(icon, iconWidth, iconHeight))
                    {
                        int x = e.CellBounds.X + (e.CellBounds.Width - smallIcon.Width) / 2;
                        int y = e.CellBounds.Y + (e.CellBounds.Height - smallIcon.Height) / 2;

                        e.Graphics.DrawIcon(smallIcon, x, y);
                    }

                    e.Handled = true; 
                }
            };


            var editColumn = new DataGridViewButtonColumn
            {
                Name = "colEdit",
                HeaderText = "",
                Text = "Düzenle",
                UseColumnTextForButtonValue = true,
                Width = 70
            };
            dgvNotifications.Columns.Add(editColumn);

            var deleteColumn = new DataGridViewButtonColumn
            {
                Name = "colDelete",
                HeaderText = "",
                Text = "Sil",
                UseColumnTextForButtonValue = true,
                Width = 50
            };
            dgvNotifications.Columns.Add(deleteColumn);
            
            // CellClick event'ini ekleyelim
            dgvNotifications.CellClick += DgvNotifications_CellClick;
        }
        private void DgvNotifications_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Düzenle butonuna tıklanıp tıklanmadığını kontrol et
            if (e.ColumnIndex == dgvNotifications.Columns["colEdit"].Index && e.RowIndex >= 0)
            {
                var notification = (Notification)dgvNotifications.Rows[e.RowIndex].DataBoundItem;
                EditNotification(notification);
            }
            // Sil butonuna tıklandığında
            if (e.ColumnIndex == dgvNotifications.Columns["colDelete"].Index && e.RowIndex >= 0)
            {
                var notification = (Notification)dgvNotifications.Rows[e.RowIndex].DataBoundItem;

                if (MessageBox.Show("Bu bildirimi silmek istediğinizden emin misiniz?",
                    "Bildirim Sil",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_notificationService.DeleteNotification(notification.Id))
                    {
                        LoadNotifications();
                        MessageBox.Show("Bildirim başarıyla silindi.",
                            "Başarılı",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Bildirim silinirken bir hata oluştu.",
                            "Hata",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void EditNotification(Notification notification)
        {
            using (var form = new EditNotificationForm(notification))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _notificationService.UpdateNotification(form.Notification);
                    LoadNotifications();
                }
            }
        }
        private Timer notificationCheckTimer;

        // Constructor'a eklenecek
        private void InitializeNotificationTimer()
        {
            notificationCheckTimer = new Timer();
            notificationCheckTimer.Interval = 10000; // 10 saniye
            notificationCheckTimer.Tick += NotificationCheckTimer_Tick;
            notificationCheckTimer.Start();
        }
        private void CreateNextNotification(Notification currentNotification)
        {
            if (!currentNotification.IsRepeating) return;

            DateTime nextDate = currentNotification.NotificationTime;
            switch (currentNotification.RepeatPattern)
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

            var newNotification = new Notification
            {
                Title = currentNotification.Title,
                Message = currentNotification.Message,
                NotificationTime = nextDate,
                CategoryId = currentNotification.CategoryId,
                Priority = currentNotification.Priority,
                IsActive = true,
                IsRepeating = true,
                RepeatPattern = currentNotification.RepeatPattern,
                EnableSound = currentNotification.EnableSound,
                SoundPath = currentNotification.SoundPath,
                CreatedAt = DateTime.Now,
                DisplaySettingsJson = currentNotification.DisplaySettingsJson
            };

            _notificationService.CreateNotification(newNotification);
        }
        private void NotificationCheckTimer_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            var pendingNotifications = _notificationService.GetActiveNotifications()
                .Where(n => n.NotificationTime <= now && n.NotificationTime > now.AddSeconds(-10))
                .ToList();

            foreach (var notification in pendingNotifications)
            {
                ShowNotification(notification);

                if (notification.IsRepeating)
                {
                    CreateNextNotification(notification);
                }

                notification.IsActive = false;
                _notificationService.UpdateNotification(notification);
            }

            LoadNotifications();
        }
        private void ShowNotification(Notification notification)
        {
            var notificationForm = new NotificationPopup(notification);
            notificationForm.Show();
        }

        private void LoadNotifications()
        {
            var notifications = _notificationService.GetActiveNotifications().ToList();
            dgvNotifications.DataSource = notifications;
        }

        private void DgvNotifications_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var notification = (Notification)dgvNotifications.Rows[e.RowIndex].DataBoundItem;
                // TODO: Bildirim düzenleme formunu aç
            }
        }

        private void OnEditNotification(object sender, EventArgs e)
        {
            if (dgvNotifications.SelectedRows.Count > 0)
            {
                var notification = (Notification)dgvNotifications.SelectedRows[0].DataBoundItem;
                // TODO: Bildirim düzenleme formunu aç
            }
        }

        private void OnDeleteNotification(object sender, EventArgs e)
        {
            if (dgvNotifications.SelectedRows.Count > 0)
            {
                var notification = (Notification)dgvNotifications.SelectedRows[0].DataBoundItem;
                if (MessageBox.Show("Bu bildirimi silmek istediğinizden emin misiniz?", "Bildirim Sil",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (_notificationService.DeleteNotification(notification.Id))
                    {
                        LoadNotifications();
                    }
                    else
                    {
                        MessageBox.Show("Bildirim silinirken bir hata oluştu.", "Hata",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void InitializeToolStrip()
        {
            toolStripMain.Items.Add(new ToolStripSeparator());
            tsbNewNotification.Click += TsbNewNotification_Click;
            tsbCategories.Click += TsbCategories_Click;
            tsbStatistics.Click += TsbStatistics_Click;
            tsbExport.Click += TsbExport_Click;
            tsbImport.Click += TsbImport_Click;
            tsbSettings.Click += TsbSettings_Click;
        }

        private void TsbExport_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "JSON Dosyası (*.json)|*.json";
                sfd.Title = "Bildirimleri Dışa Aktar";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var notifications = _notificationService.GetAll().ToList();
                        var categories = _categoryService.GetAllCategories().ToList();

                        string json = ExportImportHelper.ExportToJson(notifications, categories);
                        File.WriteAllText(sfd.FileName, json);

                        MessageBox.Show("Veriler başarıyla dışa aktarıldı.", "Başarılı",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Dışa aktarma sırasında hata oluştu: {ex.Message}",
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void TsbImport_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "JSON Dosyası (*.json)|*.json";
                ofd.Title = "Bildirimleri İçe Aktar";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string json = File.ReadAllText(ofd.FileName);
                        var importData = ExportImportHelper.ImportFromJson(json);

                        if (MessageBox.Show("Mevcut veriler yeni verilerle değiştirilecek. Devam etmek istiyor musunuz?",
                            "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            // Önce mevcut kategorileri ekle
                            foreach (var category in importData.Categories)
                            {
                                // Id'yi sıfırla ki yeni kayıt olarak eklensin
                                category.Id = 0;
                                _categoryService.CreateCategory(category);
                            }

                            // Sonra bildirimleri ekle
                            foreach (var notification in importData.Notifications)
                            {
                                // Id'yi sıfırla ki yeni kayıt olarak eklensin
                                notification.Id = 0;
                                _notificationService.CreateNotification(notification);
                            }

                            LoadNotifications();
                            MessageBox.Show("Veriler başarıyla içe aktarıldı.", "Başarılı",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"İçe aktarma sırasında hata oluştu: {ex.Message}",
                            "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void TsbStatistics_Click(object sender, EventArgs e)
        {
            using (var statsForm = new StatisticsForm(_notificationService))
            {
                statsForm.ShowDialog();
            }
        }

        private void TsbNewNotification_Click(object sender, EventArgs e)
        {
            using (var addNotificationForm = new AddNotificationForm())
            {
                if (addNotificationForm.ShowDialog() == DialogResult.OK)
                {
                    var notification = addNotificationForm.Notification;

                    if (notification == null)
                    {
                        MessageBox.Show("Form'dan alınan notification null!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (_notificationService.CreateNotification(notification))
                    {
                        LoadNotifications();
                        MessageBox.Show("Bildirim başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void TsbCategories_Click(object sender, EventArgs e)
        {
            using (var categoryForm = new CategoryManagementForm())
            {
                categoryForm.ShowDialog();
                // Form kapandığında DataGridView'i yenile (eğer yeni bildirimler varsa kategorileri güncel göstersin)
                LoadNotifications();
            }
        }

        private void TsbSettings_Click(object sender, EventArgs e)
        {
            using (var settingsForm = new SettingsForm())
            {
                settingsForm.ShowDialog();
            }
        }
    }
}
