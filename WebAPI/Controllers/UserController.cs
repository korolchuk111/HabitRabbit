using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.Services;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shared.UserDTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUserService _userService;

        public UserController(UserManager<User> manager, IHttpContextAccessor contextAccessor, IUserService userService)
        {
            _userManager = manager;
            _contextAccessor = contextAccessor;
            _userService = userService;
        }

        // [HttpGet]
        // public async Task<ActionResult> GetCurrentUser()
        // {
        //     var claims = _contextAccessor.HttpContext.User;
        //     var user = await _userManager.GetUserAsync(claims);
        //     return Ok(user);
        // }

        [HttpPost ("update")]
        public async Task<ActionResult> UpdateUserInfo(UpdateUserDTO updateUserDto)
        {
            await _userService.UpdateUserInfo(updateUserDto);
            return Ok();
        }
    }
}
