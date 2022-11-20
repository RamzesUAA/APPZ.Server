using APPZ.Core.Constants;
using APPZ.Core.DTO;
using APPZ.Core.Entities;
using APPZ.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APPZ.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificationController : ControllerBase
    {

        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<ActionResult> Get(CancellationToken cancellationToken)
        {
            return Ok(await _notificationService.GetNotifications(cancellationToken));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _notificationService.GetNotification(id, cancellationToken));
        }
        [HttpGet("user/{id}")]
        public async Task<ActionResult> GetUsersNotifications(Guid id, CancellationToken cancellationToken)
        {
            return Ok(await _notificationService.GetNotificationsForUser(id, cancellationToken));
        }
    }
}