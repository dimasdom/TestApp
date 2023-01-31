using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TestApp.Core.Common;
using TestApp.Core.DTOs.User;
using TestApp.Core.Interfaces;

namespace TestAPPAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<Result<IdentityResult>>> Register([FromBody] RegisterDTO registerDTO)
        {
            return await _userService.CreateUser(registerDTO);
        }
        [HttpPost("Login")]
        public async Task<ActionResult<Result>> Login([FromBody] LoginDTO loginDTO)
        {
            return await _userService.Login(loginDTO);
        }
    }
}
