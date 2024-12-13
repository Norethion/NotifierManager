using System;
using System.Linq;
using System.Windows.Forms;
using NotifierManager.Core.Models;
using NotifierManager.Data.Context;
using NotifierManager.Data.Services;
using System.Drawing;
using NotifierManager.WinForms.Forms;

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

            InitializeNotifyIcon();
            InitializeToolStrip();
            InitializeDataGridView();
            InitializeNotificationTimer();
            LoadNotifications();
        }
        private void InitializeNotifyIcon()
        {
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Icon = SystemIcons.Application;
            _notifyIcon.Text = "Notifier Manager";
            _notifyIcon.Visible = true;
            _notifyIcon.DoubleClick += NotifyIcon_DoubleClick;

            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Göster", null, (s, e) => { Show(); WindowState = FormWindowState.Normal; });
            contextMenu.Items.Add("Yeni Bildirim", null, TsbNewNotification_Click);
            contextMenu.Items.Add("Kategoriler", null, TsbCategories_Click);
            contextMenu.Items.Add("Ayarlar", null, TsbSettings_Click);
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

            // Durum ikonunu göstermek için
            dgvNotifications.CellPainting += (s, e) =>
            {
                if (e.ColumnIndex == dgvNotifications.Columns["colStatus"].Index && e.RowIndex >= 0)
                {
                    var notification = (Notification)dgvNotifications.Rows[e.RowIndex].DataBoundItem;
                    e.PaintBackground(e.CellBounds, true);
                    var icon = notification.NotificationTime > DateTime.Now ?
                        SystemIcons.Information : SystemIcons.Exclamation;
                    e.Graphics.DrawIcon(icon, e.CellBounds.X + 2, e.CellBounds.Y + 2);
                    e.Handled = true;
                }
            };
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

        private void NotificationCheckTimer_Tick(object sender, EventArgs e)
        {
            var now = DateTime.Now;
            var pendingNotifications = _notificationService.GetActiveNotifications()
                .Where(n => n.NotificationTime <= now && n.NotificationTime > now.AddSeconds(-10))
                .ToList();

            foreach (var notification in pendingNotifications)
            {
                ShowNotification(notification);
                // Bildirimi pasif yap
                notification.IsActive = false;
                _notificationService.UpdateNotification(notification);
            }

            // DataGridView'i güncelle
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
            // Yeni Bildirim butonu için event handler
            tsbNewNotification.Click += TsbNewNotification_Click;

            // Kategoriler butonu için event handler
            tsbCategories.Click += TsbCategories_Click;

            // Ayarlar butonu için event handler
            tsbSettings.Click += TsbSettings_Click;
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
