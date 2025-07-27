namespace StreetSupply.Models
{
    public class OrderHistory
    {
        public int OrderHistoryId { get; set; }
        public int HawkerId { get; set; }
        public string ProductName { get; set; }
        public decimal FinalPrice { get; set; }
        public string VendorCompany { get; set; }
        public DateTime OrderedOn { get; set; }
        public int Rating { get; set; } // Out of 5
    }
}
