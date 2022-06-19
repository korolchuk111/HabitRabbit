using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared.UserDTO;

namespace Core.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IRepository<User> _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly IRepository<DailyTask> _dailyTaskRepository;
        private readonly IRepository<Challenge> _challengeRepository;

        public UserService(IMapper mapper, IRepository<User> userRepository, UserManager<User> userManager,
            IRepository<DailyTask> dailyTaskRepository, IRepository<Challenge> challengeRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _userManager = userManager;
            _dailyTaskRepository = dailyTaskRepository;
            _challengeRepository = challengeRepository;
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
            var challenges = _challengeRepository.Query().Where(c => c.AuthorId == user.Id);
            foreach (var challenge in challenges)
            {
                var tasksByChallenge = _dailyTaskRepository.Query()
                    .Where(t => t.ChallengeId == challenge.Id && t.Date.Date == DateTime.Now.Date).ToList();
                await _dailyTaskRepository.DeleteRange(tasksByChallenge);
            }
            await _challengeRepository.DeleteRange(challenges);
            await _challengeRepository.SaveChangesAsync();
            await _userManager.DeleteAsync(user);
        }
    }
}
