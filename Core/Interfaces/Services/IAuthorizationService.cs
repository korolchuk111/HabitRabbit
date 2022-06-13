using System.Threading.Tasks;
using Shared.UserDTO;

namespace Core.Interfaces.Services
{
    public interface IAuthorizationService
    {
        Task<string> LoginAsync(UserLoginDTO userLogin);
        Task<string> RegisterAsync(UserRegistrationDTO userRegistrationDto);
        Task<UserDTO> GetUserByJWT(string jwtToken);
    }
}