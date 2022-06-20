﻿using System.Threading.Tasks;
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

        [HttpGet]
        public ActionResult<UserDTO> GetCurrentUser(string userName)
        {
            var user = _userService.GetUserByName(userName);
            return Ok(user);
        }

        [HttpPost ("update")]
        public async Task<ActionResult> UpdateUserInfo(UpdateUserDTO updateUserDto)
        {
            await _userService.UpdateUserInfo(updateUserDto);
            return Ok();
        }

        [HttpPost("delete")]
        public async Task<ActionResult> DeleteUser(string userName)
        {
            await _userService.DeleteUser(userName);
            return Ok();
        }
    }
}
