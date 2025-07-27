using Microsoft.EntityFrameworkCore;
using StreetSupply.Data;
using StreetSupply.Interfaces.Engines;
using StreetSupply.Models;

namespace StreetSupply.Engines
{
    public class VendorEngine : IVendorEngine
    {
        private readonly StreetSupplyDbContext _context;

        public VendorEngine(StreetSupplyDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<OrderRequest>> GetRequestsByVendorIdAsync(int vendorId)
        {
            return await _context.OrderRequests
                                 .Where(r => r.VendorId == vendorId)
                                 .ToListAsync();
        }


        public async Task<List<Vendor>> GetAllVendorsAsync()
        {
            return await _context.Vendors.Include(v => v.Products).ToListAsync();
        }

        public async Task<Vendor> GetVendorByIdAsync(int id)
        {
            return await _context.Vendors.Include(v => v.Products).FirstOrDefaultAsync(v => v.VendorId == id);
        }

        public async Task<Vendor> CreateVendorAsync(Vendor vendor)
        {
            _context.Vendors.Add(vendor);
            await _context.SaveChangesAsync();
            return vendor;
        }

        public async Task<List<OrderRequest>> GetIncomingRequestsAsync(int vendorId)
        {
            return await _context.OrderRequests
                .Where(r => r.VendorId == vendorId)
                .ToListAsync();
        }

        public async Task<bool> RespondToOrderRequestAsync(int requestId, bool approve)
        {
            var request = await _context.OrderRequests.FindAsync(requestId);
            if (request == null || request.Status != "Pending") return false;

            request.Status = approve ? "Approved" : "Rejected";
            await _context.SaveChangesAsync();

            // Auto-cancel other requests if approved
            if (approve)
            {
                var otherRequests = _context.OrderRequests
                    .Where(r => r.HawkerId == request.HawkerId && r.OrderRequestId != requestId && r.Status == "Pending");

                foreach (var r in otherRequests)
                    r.Status = "Cancelled";

                await _context.SaveChangesAsync();
            }

            return true;
        }
    }
}
