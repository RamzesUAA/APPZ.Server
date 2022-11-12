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
        public async Task<IEnumerable<RequestEntity>> Get()
        {
            return await _requestService.GetRequests();
        }
    }
}