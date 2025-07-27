using Microsoft.AspNetCore.Mvc;
using StreetSupply.Interfaces.Services;
using StreetSupply.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StreetSupply.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HawkerController : ControllerBase
    {
        private readonly IOrderRequestService _orderRequestService;

        public HawkerController(IOrderRequestService orderRequestService)
        {
            _orderRequestService = orderRequestService;
        }

        [HttpPost("place-order")]
        public async Task<ActionResult<OrderRequest>> PlaceOrderRequest([FromBody] OrderRequest request)
        {
            return await _orderRequestService.PlaceOrderRequestAsync(request);
        }
        [HttpGet("{hawkerId}/pending-requests")]
        public async Task<ActionResult<IEnumerable<OrderRequest>>> GetPendingRequests(int hawkerId)
        {
            return await _orderRequestService.GetRequestsByHawkerIdAsync(hawkerId);
        }


        [HttpGet("{hawkerId}/approved-orders")]
        public async Task<ActionResult<IEnumerable<OrderRequest>>> GetApprovedOrders(int hawkerId)
        {
            return await _orderRequestService.GetApprovedOrdersByHawkerIdAsync(hawkerId);
        }

        [HttpGet("{hawkerId}/order-history")]
        public async Task<ActionResult<IEnumerable<OrderRequest>>> GetOrderHistory(int hawkerId)
        {
            return await _orderRequestService.GetOrderHistoryByHawkerIdAsync(hawkerId);
        }
    }
}
