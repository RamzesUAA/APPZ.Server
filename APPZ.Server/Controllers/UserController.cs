using APPZ.Core.DTO;
using APPZ.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APPZ.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService requestService)
        {
            _userService = requestService;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login([FromBody] UserDto userDto, CancellationToken cancellationToken)
        {
            var id = await _userService.Login(userDto, cancellationToken);
            if (id == Guid.Empty || id == null)
            {
                return Unauthorized();
            }
            return Ok(id);
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAllUsers(CancellationToken cancellationToken)
        {
            return Ok(await _userService.GetAllUsers(cancellationToken));
        }
    }
}
