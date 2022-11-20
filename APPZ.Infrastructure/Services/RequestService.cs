using APPZ.Core.Constants;
using APPZ.Core.DTO;
using APPZ.Core.Entities;
using APPZ.Core.Exceptions;
using APPZ.Core.Interfaces;
using APPZ.Infrastructure.Strategies;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APPZ.Infrastructure.Implementations
{
    public class RequestService : IRequestService
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;
        INotificationService _notificationService;
        public RequestService(IUnitOfWork unitOfWork, IMapper mapper, INotificationService notificationService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _notificationService = notificationService;
        }

        public async Task AddRequest(RequestCreateDTO request, CancellationToken cancellationToken)
        {
            var mapped = _mapper.Map<RequestEntity>(request);
            mapped.Id = Guid.NewGuid();
            mapped.DateCreated = DateTime.UtcNow;

            await _unitOfWork.RequestRepository.Create(mapped, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

        }

        public async Task<RequestReadDTO> GetRequest(Guid id, CancellationToken cancellationToken) =>
            _mapper.Map<RequestReadDTO>(await _unitOfWork.RequestRepository.GetById(id, cancellationToken));
        public async Task ProcessRequest(Guid id, Status status, CancellationToken cancellationToken)
        {
            var entity = (await _unitOfWork.RequestRepository.GetById(id, cancellationToken));

            entity.Status = status;

            _unitOfWork.RequestRepository.Update(entity);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
        public async Task<IEnumerable<RequestReadDTO>> GetRequestsByUserId(Guid userId, CancellationToken cancellationToken) =>
            _mapper.Map<IEnumerable<RequestReadDTO>>(await _unitOfWork.RequestRepository.DbSet.Where(item => item.UserId == userId).ToListAsync(cancellationToken));
        public async Task<IEnumerable<RequestReadDTO>> GetAllRequests(CancellationToken cancellationToken) =>
            _mapper.Map<IEnumerable<RequestReadDTO>>((await _unitOfWork.RequestRepository.GetAll(cancellationToken)));

        public async Task SendRequestsToOrganisation(Guid organisationId, List<Guid> requestIds, CancellationToken cancellationToken)
        {
            var organisationDetails = await _unitOfWork.OrganisationDetailsRepository.DbSet
                .Include(item => item.Organisation).FirstOrDefaultAsync(item => item.OrganisationId == organisationId, cancellationToken) ?? throw new HttpCodeException(HttpStatusCode.BadRequest);

            var organisationNotificationType = await _unitOfWork.OrganisationNotificationsRepository.DbSet
                .FirstOrDefaultAsync(item => item.OrgId == organisationId, cancellationToken) ?? throw new HttpCodeException(HttpStatusCode.BadRequest);

            switch (organisationNotificationType.Type)
            {
                case OrgNotification.Slack:
                    _notificationService.Strategy = new SlackNotifier();
                    break;
                case OrgNotification.Mail:
                    _notificationService.Strategy = new MailNotifier();
                    break;
                default:
                    throw new HttpCodeException(HttpStatusCode.BadRequest);
            }

            await _notificationService.NotificateOrganisation(organisationDetails, await GetInfoFromIDs(requestIds, cancellationToken), cancellationToken);
        }

        private async Task<string> GetInfoFromIDs(List<Guid> requestIds, CancellationToken cancellationToken)
        {
            var entities = await _unitOfWork.RequestRepository.DbSet.Include(item => item.User).Where(item => requestIds.Contains(item.Id)).ToListAsync(cancellationToken);
            StringBuilder sb = new StringBuilder();

            foreach (var item in entities)
                sb.Append($"{item.Name}\n{item.DateCreated}\n{item.Description}\n by {item.User.FirstName} {item.User.LastName}");

            return sb.ToString();
        }
    }
}
