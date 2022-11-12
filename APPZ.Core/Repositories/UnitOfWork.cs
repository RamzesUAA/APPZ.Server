using System.Data;
using APPZ.Core.Entities;
using APPZ.Core.Interfaces;
using Npgsql;

namespace APPZ.Core.Repository
{
    public abstract class UnitOfWork : IUnitOfWork
    {
        private readonly MDBContext _context;
        private IGenericRepository<NotificationEntity> _notificationEntityRepository;
        private IGenericRepository<UserEntity> _userRepository;
        private IGenericRepository<RequestEntity> _requestRepository;
        private IGenericRepository<OrganisationNotifications> _organisationNotificationsRepository;
        private IGenericRepository<OrganisationDetails> _organisationDetailsRepository;
        public UnitOfWork(MDBContext context)
        {
            this._context = context;
        }
        public virtual IGenericRepository<OrganisationDetails> OrganisationDetailsRepository
        {
            get
            {
                if (this._organisationDetailsRepository == null)
                {
                    this._organisationDetailsRepository = new GenericRepository<OrganisationDetails>(_context);
                }
                return _organisationDetailsRepository;
            }
        }
        public virtual IGenericRepository<NotificationEntity> NotifcationsRepository
        {
            get
            {
                if (this._notificationEntityRepository == null)
                {
                    this._notificationEntityRepository = new GenericRepository<NotificationEntity>(_context);
                }
                return _notificationEntityRepository;
            }
        }
        public virtual IGenericRepository<OrganisationNotifications> OrganisationNotificationsRepository
        {
            get
            {
                if (this._organisationNotificationsRepository == null)
                {
                    this._organisationNotificationsRepository = new GenericRepository<OrganisationNotifications>(_context);
                }
                return _organisationNotificationsRepository;
            }
        }
        public IGenericRepository<UserEntity> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                {
                    this._userRepository = new GenericRepository<UserEntity>(_context);
                }
                return _userRepository;
            }
        }

        public IGenericRepository<RequestEntity> RequestRepository
        {
            get
            {
                if (this._requestRepository == null)
                {
                    this._requestRepository = new GenericRepository<RequestEntity>(_context);
                }
                return _requestRepository;
            }
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
