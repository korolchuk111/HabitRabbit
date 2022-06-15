using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Services;
using Shared.UnitDTO;

namespace Core.Services
{
    public class UnitService : IUnitService
    {
        private readonly IRepository<Unit> _unitRepository;
        private readonly IMapper _mapper;
        
        public UnitService(IRepository<Unit> unitRepository, IMapper mapper)
        {
            _unitRepository = unitRepository;
            _mapper = mapper;
        }

        public IList<UnitDTO> GetAllUnits()
        {
            var units = _unitRepository.Query().ToList();
            var unitDtos = units.Select(unit => _mapper.Map<UnitDTO>(unit)).ToList();
            return unitDtos;
        }
    }
}