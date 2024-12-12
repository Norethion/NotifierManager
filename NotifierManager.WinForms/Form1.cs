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

            // Servislerimizi başlat
            var dbContext = new NotifierDbContext();
            _notificationService = new NotificationService(dbContext);
            _categoryService = new CategoryService(dbContext);

            InitializeNotifyIcon();
            InitializeToolStrip();
            InitializeDataGridView();
            LoadNotifications();
        }
        private void InitializeNotifyIcon()
        {
            _notifyIcon = new NotifyIcon();
            _notifyIcon.Icon = SystemIcons.Application;
            _notifyIcon.Text = "Notifier Manager";
            _notifyIcon.Visible = true;
            _notifyIcon.DoubleClick += NotifyIcon_DoubleClick;

            // Context menu for notify icon
            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Open", null, (s, e) => { Show(); WindowState = FormWindowState.Normal; });
            contextMenu.Items.Add("Exit", null, (s, e) => Application.Exit());
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

            // Kolonları manuel olarak ekle
            dgvNotifications.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Title",
                HeaderText = "Başlık",
                Name = "colTitle"
            });

            dgvNotifications.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Message",
                HeaderText = "Mesaj",
                Name = "colMessage"
            });

            dgvNotifications.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NotificationTime",
                HeaderText = "Bildirim Zamanı",
                Name = "colTime",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd.MM.yyyy HH:mm" }
            });

            dgvNotifications.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Category.Name",
                HeaderText = "Kategori",
                Name = "colCategory"
            });

            // Sağ tıklama menüsü
            var contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Düzenle", null, OnEditNotification);
            contextMenu.Items.Add("Sil", null, OnDeleteNotification);
            dgvNotifications.ContextMenuStrip = contextMenu;

            // Event handlers
            dgvNotifications.CellDoubleClick += DgvNotifications_CellDoubleClick;
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
                    if (_notificationService.CreateNotification(notification))
                    {
                        LoadNotifications(); // DataGridView'i yenile
                        MessageBox.Show("Bildirim başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Bildirim eklenirken bir hata oluştu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void TsbCategories_Click(object sender, EventArgs e)
        {
            // TODO: Kategori yönetim formu açılacak
            MessageBox.Show("Kategori yönetim formu açılacak.");
        }

        private void TsbSettings_Click(object sender, EventArgs e)
        {
            // TODO: Ayarlar formu açılacak
            MessageBox.Show("Ayarlar formu açılacak.");
        }
    }
}
