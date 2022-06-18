using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.DailyTaskDTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyTaskController : Controller
    {
        private readonly IDailyTaskService _dailyTaskService;
        private readonly IUserService _userService;

        public DailyTaskController(IDailyTaskService dailyTaskService, IUserService userService)
        {
            _dailyTaskService = dailyTaskService;
            _userService = userService;
        }  
        
        [HttpGet("today")]
        public async Task<ActionResult<IList<DailyTaskDTO>>> GetAllTasksForToday(string userName)
        {
            var user = _userService.GetUserByName(userName);
            var tasks = await _dailyTaskService.GetAllTasksForTodayByUser(user.Id);
            return Ok(tasks);
        }
    }
}
