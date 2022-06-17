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

        public ChallengeService(IRepository<Challenge> challengeRepository, IMapper mapper)
        {
            _challengeRepository = challengeRepository;
            _mapper = mapper;
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
    }
}