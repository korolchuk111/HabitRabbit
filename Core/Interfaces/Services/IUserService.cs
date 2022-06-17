using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.UserDTO;
namespace Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<IList<UserDTO>> GetAllUser();

    }
}