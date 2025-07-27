namespace StreetSupply.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal PricePerUnit { get; set; }
        public bool IsPreCut { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
    }
}
