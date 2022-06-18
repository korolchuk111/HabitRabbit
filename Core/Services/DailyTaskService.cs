using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared.DailyTaskDTO;

namespace Core.Services
{
    public class DailyTaskService : IDailyTaskService
    {
        private readonly IRepository<DailyTask> _dailyTaskRepository;
        private readonly UserManager<User> _userManager;
        private readonly IChallengeService _challengeService;
        private readonly IMapper _mapper;

        public DailyTaskService(
            IRepository<DailyTask> dailyTaskRepository,
            UserManager<User> userManager,
            IChallengeService challengeService,
            IMapper mapper)
        {
            _dailyTaskRepository = dailyTaskRepository;
            _userManager = userManager;
            _challengeService = challengeService;
            _mapper = mapper;
        }

        public async Task<IList<DailyTaskDTO>> GetAllTasksForTodayByUser(string userId)
        {
            var challenges = await _challengeService.GetAllChallengesByUser(userId);
            var tasks = new List<DailyTask>();
            foreach (var challenge in challenges)
            {
                var tasksByChallenge = _dailyTaskRepository.Query()
                    .Where(t => t.ChallengeId == challenge.Id && t.Date.Date == DateTime.Now.Date)
                    .Include(t => t.Challenge.Unit)
                    .Include(t => t.Challenge.Frequency).ToList();
                tasks.AddRange(tasksByChallenge);
            }
            return tasks.Select(task => _mapper.Map<DailyTaskDTO>(task)).ToList();
        }
    }
}
