namespace StreetSupply.DTOs
{
    public class RegisterDTO
    {
        public string UserType { get; set; } // "hawker" or "vendor"
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Pincode { get; set; }
    }
}
