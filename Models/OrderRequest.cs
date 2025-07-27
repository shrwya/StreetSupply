namespace StreetSupply.Models
{
    public class OrderRequest
    {
        public int OrderRequestId { get; set; }
        public int HawkerId { get; set; }
        public Hawker Hawker { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
        public string ProductName { get; set; }
        public decimal OfferedPrice { get; set; }
        public string Status { get; set; } // Pending, Approved, Rejected
        public DateTime RequestTime { get; set; }
        public bool IsApproved { get; set; }

    }
}
