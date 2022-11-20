using APPZ.Core.Constants;
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
        public async Task<ActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok(await _requestService.GetAllRequests(cancellationToken));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _requestService.GetRequest(id, cancellationToken));
        }
        [HttpPost]
        public async Task<ActionResult> Create(RequestCreateDTO item, CancellationToken cancellationToken)
        {
            await _requestService.AddRequest(item, cancellationToken);
            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> ProcessRequest(Guid id, [FromBody]Status status, CancellationToken cancellationToken)
        {
            await _requestService.ProcessRequest(id, status, cancellationToken);
            return Ok();
        }
        [HttpGet("user/{id}")]
        public async Task<ActionResult> GetUsersRequest(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _requestService.GetRequestsByUserId(id, cancellationToken));
        }
    }
}