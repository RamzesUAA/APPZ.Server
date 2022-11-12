using APPZ.Core.DTO;
using APPZ.Core.Entities;
using APPZ.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APPZ.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestController : ControllerBase
    {

        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }


        [HttpGet(Name = "GetRequests")]
        public async Task<IEnumerable<RequestReadDTO>> Get(CancellationToken cancellationToken)
        {
            return await _requestService.GetAllRequests(cancellationToken);
        }
    }
}