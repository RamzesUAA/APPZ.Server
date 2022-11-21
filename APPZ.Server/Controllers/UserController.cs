using APPZ.Core.DTO;
using APPZ.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

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

        [HttpPost(Name = "Login")]
        public async Task<ActionResult> Get([FromBody] UserDto userDto, CancellationToken cancellationToken)
        {
            return Ok(await _userService.Login(userDto, cancellationToken));
        }
    }
}
