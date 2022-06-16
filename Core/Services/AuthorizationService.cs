using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shared.UserDTO;

namespace Core.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IRepository<User> _userRepository;

        public AuthorizationService(
            IMapper mapper,
            UserManager<User> userManager,
            IConfiguration configuration,
            IRepository<User> userRepository
        )
        {
            _mapper = mapper;
            _userManager = userManager;
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public async Task<string> RegisterAsync(UserRegistrationDTO userRegistrationDto)
        {
            var user = _mapper.Map<User>(userRegistrationDto);
            user.StatusId = 1;
            var createUserResult = await _userManager.CreateAsync(user, userRegistrationDto.Password);

            if (!createUserResult.Succeeded)
            {
                throw new Exception("User creation failed");
            }

            return GenerateJwtToken(user);
            // return new UserDTO{Id = user.Id, Email = user.Email, UserName = user.UserName, StatusId = user.StatusId};
        }

        public async Task<string> LoginAsync(UserLoginDTO userLogin)
        {
            var user = await _userManager.FindByEmailAsync(userLogin.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, userLogin.Password))
            {
                throw new Exception("Wrong email or password");
            }

            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(User user)
        {
            //getting the secret key
            var secretKey = _configuration["JWTSettings:Secret"];
            var key = Encoding.ASCII.GetBytes(secretKey);

            //create claims
            var claimEmail = new Claim(ClaimTypes.Email, user.Email);
            var claimNameIdentifier = new Claim(ClaimTypes.NameIdentifier, user.Id);
            var claimRole = new Claim(ClaimTypes.Name, user.UserName);

            //create claimsIdentity
            var claimsIdentity = new ClaimsIdentity(
                new[] { claimEmail, claimNameIdentifier, claimRole }, "serverAuth");

            // generate token that is valid for 12 hours
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            //creating a token handler
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            //returning the token back
            return tokenHandler.WriteToken(token);
        }

        public async Task<UserDTO> GetUserByJwt(string jwtToken)
        {
            try
            {
                var secretKey = _configuration["JWTSettings:Secret"];
                var key = Encoding.ASCII.GetBytes(secretKey);
                
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                var tokenHandler = new JwtSecurityTokenHandler();

                var principle = tokenHandler.ValidateToken
                    (jwtToken, tokenValidationParameters, out var securityToken);
                var jwtSecurityToken = (JwtSecurityToken)securityToken;

                if (jwtSecurityToken != null
                    && jwtSecurityToken.ValidTo > DateTime.Now
                    && jwtSecurityToken.Header.Alg.Equals(
                        SecurityAlgorithms.HmacSha256,
                        StringComparison.InvariantCultureIgnoreCase))
                {
                    var userId = principle.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    var user = await _userRepository.GetByIdAsync(userId);
                    return _mapper.Map<UserDTO>(user);
                }
            }
            catch (Exception)
            {
                return null;
            }
            return null;
        }
    }
}