using Microsoft.AspNetCore.Mvc;
using StreetSupply.Interfaces.Engines;
using StreetSupply.Interfaces.Services;
using StreetSupply.Models;

namespace StreetSupply.Services
{
    public class HawkerService : IHawkerService
    {
        private readonly IHawkerEngine _hawkerEngine;

        public HawkerService(IHawkerEngine hawkerEngine)
        {
            _hawkerEngine = hawkerEngine;
        }

        public async Task<ActionResult<Hawker>> CreateHawkerAsync(Hawker hawker)
        {
            var created = await _hawkerEngine.CreateHawkerAsync(hawker);
            return new CreatedAtActionResult(nameof(CreateHawkerAsync), "Hawker", new { id = created.HawkerId }, created);
        }

        public async Task<ActionResult<IEnumerable<Vendor>>> GetNearbyVendorsAsync(string pincode)
        {
            var vendors = await _hawkerEngine.GetNearbyVendorsAsync(pincode);
            return new OkObjectResult(vendors);
        }

        public async Task<ActionResult> SendOrderRequestAsync(OrderRequest request)
        {
            var success = await _hawkerEngine.SendOrderRequestAsync(request);
            if (!success)
                return new BadRequestObjectResult("Limit reached or invalid data");

            return new OkResult();
        }

        public async Task<ActionResult<IEnumerable<OrderRequest>>> GetOrderStatusAsync(int hawkerId)
        {
            var status = await _hawkerEngine.GetOrderStatusAsync(hawkerId);
            return new OkObjectResult(status);
        }

        public async Task<ActionResult<IEnumerable<OrderHistory>>> GetOrderHistoryAsync(int hawkerId)
        {
            var history = await _hawkerEngine.GetOrderHistoryAsync(hawkerId);
            return new OkObjectResult(history);
        }
    }
}
