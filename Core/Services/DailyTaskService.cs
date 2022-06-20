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
        
        public async Task AddProgress(AddProgressDTO addProgressDto)
        {
            var task = await _dailyTaskRepository.GetByIdAsync(addProgressDto.DailyTaskId);
            var sum = task.CountOfUnitsDone + addProgressDto.ProgressToAdd;
            if (sum > addProgressDto.CountOfUnits) { return; }
            task.CountOfUnitsDone += addProgressDto.ProgressToAdd;
            task.PercentOfDone = (int)((double)task.CountOfUnitsDone / addProgressDto.CountOfUnits*100);
            if (sum == addProgressDto.CountOfUnits)
            {
                task.IsDone = true;
            }
            await _dailyTaskRepository.UpdateAsync(task);
            await _dailyTaskRepository.SaveChangesAsync();
        }
        
        public async Task DeleteAllTasksByChallenge(int challengeId)
        {
            var tasks = await _dailyTaskRepository.Query()
                .Where(t => t.ChallengeId == challengeId).ToListAsync();
            await _dailyTaskRepository.DeleteRange(tasks);
            // await _dailyTaskRepository.SaveChangesAsync();
        }

        public async Task RemoveProgress(int taskId)
        {
            var task = await _dailyTaskRepository.GetByIdAsync(taskId);
            task.CountOfUnitsDone = 0;
            task.PercentOfDone = 0;
            task.IsDone = false;
            await _dailyTaskRepository.UpdateAsync(task);
            await _dailyTaskRepository.SaveChangesAsync();
        }
    }
}
