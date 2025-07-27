namespace StreetSupply.Models
{
    public class Vendor
    {
        public int VendorId { get; set; }
        public string CompanyName { get; set; }
        public string Locality { get; set; }
        public string Pincode { get; set; }
        public List<Product> Products { get; set; }
        public List<OrderRequest> OrdersReceived { get; set; }
    }
}
