using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotifierManager.Core.Models
{
    public class DisplaySettings
    {
        public NotificationPosition Position { get; set; }
        public int DisplayDurationSeconds { get; set; }
        public string BackgroundColor { get; set; }
        public double Opacity { get; set; }
        public bool EnableAnimation { get; set; }
    }
    public enum NotificationPosition
    {
        TopLeft,
        TopRight,
        BottomLeft,
        BottomRight,
        Center
    }
}
