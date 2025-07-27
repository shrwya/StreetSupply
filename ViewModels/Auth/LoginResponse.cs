namespace StreetSupply.ViewModels.Auth
{
    public class LoginResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }  // Optional - add later if you're doing JWT
    }
}
