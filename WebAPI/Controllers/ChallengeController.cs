using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Shared.ChallengeDTO;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChallengeController : Controller
    {
        private readonly IChallengeService _challengeService;
        private readonly IUserService _userService;

        public ChallengeController(IChallengeService challengeService, IUserService userService)
        {
            _challengeService = challengeService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> GetChallengesByUserId(string userName)
        {
            var user = _userService.GetUserByName(userName);
            var challenges = await _challengeService.GetAllChallengesByUser(user.Id);
            return Ok(challenges);
        }

        [HttpPost("create")]
        public async Task<ActionResult> AddChallenge(CreateChallengeDTO createChallengeDto)
        {
            await _challengeService.AddChallenge(createChallengeDto);
            return Ok();
        }
        
        [HttpPost("update")]
        public async Task<ActionResult> UpdateChallenge(UpdateChallengeDTO updateChallengeDto)
        {
            await _challengeService.UpdateChallenge(updateChallengeDto);
            return Ok();
        }
        

        [HttpDelete]
        public async Task<ActionResult> DeleteChallenge(CreateChallengeDTO createChallengeDto)
        {
            await _challengeService.DeleteChallenge(createChallengeDto);
            return Ok();
        }
        
    }
}