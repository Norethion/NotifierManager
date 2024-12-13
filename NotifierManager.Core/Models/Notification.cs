﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NotifierManager.Core.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime NotificationTime { get; set; }
        public bool IsActive { get; set; }
        public NotificationPriority Priority { get; set; }
        public int CategoryId { get; set; }

        [NotMapped]
        public DisplaySettings DisplaySettings
        {
            get => string.IsNullOrEmpty(DisplaySettingsJson)
                ? new DisplaySettings()
                : JsonConvert.DeserializeObject<DisplaySettings>(DisplaySettingsJson);
            set => DisplaySettingsJson = JsonConvert.SerializeObject(value);
        }

        public string DisplaySettingsJson { get; set; }

        public virtual Category Category { get; set; }
    }

    public enum NotificationPriority
    {
        Low,
        Medium,
        High
    }
}