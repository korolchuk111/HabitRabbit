using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Services;
using Shared.UserDTO;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;
        
        
        public UserService(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        
        public async Task<IList<UserDTO>> GetAllUser()
        {
            var users = await _userRepository.GetAllAsync();
            var userDtos = users.Select(user => _mapper.Map<UserDTO>(user)).ToList();
            return userDtos;
        }
        
    }
}