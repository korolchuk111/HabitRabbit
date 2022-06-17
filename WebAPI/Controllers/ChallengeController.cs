using System.Security.Claims;
using System.Threading.Tasks;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

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
            var user = await _userService.GetUserByName(userName);
            var challenges = await _challengeService.GetAllChallengesByUser(user.Id);
            return Ok(challenges);
        }
    }
}