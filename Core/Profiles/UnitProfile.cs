using AutoMapper;
using Core.Entities;
using Shared.UnitDTO;

namespace Core.Profiles
{
    public class UnitProfile : Profile
    {
        public UnitProfile()
        {
            CreateMap<Unit, UnitDTO>();
        }
    }
}