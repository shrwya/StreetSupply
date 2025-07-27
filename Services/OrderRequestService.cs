//using Microsoft.AspNetCore.Mvc;
//using StreetSupply.Engines;
//using StreetSupply.Interfaces.Engines;
//using StreetSupply.Interfaces.Services;
//using StreetSupply.Models;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace StreetSupply.Services
//{
//    public class OrderRequestService : IOrderRequestService
//    {
//        private readonly IOrderRequestEngine _engine;
//        private readonly IOrderRequestEngine _orderRequestEngine;


//        public OrderRequestService(IOrderRequestEngine engine)
//        {
//            _engine = engine;
//        }

//        public async Task<ActionResult<OrderRequest>> PlaceOrderRequestAsync(OrderRequest request)
//        {
//            return await _engine.PlaceOrderRequestAsync(request);
//        }

//        public async Task<ActionResult<IEnumerable<OrderRequest>>> GetApprovedOrdersByHawkerIdAsync(int hawkerId)
//        {
//            return await _engine.GetApprovedOrdersByHawkerIdAsync(hawkerId);
//        }

//        public async Task<ActionResult<IEnumerable<OrderRequest>>> GetOrderHistoryByHawkerIdAsync(int hawkerId)
//        {
//            return await _engine.GetOrderHistoryByHawkerIdAsync(hawkerId);
//        }


//        // 🔹 NEW: Vendor methods
//        //public async Task<ActionResult<IEnumerable<OrderRequest>>> GetRequestsByVendorIdAsync(int vendorId)
//        //{
//        //    var requests = await _engine.GetRequestsByVendorIdAsync(vendorId);
//        //    //return new ActionResult<IEnumerable<OrderRequest>>(requests);

//        //    if (result.Result is NotFoundResult || result.Value == null)
//        //    {
//        //        return new List<OrderRequest>(); // or handle as needed
//        //    }

//        //    return result.Value;

//        //}
//        public async Task<IEnumerable<OrderRequest>> GetRequestsByVendorIdAsync(int vendorId)
//        {
//            var response = await _orderRequestEngine.GetRequestsByVendorIdAsync(vendorId);

//            if (response == null || response.Result is NotFoundResult || response.Value == null)
//            {
//                return new List<OrderRequest>(); // Return empty list if not found or null
//            }

//            return response.Value;
//        }


//        public async Task<ActionResult<IEnumerable<OrderRequest>>> GetRequestsByHawkerIdAsync(int hawkerId)
//        {
//            var requests = await _engine.GetRequestsByHawkerIdAsync(hawkerId);
//            return new ActionResult<IEnumerable<OrderRequest>>(requests);
//        }
//    }
//}


using Microsoft.AspNetCore.Mvc;
using StreetSupply.Interfaces.Engines;
using StreetSupply.Interfaces.Services;
using StreetSupply.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StreetSupply.Services
{
    public class OrderRequestService : IOrderRequestService
    {
        private readonly IOrderRequestEngine _orderRequestEngine;

        public OrderRequestService(IOrderRequestEngine orderRequestEngine)
        {
            _orderRequestEngine = orderRequestEngine;
        }

        public async Task<ActionResult<IEnumerable<OrderRequest>>> GetRequestsByVendorIdAsync(int vendorId)
        {
            return await _orderRequestEngine.GetRequestsByVendorIdAsync(vendorId);
        }

        public async Task<ActionResult<IEnumerable<OrderRequest>>> GetRequestsByHawkerIdAsync(int hawkerId)
        {
            return await _orderRequestEngine.GetRequestsByHawkerIdAsync(hawkerId);
        }

        public async Task<ActionResult<OrderRequest>> PlaceOrderRequestAsync(OrderRequest request)
        {
            return await _orderRequestEngine.PlaceOrderRequestAsync(request);
        }

        public async Task<ActionResult<IEnumerable<OrderRequest>>> GetApprovedOrdersByHawkerIdAsync(int hawkerId)
        {
            return await _orderRequestEngine.GetApprovedOrdersByHawkerIdAsync(hawkerId);
        }

        public async Task<ActionResult<IEnumerable<OrderRequest>>> GetOrderHistoryByHawkerIdAsync(int hawkerId)
        {
            return await _orderRequestEngine.GetOrderHistoryByHawkerIdAsync(hawkerId);
        }
    }
}

