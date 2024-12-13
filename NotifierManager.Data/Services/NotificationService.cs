using System.Collections.Generic;
using System.Linq;
using NotifierManager.Core.Interfaces;
using NotifierManager.Core.Models;
using NotifierManager.Data.Context;
using NotifierManager.Data.Repository;

namespace NotifierManager.Data.Services
{
    public class NotificationService : INotificationService
    {
        private readonly Repository<Notification> _repository;

        public NotificationService(NotifierDbContext context)
        {
            _repository = new Repository<Notification>(context);
        }

        public bool CreateNotification(Notification notification)
        {
            try
            {
                _repository.Add(notification);
                _repository.SaveChanges();
                return true;
            }
            catch
            {
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
            return _repository.GetAll().Where(n => n.IsActive);
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