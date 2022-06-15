using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.FrequencyDTo;

namespace Core.Interfaces.Services
{
    public interface IFrequencyService
    {
        Task<IList<FrequencyDTO>> GetAllFrequencies();
    }
}
