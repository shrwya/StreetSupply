using StreetSupply.ViewModels.Auth;
using System.Threading.Tasks;

namespace StreetSupply.Interfaces.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginAsync(LoginRequest request);
    }
}
