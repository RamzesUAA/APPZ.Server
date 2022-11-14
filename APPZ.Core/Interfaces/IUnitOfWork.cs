using APPZ.Core.Entities;

namespace APPZ.Core.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<NotificationEntity> NotifcationsRepository { get; set; }
        IGenericRepository<UserEntity> UserRepository { get; }
        IGenericRepository<RequestEntity> RequestRepository { get; }
        IGenericRepository<OrganisationNotifications> OrganisationNotificationsRepository { get; }
        IGenericRepository<OrganisationDetails> OrganisationDetailsRepository { get; }
        Task SaveChangesAsync(CancellationToken cancel);
    }
}
