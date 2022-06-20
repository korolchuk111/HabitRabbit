using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using Shared.ChallengeDTO;

namespace Core.Services
{
    public class ChallengeService : IChallengeService
    {
        private readonly IRepository<Challenge> _challengeRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IRepository<DailyTask> _dailyTaskRepository;

        public ChallengeService(
            IRepository<Challenge> challengeRepository,
            IMapper mapper,
            IUserService userService,
            IRepository<DailyTask> dailyTaskRepository)
        {
            _challengeRepository = challengeRepository;
            _mapper = mapper;
            _userService = userService;
            _dailyTaskRepository = dailyTaskRepository;
        }
        public async Task<IList<ChallengeDTO>> GetAllChallengesByUser(string userId)
        {
            var challenges = await _challengeRepository.Query()
                .Where(c => c.AuthorId == userId)
                .Include(ch => ch.Frequency)
                .Include(ch => ch.Unit)
                .Include(ch => ch.Author)
                .ToListAsync();
            return challenges.Select(challenge => _mapper.Map<ChallengeDTO>(challenge)).ToList();
        }

        public async Task AddChallenge(CreateChallengeDTO createChallengeDto)
        {
            var user = _userService.GetUserByName(createChallengeDto.AuthorName);
            var challenge = _mapper.Map<Challenge>(createChallengeDto);
            challenge.AuthorId = user.Id;
            challenge = await _challengeRepository.AddAsync(challenge);
            await _challengeRepository.SaveChangesAsync();
            
            await CreateDailyTasksByChallenge(challenge);
        }

        private async Task CreateDailyTasksByChallenge(Challenge challenge)
        {
            var startDate = challenge.StartDate.Date;
            var endDate = challenge.EndDate;
            var days = (endDate - startDate).Days + 1;
            
            for (var i = 0; i < days; i++)
            {
                var dailyTask = new DailyTask
                {
                    ChallengeId = challenge.Id,
                    Date = startDate.AddDays(i),
                    CountOfUnitsDone = 0,
                    PercentOfDone = 0,
                    IsDone = false
                };
                await _dailyTaskRepository.AddAsync(dailyTask);
            }
            await _dailyTaskRepository.SaveChangesAsync();
        }

        public async Task UpdateChallenge(UpdateChallengeDTO updateChallengeDto)
        {
            var user = _userService.GetUserByName(updateChallengeDto.AuthorName);
            var challenge = _mapper.Map<Challenge>(updateChallengeDto);
            challenge.AuthorId = user.Id;
            await _challengeRepository.UpdateAsync(challenge);
            await _challengeRepository.SaveChangesAsync();
        }

        public async Task DeleteChallenge(int challengeId)
        {
            var challenge = await _challengeRepository.GetByIdAsync(challengeId);
            var tasks = await _dailyTaskRepository.Query()
                .Where(t => t.ChallengeId == challengeId).ToListAsync();
            await _dailyTaskRepository.DeleteRange(tasks);
            await _challengeRepository.DeleteAsync(challenge);
            await _challengeRepository.SaveChangesAsync();
        }
        
        public async Task<ChallengeDTO> GetChallengeById(int challengeId)
        {
            var challenge = await _challengeRepository.Query()
                .Where(c => c.Id == challengeId)
                .Include(ch => ch.Frequency)
                .Include(ch => ch.Unit)
                .Include(ch => ch.Author)
                .FirstOrDefaultAsync();
            return _mapper.Map<ChallengeDTO>(challenge);
        }
    }
}
