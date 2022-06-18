using System.Linq;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Services;
using Shared.UserDTO;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _userRepository;

        public UserService(IMapper mapper, IRepository<User> userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public UserDTO GetUserByName(string userName)
        {
            var user = _userRepository.Query().First(user => user.UserName.Equals(userName)); 
            return _mapper.Map<UserDTO>(user);
        }
    }
}
