using Microsoft.AspNetCore.Mvc;
using StreetSupply.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StreetSupply.Interfaces.Services
{
    public interface IVendorService
    {
        Task<ActionResult<IEnumerable<Vendor>>> GetAllVendorsAsync();
        Task<ActionResult<Vendor>> GetVendorByIdAsync(int id);
        Task<ActionResult<Vendor>> CreateVendorAsync(Vendor vendor);
        Task<ActionResult> RespondToOrderRequestAsync(int requestId, bool approve);
        Task<ActionResult<IEnumerable<OrderRequest>>> GetIncomingRequestsAsync(int vendorId);
        Task<ActionResult<IEnumerable<OrderRequest>>> GetRequestsByVendorIdAsync(int vendorId);

    }
}
