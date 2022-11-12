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
        public Task<RequestEntity> GetRequest(Guid id);
        public Task<IEnumerable<RequestEntity>> GetRequests();
    }
}
