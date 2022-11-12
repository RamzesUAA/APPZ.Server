using APPZ.Core.Constants;
using APPZ.Core.DTO;
using APPZ.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPZ.Core.Interfaces
{
    public interface IRequestService
    {
        Task AddRequest(RequestCreateDTO request, CancellationToken cancellationToken);
        Task<RequestReadDTO> GetRequest(Guid id, CancellationToken cancellationToken);
        Task ProcessRequest(Guid id, Status status, CancellationToken cancellationToken);
        Task<IEnumerable<RequestReadDTO>> GetAllRequests(CancellationToken cancellationToken);
    }
}
