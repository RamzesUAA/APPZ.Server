using APPZ.Core.Entities;
using APPZ.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPZ.Infrastructure.Implementations
{
    public class RequestService : IRequestService
    {
        IUnitOfWork _unitOfWork;
        public RequestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<RequestEntity> GetRequest(Guid id)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<RequestEntity>> GetRequests()
        {
            return await _unitOfWork.RequestRepository.GetAll(CancellationToken.None);

        }
    }
}
