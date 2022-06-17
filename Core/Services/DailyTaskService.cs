using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Shared.DailyTaskDTO;

namespace Core.Services
{
    public class DailyTaskService : IDailyTaskService
    {
        private readonly IRepository<DailyTask> _dailyTaskRepository;
        private readonly UserManager<User> _userManager;

        public DailyTaskService(IRepository<DailyTask> dailyTaskRepository, UserManager<User> userManager)
        {
            _dailyTaskRepository = dailyTaskRepository;
            _userManager = userManager;
        }

        public async Task<IList<DailyTaskDTO>> GetAllTasksForTodayByUser(ClaimsPrincipal claims)
        {
            var userId = _userManager.GetUserId(claims);
            // var challenges = await _dailyTaskRepository.Query(t => t.ChallengeId)
            return null;
        }
    }
}