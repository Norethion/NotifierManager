using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotifierManager.Core.Models;

namespace NotifierManager.Core.Interfaces
{
    public interface INotificationService
    {
        bool CreateNotification(Notification notification);
        bool UpdateNotification(Notification notification);
        bool DeleteNotification(int id);
        Notification GetNotification(int id);
        IEnumerable<Notification> GetActiveNotifications();
        IEnumerable<Notification> GetNotificationsByCategory(int categoryId);
    }
}
