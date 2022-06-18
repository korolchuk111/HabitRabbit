using AutoMapper;
using Core.Entities;
using Shared.DailyTaskDTO;

namespace Core.Profiles
{
    public class DailyTaskProfile : Profile
    {
        public DailyTaskProfile()
        {
            CreateMap<DailyTask, DailyTaskDTO>()
                .ForMember(d => d.FrequencyType,
                    opt => opt
                        .MapFrom(task => task.Challenge.Frequency.Type))
                .ForMember(d => d.UnitShortName,
                    opt => opt
                        .MapFrom(task => task.Challenge.Unit.ShortType))
                .ForMember(d => d.CountOfUnits,
                    opt => opt
                        .MapFrom(task => task.Challenge.CountOfUnits));
        }
    }
}
