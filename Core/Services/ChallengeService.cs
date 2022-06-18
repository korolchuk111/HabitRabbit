using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared.ChallengeDTO;

namespace Core.Services
{
    public class ChallengeService : IChallengeService
    {
        
        private readonly IRepository<Challenge> _challengeRepository;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public ChallengeService(IRepository<Challenge> challengeRepository, IMapper mapper, IUserService userService)
        {
            _challengeRepository = challengeRepository;
            _mapper = mapper;
            _userService = userService;
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
            await _challengeRepository.AddAsync(challenge);
            await _challengeRepository.SaveChangesAsync();
        }
    }
}