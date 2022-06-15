using AutoMapper;
using Core.Entities;
using Shared.FrequencyDTo;

namespace Core.Profiles
{
    public class FrequencyProfile : Profile
    {
        public FrequencyProfile()
        {
            CreateMap<Frequency, FrequencyDTO>();
        }
    }
}
