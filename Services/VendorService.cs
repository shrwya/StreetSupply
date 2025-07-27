using Microsoft.AspNetCore.Mvc;
using StreetSupply.Interfaces.Engines;
using StreetSupply.Interfaces.Services;
using StreetSupply.Models;

namespace StreetSupply.Services
{
    public class VendorService : IVendorService
    {
        private readonly IVendorEngine _vendorEngine;

        public VendorService(IVendorEngine vendorEngine)
        {
            _vendorEngine = vendorEngine;
        }

        public async Task<ActionResult<IEnumerable<Vendor>>> GetAllVendorsAsync()
        {
            var vendors = await _vendorEngine.GetAllVendorsAsync();
            return new OkObjectResult(vendors);
        }

        public async Task<ActionResult<Vendor>> GetVendorByIdAsync(int id)
        {
            var vendor = await _vendorEngine.GetVendorByIdAsync(id);
            if (vendor == null)
                return new NotFoundResult();

            return new OkObjectResult(vendor);
        }

        public async Task<ActionResult<Vendor>> CreateVendorAsync(Vendor vendor)
        {
            var created = await _vendorEngine.CreateVendorAsync(vendor);
            return new CreatedAtActionResult(nameof(GetVendorByIdAsync), "Vendor", new { id = created.VendorId }, created);
        }

        public async Task<ActionResult<IEnumerable<OrderRequest>>> GetIncomingRequestsAsync(int vendorId)
        {
            var requests = await _vendorEngine.GetIncomingRequestsAsync(vendorId);
            return new OkObjectResult(requests);
        }
        public async Task<ActionResult<IEnumerable<OrderRequest>>> GetRequestsByVendorIdAsync(int vendorId)
        {
            var requests = await _vendorEngine.GetRequestsByVendorIdAsync(vendorId);
            return new ActionResult<IEnumerable<OrderRequest>>(requests);
        }


        public async Task<ActionResult> RespondToOrderRequestAsync(int requestId, bool approve)
        {
            var result = await _vendorEngine.RespondToOrderRequestAsync(requestId, approve);
            if (!result) return new BadRequestObjectResult("Request not found or already responded to.");

            return new OkResult();
        }
    }
}
