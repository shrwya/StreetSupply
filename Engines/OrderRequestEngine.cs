using Microsoft.AspNetCore.Mvc;
using StreetSupply.Interfaces.Engines;
using StreetSupply.Models;
using StreetSupply.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;


namespace StreetSupply.Engines
{
    public class OrderRequestEngine : IOrderRequestEngine
    {
        private readonly StreetSupplyDbContext _context;

        public OrderRequestEngine(StreetSupplyDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult<IEnumerable<OrderRequest>>> GetRequestsByVendorIdAsync(int vendorId)
        {
            var requests = await _context.OrderRequests
                .Where(r => r.VendorId == vendorId && !r.IsApproved)
                .ToListAsync();

            return new ActionResult<IEnumerable<OrderRequest>>(requests);
        }

        public async Task<ActionResult<IEnumerable<OrderRequest>>> GetRequestsByHawkerIdAsync(int hawkerId)
        {
            var requests = await _context.OrderRequests
                .Where(r => r.HawkerId == hawkerId && !r.IsApproved)
                .ToListAsync();

            return new ActionResult<IEnumerable<OrderRequest>>(requests);
        }

        public async Task<ActionResult<OrderRequest>> PlaceOrderRequestAsync(OrderRequest request)
        {
            _context.OrderRequests.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task<ActionResult<IEnumerable<OrderRequest>>> GetApprovedOrdersByHawkerIdAsync(int hawkerId)
        {
            var orders = await _context.OrderRequests
                .Where(r => r.HawkerId == hawkerId && r.IsApproved)
                .ToListAsync();

            return orders;
        }


        public async Task<ActionResult<IEnumerable<OrderRequest>>> GetOrderHistoryByHawkerIdAsync(int hawkerId)
        {
            var orders = await _context.OrderRequests
                .Where(r => r.HawkerId == hawkerId)
                .ToListAsync();

            return orders;
        }
    }
}
