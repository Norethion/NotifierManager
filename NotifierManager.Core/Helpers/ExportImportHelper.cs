using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NotifierManager.Core.Models;

namespace NotifierManager.Core.Helpers
{
    public class NotificationExportData
    {
        public List<Notification> Notifications { get; set; }
        public List<Category> Categories { get; set; }
    }

    public static class ExportImportHelper
    {
        public static string ExportToJson(List<Notification> notifications, List<Category> categories)
        {
            var settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            };

            var exportData = new NotificationExportData
            {
                Notifications = notifications.Select(n => new Notification
                {
                    Id = n.Id,
                    Title = n.Title,
                    Message = n.Message,
                    CreatedAt = n.CreatedAt,
                    NotificationTime = n.NotificationTime,
                    IsActive = n.IsActive,
                    Priority = n.Priority,
                    CategoryId = n.CategoryId,
                    DisplaySettingsJson = n.DisplaySettingsJson,
                    EnableSound = n.EnableSound,
                    SoundPath = n.SoundPath,
                    IsRepeating = n.IsRepeating,
                    RepeatPattern = n.RepeatPattern,
                    LastRepeatDate = n.LastRepeatDate
                }).ToList(),
                Categories = categories.Select(c => new Category
                {
                    Id = c.Id,
                    Name = c.Name,
                    ColorHex = c.ColorHex
                }).ToList()
            };

            return JsonConvert.SerializeObject(exportData, settings);
        }

        public static NotificationExportData ImportFromJson(string json)
        {
            return JsonConvert.DeserializeObject<NotificationExportData>(json);
        }
    }
}
