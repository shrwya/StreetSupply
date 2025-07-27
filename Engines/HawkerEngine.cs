using Microsoft.EntityFrameworkCore;
using StreetSupply.Data;
using StreetSupply.Interfaces.Engines;
using StreetSupply.Models;

namespace StreetSupply.Engines
{
    public class HawkerEngine : IHawkerEngine
    {
        private readonly StreetSupplyDbContext _context;

        public HawkerEngine(StreetSupplyDbContext context)
        {
            _context = context;
        }

        public async Task<Hawker> CreateHawkerAsync(Hawker hawker)
        {
            _context.Hawkers.Add(hawker);
            await _context.SaveChangesAsync();
            return hawker;
        }

        public async Task<List<Vendor>> GetNearbyVendorsAsync(string pincode)
        {
            return await _context.Vendors
                .Include(v => v.Products)
                .Where(v => v.Pincode == pincode)
                .ToListAsync();
        }

        public async Task<bool> SendOrderRequestAsync(OrderRequest request)
        {
            var existing = await _context.OrderRequests
                .CountAsync(r => r.HawkerId == request.HawkerId && r.Status == "Pending");

            if (existing >= 2) return false;

            request.RequestTime = DateTime.UtcNow;
            request.Status = "Pending";
            _context.OrderRequests.Add(request);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<OrderRequest>> GetOrderStatusAsync(int hawkerId)
        {
            return await _context.OrderRequests
                .Where(r => r.HawkerId == hawkerId)
                .ToListAsync();
        }

        public async Task<List<OrderHistory>> GetOrderHistoryAsync(int hawkerId)
        {
            return await _context.OrderHistories
                .Where(h => h.HawkerId == hawkerId)
                .OrderByDescending(h => h.OrderedOn)
                .ToListAsync();
        }
    }
}
