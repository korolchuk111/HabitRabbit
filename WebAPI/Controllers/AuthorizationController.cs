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
        public async Task<ActionResult> Register([FromBody] UserRegistrationDTO user)
        {
            await _authorizationService.RegisterAsync(user);
            return Ok();
        }
        
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] UserLoginDTO userLoginDto)
        {
            var id = await _authorizationService.LoginAsync(userLoginDto);
            return Ok(id);
        }
    }
}