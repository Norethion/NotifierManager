using System;
using System.IO;
using System.Windows.Forms;
using IWshRuntimeLibrary;
using NotifierManager.Core.Models;
using File = System.IO.File;

namespace NotifierManager.WinForms.Forms
{
    public partial class SettingsForm : Form
    {
        public bool StartWithWindows
        {
            get => chkStartWithWindows.Checked;
            private set => chkStartWithWindows.Checked = value;
        }

        public bool MinimizeToTray
        {
            get => chkMinimizeToTray.Checked;
            private set => chkMinimizeToTray.Checked = value;
        }

        public int NotificationDuration
        {
            get => (int)numNotificationDuration.Value;
            private set => numNotificationDuration.Value = value;
        }

        public NotificationPosition DefaultPosition
        {
            get => (NotificationPosition)cmbDefaultPosition.SelectedIndex;
            private set => cmbDefaultPosition.SelectedIndex = (int)value;
        }

        public SettingsForm()
        {
            InitializeComponent();
            InitializeControls();
            LoadSettings();
        }

        private void InitializeControls()
        {
            // ComboBox'a pozisyon değerlerini ekle
            cmbDefaultPosition.Items.AddRange(Enum.GetNames(typeof(NotificationPosition)));

            // NumericUpDown ayarları
            numNotificationDuration.Minimum = 1;
            numNotificationDuration.Maximum = 30;
        }

        private void LoadSettings()
        {
            // Windows başlangıç durumunu kontrol et
            var settings = Properties.Settings.Default;
            string startupPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Startup),
                "NotifierManager.lnk");

            chkStartWithWindows.Checked = File.Exists(startupPath);
            chkMinimizeToTray.Checked = settings.MinimizeToTray;
            numNotificationDuration.Value = settings.NotificationDuration;
            cmbDefaultPosition.SelectedIndex = (int)settings.DefaultPosition;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Ayarları kaydet
            var settings = Properties.Settings.Default;
            settings.StartWithWindows = StartWithWindows;
            settings.MinimizeToTray = MinimizeToTray;
            settings.NotificationDuration = NotificationDuration;
            settings.DefaultPosition = DefaultPosition;
            settings.Save();

            // Windows başlangıcına ekleme/çıkarma
            SetStartupWithWindows(StartWithWindows);

            DialogResult = DialogResult.OK;
            Close();
        }

        private void SetStartupWithWindows(bool enable)
        {
            string startupPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Startup),
                "NotifierManager.lnk");

            if (enable)
            {
                if (!File.Exists(startupPath))
                {
                    var shell = new WshShell();
                    var shortcut = (IWshShortcut)shell.CreateShortcut(startupPath);
                    shortcut.TargetPath = Application.ExecutablePath;
                    shortcut.WorkingDirectory = Application.StartupPath;
                    shortcut.Description = "Notifier Manager";
                    shortcut.Save();
                }
            }
            else
            {
                if (File.Exists(startupPath))
                {
                    File.Delete(startupPath);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
