using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NotifierManager.Data.Services;

namespace NotifierManager.WinForms.Forms
{
    public partial class StatisticsForm : Form
    {
        private readonly NotificationService _notificationService;

        public StatisticsForm(NotificationService notificationService)
        {
            InitializeComponent();
            _notificationService = notificationService;
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            var notifications = _notificationService.GetAll().ToList();

            var generalStats = new List<object[]>
        {
            new object[] { "Toplam Bildirim", notifications.Count() },
            new object[] { "Aktif Bildirim", notifications.Count(n => n.IsActive) },
            new object[] { "Tamamlanan Bildirim", notifications.Count(n => !n.IsActive) },
            new object[] { "Tekrarlayan Bildirim", notifications.Count(n => n.IsRepeating) }
        };

            dgvGeneralStats.Columns.Clear();
            dgvGeneralStats.Columns.Add("Metrik", "Metrik");
            dgvGeneralStats.Columns.Add("Deger", "Değer");

            foreach (var stat in generalStats)
            {
                dgvGeneralStats.Rows.Add(stat[0], stat[1]);
            }

            // Kategori dağılımı için Chart kullanımını ekleyelim
            var categories = notifications
                .GroupBy(n => n.Category?.Name ?? "Kategorisiz")
                .Select(g => new
                {
                    Category = g.Key,
                    Count = g.Count()
                })
                .ToList();

            chartCategories.Series.Clear();
            var series = chartCategories.Series.Add("Categories");
            series.ChartType = SeriesChartType.Pie;

            foreach (var category in categories)
            {
                series.Points.AddXY(category.Category, category.Count);
            }

            // Öncelik dağılımı
            var priorities = notifications
                .GroupBy(n => n.Priority)
                .Select(g => new
                {
                    Priority = g.Key,
                    Count = g.Count()
                })
                .OrderBy(x => x.Priority)
                .ToList();

            chartPriority.Series.Clear();
            var prioritySeries = chartPriority.Series.Add("Priorities");
            prioritySeries.ChartType = SeriesChartType.Column;

            foreach (var priority in priorities)
            {
                prioritySeries.Points.AddXY(priority.Priority.ToString(), priority.Count);
            }
        }
    }
}
