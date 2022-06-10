using System.Threading.Tasks;
using Shared.UserDTO;

namespace Core.Interfaces.Services
{
    public interface IAuthorizationService
    {
        Task<string> LoginAsync(UserLoginDTO userLogin);
        Task RegisterAsync(UserRegistrationDTO userRegistrationDto);
    }
}