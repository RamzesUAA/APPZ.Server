using APPZ.Core.Entities;
using APPZ.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace APPZ.Infrastructure.Implementations
{
    public class NotificationService : INotificationService
    {
        IUnitOfWork _unitOfWork;
        public INotifyOrgStrategy Strategy { get; set; }
        public NotificationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<NotificationEntity>> GetNotifications(CancellationToken cancellationToken)
        {
            return await _unitOfWork.NotifcationsRepository.GetAll(cancellationToken);
        }

        public async Task<NotificationEntity> GetNotification(Guid id, CancellationToken cancellationToken)
        {
            return await _unitOfWork.NotifcationsRepository.GetById(id, cancellationToken);
        }
        public async Task<IEnumerable<NotificationEntity>> GetNotificationsForUser(Guid userId, CancellationToken cancellationToken)
        {
            return await _unitOfWork.NotifcationsRepository.DbSet.Where(item => item.ToUserId == userId).ToListAsync(cancellationToken);
        }

        public async Task NotificateOrganisation(OrganisationDetails organisationDetails, string message, CancellationToken cancellationToken)
        {
            await Strategy.SendNotification(organisationDetails, message, cancellationToken);
        }
    }
}
