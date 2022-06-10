using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Shared.UserDTO;

namespace Core.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;

        public AuthorizationService(IMapper mapper, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task RegisterAsync(UserRegistrationDTO userRegistrationDto)
        {
            var user = _mapper.Map<User>(userRegistrationDto);
            var createUserResult = await _userManager.CreateAsync(user, userRegistrationDto.Password);
            
            if (!createUserResult.Succeeded)
            {
                throw new System.Exception("User creation failed");
            }
        }

        public async Task<string> LoginAsync(UserLoginDTO userLogin)
        {
            var user = await _userManager.FindByEmailAsync(userLogin.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, userLogin.Password))
            {
                throw new System.Exception("Wrong email or password");
            }

            return user.Id;
        }
    }
}