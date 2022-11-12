using APPZ.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPZ.Core.Interfaces
{
    public interface INotificationService
    {
        public Task<NotificationEntity> GetNotification(Guid id);
        public Task<IEnumerable<NotificationEntity>> GetNotifications();
    }
}
