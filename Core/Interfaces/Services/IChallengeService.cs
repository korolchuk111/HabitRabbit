using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.ChallengeDTO;

namespace Core.Interfaces.Services
{
    public interface IChallengeService
    {
        Task<IList<ChallengeDTO>> GetAllChallengesByUser(string userId);
        Task AddChallenge(CreateChallengeDTO createChallengeDto);
        Task UpdateChallenge(UpdateChallengeDTO updateChallengeDto);
        Task DeleteChallenge(CreateChallengeDTO createChallengeDto);
    }
}