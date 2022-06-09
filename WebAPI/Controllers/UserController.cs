﻿using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;

        public UserController(UserManager<User> manager)
        {
            _userManager = manager;
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(string userName, string email, string password)
        {
            await _userManager.CreateAsync(new User
            {
                UserName = userName,
                Email = email,
                StatusId = 1
            }, password);
            return Ok();
        }
    }
}