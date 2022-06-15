using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.UnitDTO;

namespace Core.Interfaces.Services
{
    public interface IUnitService
    {
        IList<UnitDTO> GetAllUnits();
    }
}