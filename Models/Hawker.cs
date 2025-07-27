namespace StreetSupply.Models
{
    public class Hawker
    {
        public int HawkerId { get; set; }
        public string Name { get; set; }
        public string Pincode { get; set; }
        public List<OrderRequest> OrdersPlaced { get; set; }
    }
}
