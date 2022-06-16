using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Services;
using Shared.FrequencyDTo;

namespace Core.Services
{
    public class FrequencyService : IFrequencyService
    {
        private readonly IRepository<Frequency> _frequencyRepository;
        private readonly IMapper _mapper;
        public FrequencyService(IRepository<Frequency> frequencyRepository, IMapper mapper)
        {
            _frequencyRepository = frequencyRepository;
            _mapper = mapper;
        }

        public async Task<IList<FrequencyDTO>> GetAllFrequencies()
        {
            var frequencies = await _frequencyRepository.GetAllAsync();
            var dtos = frequencies.ToList().Select(unit => _mapper.Map<FrequencyDTO>(unit)).ToList();
            return dtos;
        }
    }
}
