using System.Security.Claims;
using System.Threading.Tasks;
using Shared.UserDTO;

namespace Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<UserDTO> GetUserByName(string userName);
    }
}