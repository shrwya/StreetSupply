//using StreetSupply.Interfaces.Services;
//using StreetSupply.ViewModels.Auth;
//using System.Threading.Tasks;

//namespace StreetSupply.Services
//{
//    public class AuthService : IAuthService
//    {
//        // Hardcoded for demo. Later connect to your DB
//        public async Task<LoginResponse> LoginAsync(LoginRequest request)
//        {
//            // Fake user validation
//            if (request.Username == "admin" && request.Password == "password")
//            {
//                return new LoginResponse
//                {
//                    IsSuccess = true,
//                    Message = "Login successful",
//                    Token = "demo-token" // Placeholder; replace with JWT later
//                };
//            }

//            return new LoginResponse
//            {
//                IsSuccess = false,
//                Message = "Invalid username or password",
//                Token = null
//            };
//        }
//    }
//}
using StreetSupply.Interfaces.Services;
using StreetSupply.ViewModels.Auth;
using System.Threading.Tasks;
using StreetSupply.Helpers;
using Microsoft.Extensions.Configuration;

namespace StreetSupply.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtHelper _jwtHelper;

        public AuthService(IConfiguration config)
        {
            _jwtHelper = new JwtHelper(config);
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            if (request.Username == "admin" && request.Password == "password")
            {
                var token = _jwtHelper.GenerateToken(request.Username);

                return new LoginResponse
                {
                    IsSuccess = true,
                    Message = "Login successful",
                    Token = token
                };
            }

            return new LoginResponse
            {
                IsSuccess = false,
                Message = "Invalid username or password",
                Token = null
            };
        }
    }
}
