using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public UserController(UserManager<User> manager, IHttpContextAccessor contextAccessor)
        {
            _userManager = manager;
            _contextAccessor = contextAccessor;
        }

        [HttpGet]
        public async Task<ActionResult> GetCurrentUser()
        {
            var claims = _contextAccessor.HttpContext.User;
            var user = await _userManager.GetUserAsync(claims);
            return Ok(user);
        }
    }
}
