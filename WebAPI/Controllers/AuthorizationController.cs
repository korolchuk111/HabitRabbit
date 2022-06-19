using System.Threading.Tasks;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.UserDTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : Controller
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthorizationController(
            IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserRegistrationDTO user)
        {
            var token = await _authorizationService.RegisterAsync(user);
            return Ok(token);
        }
        
        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLoginDTO userLoginDto)
        {
            var token = await _authorizationService.LoginAsync(userLoginDto);
            return Ok(token);
        }
        
        [HttpGet("get-user-by-jwt")]
        public async Task<ActionResult<UserDTO>> GetUserByJwt(string token)
        {
            var user = await _authorizationService.GetUserByJwt(token);
            if (user == null)
            {
                return Unauthorized();
            }

            return user;
        }
    }
}
