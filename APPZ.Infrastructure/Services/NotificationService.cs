using APPZ.Core.Entities;
using APPZ.Core.Interfaces;
using Microsoft.Extensions.Configuration;
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
        IConfiguration _configuration;
        public INotifyOrgStrategy Strategy { get; set; }
        public NotificationService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<IEnumerable<NotificationEntity>> GetNotifications()
        {
            return await _unitOfWork.NotifcationsRepository.GetAll(CancellationToken.None);
        }

        public Task<NotificationEntity> GetNotification(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task NotificateOrganisation(OrganisationDetails organisationDetails, string message, CancellationToken cancellationToken)
        {
            await Strategy.SendNotification(organisationDetails, message, _configuration, cancellationToken);
        }
    }
}
