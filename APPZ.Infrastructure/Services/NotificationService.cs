using APPZ.Core.Entities;
using APPZ.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPZ.Infrastructure.Implementations
{
    public class NotificationService : INotificationService
    {
        IUnitOfWork _unitOfWork;
        public NotificationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<NotificationEntity>> GetNotifications()
        {
            return await _unitOfWork.NotifcationsRepository.GetAll(CancellationToken.None);
        }

        public Task<NotificationEntity> GetNotification(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
