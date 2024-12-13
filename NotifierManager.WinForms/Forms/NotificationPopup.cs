using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NotifierManager.Core.Models;

namespace NotifierManager.WinForms.Forms
{
    public partial class NotificationPopup : Form
    {
        private Timer fadeTimer = new Timer();
        private double opacity = 1.0;
        private bool isClosing = false;

        public NotificationPopup(Notification notification)
        {
            InitializeComponent();

            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            ShowInTaskbar = false;
            TopMost = true;
            Opacity = opacity;

            // İçeriği ayarla
            lblTitle.Text = notification.Title;
            lblMessage.Text = notification.Message;

            // Kategori kontrolü ekleyelim
            lblCategory.Text = notification.Category?.Name ?? "Kategori Yok";

            // Arka plan rengini ayarla - kategori null kontrolü
            if (notification.Category != null && !string.IsNullOrEmpty(notification.Category.ColorHex))
            {
                BackColor = ColorTranslator.FromHtml(notification.Category.ColorHex);
            }
            else
            {
                BackColor = Color.LightGray; // Varsayılan renk
            }

            // Konumu ayarla
            SetPosition(notification.DisplaySettings.Position);

            // Fade-out efekti için timer
            fadeTimer.Interval = 50;
            fadeTimer.Tick += FadeTimer_Tick;

            // Mouse tıklaması ile kapatma
            this.Click += (s, e) => CloseNotification();

            // 5 saniye sonra fade-out başlat
            Timer closeTimer = new Timer();
            closeTimer.Interval = 5000;
            closeTimer.Tick += (s, e) =>
            {
                closeTimer.Stop();
                if (!isClosing) StartFadeOut();
            };
            closeTimer.Start();
        }
        private void SetPosition(NotificationPosition position)
        {
            var screen = Screen.PrimaryScreen.WorkingArea;
            switch (position)
            {
                case NotificationPosition.TopRight:
                    Location = new Point(screen.Right - Width - 10, screen.Top + 10);
                    break;
                case NotificationPosition.TopLeft:
                    Location = new Point(screen.Left + 10, screen.Top + 10);
                    break;
                case NotificationPosition.BottomRight:
                    Location = new Point(screen.Right - Width - 10, screen.Bottom - Height - 10);
                    break;
                case NotificationPosition.BottomLeft:
                    Location = new Point(screen.Left + 10, screen.Bottom - Height - 10);
                    break;
                case NotificationPosition.Center:
                    Location = new Point((screen.Width - Width) / 2, (screen.Height - Height) / 2);
                    break;
            }
        }

        private void StartFadeOut()
        {
            isClosing = true;
            fadeTimer.Start();
        }

        private void CloseNotification()
        {
            if (!isClosing)
            {
                isClosing = true;
                StartFadeOut();
            }
        }

        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            opacity -= 0.05;
            if (opacity <= 0)
            {
                fadeTimer.Stop();
                Close();
                return;
            }
            Opacity = opacity;
        }
    }
}
