using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using NotifierManager.Core.Interfaces;
using NotifierManager.Core.Models;
using NotifierManager.Data.Context;
using NotifierManager.Data.Repository;

namespace NotifierManager.Data.Services
{
    public class NotificationService : INotificationService
    {
        private readonly NotifierDbContext _context;
        private readonly Repository<Notification> _repository;

        public NotificationService(NotifierDbContext context)
        {
            _context = context;
            _repository = new Repository<Notification>(context);
        }

        public bool CreateNotification(Notification notification)
        {
            try
            {
                if (notification == null)
                {
                    MessageBox.Show("Notification objesi null!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Tüm gerekli alanları kontrol edelim
                var debugInfo = $"Notification Detayları:\n" +
                               $"Title: {notification.Title}\n" +
                               $"Message: {notification.Message}\n" +
                               $"CategoryId: {notification.CategoryId}\n" +
                               $"NotificationTime: {notification.NotificationTime}\n" +
                               $"Priority: {notification.Priority}\n" +
                               $"DisplaySettings: {notification.DisplaySettingsJson}";

                MessageBox.Show(debugInfo, "Debug Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                _repository.Add(notification);
                _repository.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"CreateNotification Hatası:\n" +
                               $"Message: {ex.Message}\n" +
                               $"Inner Exception: {ex.InnerException?.Message}\n" +
                               $"Stack Trace: {ex.StackTrace}",
                    "Hata Detayı",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        public bool DeleteNotification(int id)
        {
            try
            {
                var notification = _repository.GetById(id);
                if (notification != null)
                {
                    _repository.Delete(notification);
                    _repository.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Notification> GetActiveNotifications()
        {
            return _context.Notifications
                .Include(n => n.Category)
                .Where(n => n.IsActive)
                .ToList();
        }

        public Notification GetNotification(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<Notification> GetNotificationsByCategory(int categoryId)
        {
            return _repository.GetAll().Where(n => n.CategoryId == categoryId);
        }

        public bool UpdateNotification(Notification notification)
        {
            try
            {
                _repository.Update(notification);
                _repository.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}