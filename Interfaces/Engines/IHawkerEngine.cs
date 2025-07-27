using StreetSupply.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StreetSupply.Interfaces.Engines
{
    public interface IHawkerEngine
    {
        Task<Hawker> CreateHawkerAsync(Hawker hawker);
        Task<List<Vendor>> GetNearbyVendorsAsync(string pincode);
        Task<bool> SendOrderRequestAsync(OrderRequest request);
        Task<List<OrderRequest>> GetOrderStatusAsync(int hawkerId);
        Task<List<OrderHistory>> GetOrderHistoryAsync(int hawkerId);
    }
}
