using StreetSupply.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StreetSupply.Interfaces.Engines
{
    public interface IVendorEngine
    {
        Task<List<Vendor>> GetAllVendorsAsync();
        Task<Vendor> GetVendorByIdAsync(int id);
        Task<Vendor> CreateVendorAsync(Vendor vendor);
        Task<bool> RespondToOrderRequestAsync(int requestId, bool approve);
        Task<List<OrderRequest>> GetIncomingRequestsAsync(int vendorId);
        Task<IEnumerable<OrderRequest>> GetRequestsByVendorIdAsync(int vendorId);

    }
}
