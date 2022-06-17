using AutoMapper;
using Core.Entities;
using Shared.ChallengeDTO;

namespace Core.Profiles
{
    public class ChallengeProfile : Profile
    {
        public ChallengeProfile()
        {
            CreateMap<Challenge, ChallengeDTO>()
                .ForMember(d => d.AuthorId,
                    opt => opt
                        .MapFrom(ch => ch.AuthorId))
                .ForMember(d => d.FrequencyTitle,
                    opt => opt
                        .MapFrom(ch => ch.Frequency.Type))
                .ForMember(d => d.UnitShortTitle,
                    opt => opt
                        .MapFrom(ch => ch.Unit.ShortType));
        }
    }
}