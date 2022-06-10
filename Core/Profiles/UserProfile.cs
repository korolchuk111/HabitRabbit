using AutoMapper;
using Core.Entities;
using Shared.UserDTO;

namespace Core.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserRegistrationDTO>().ReverseMap();
        }

    }
}