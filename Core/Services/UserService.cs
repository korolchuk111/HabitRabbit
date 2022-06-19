using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Shared.UserDTO;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _userRepository;
        private readonly UserManager<User> _userManager;

        public UserService(IMapper mapper, IRepository<User> userRepository, UserManager<User> userManager)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public UserDTO GetUserByName(string userName)
        {
            var user = _userRepository.Query().First(user => user.UserName.Equals(userName)); 
            return _mapper.Map<UserDTO>(user);
        }
        
        public async Task UpdateUserInfo(UpdateUserDTO updateUserDto)
        {
            var user = _userRepository.Query().First(user => user.UserName.Equals(updateUserDto.UserName)); 
            user.Email = updateUserDto.NewEmail;
            user.UserName = updateUserDto.NewUserName;
            await _userManager.UpdateAsync(user);
        }
        public async Task DeleteUser(string userName)
        {
            var user = _userRepository.Query().First(user => user.UserName.Equals(userName));
            await _userManager.DeleteAsync(user);
        }
    }
}
