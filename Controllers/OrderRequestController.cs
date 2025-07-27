using Microsoft.AspNetCore.Mvc;
using StreetSupply.Interfaces.Services;
using StreetSupply.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StreetSupply.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderRequestController : ControllerBase
    {
        private readonly IOrderRequestService _orderRequestService;

        public OrderRequestController(IOrderRequestService orderRequestService)
        {
            _orderRequestService = orderRequestService;
        }

        [HttpGet("vendor/{vendorId}")]
        public async Task<ActionResult<IEnumerable<OrderRequest>>> GetRequestsByVendorId(int vendorId)
        {
            return await _orderRequestService.GetRequestsByVendorIdAsync(vendorId);
        }

        [HttpGet("hawker/{hawkerId}")]
        public async Task<ActionResult<IEnumerable<OrderRequest>>> GetRequestsByHawkerId(int hawkerId)
        {
            return await _orderRequestService.GetRequestsByHawkerIdAsync(hawkerId);
        }

        [HttpPost]
        public async Task<ActionResult<OrderRequest>> PlaceOrderRequest([FromBody] OrderRequest request)
        {
            return await _orderRequestService.PlaceOrderRequestAsync(request);
        }

        [HttpGet("approved/{hawkerId}")]
        public async Task<ActionResult<IEnumerable<OrderRequest>>> GetApprovedOrdersByHawkerId(int hawkerId)
        {
            return await _orderRequestService.GetApprovedOrdersByHawkerIdAsync(hawkerId);
        }

        [HttpGet("history/{hawkerId}")]
        public async Task<ActionResult<IEnumerable<OrderRequest>>> GetOrderHistoryByHawkerId(int hawkerId)
        {
            return await _orderRequestService.GetOrderHistoryByHawkerIdAsync(hawkerId);
        }
    }
}
