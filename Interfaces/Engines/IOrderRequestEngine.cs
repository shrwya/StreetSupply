using Microsoft.AspNetCore.Mvc;
using StreetSupply.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StreetSupply.Interfaces.Engines
{
    public interface IOrderRequestEngine
    {
        Task<ActionResult<OrderRequest>> PlaceOrderRequestAsync(OrderRequest request);
        Task<ActionResult<IEnumerable<OrderRequest>>> GetApprovedOrdersByHawkerIdAsync(int hawkerId);
        Task<ActionResult<IEnumerable<OrderRequest>>> GetOrderHistoryByHawkerIdAsync(int hawkerId);
        //Task<IEnumerable<OrderRequest>> GetRequestsByHawkerIdAsync(int hawkerId);
        Task<ActionResult<IEnumerable<OrderRequest>>> GetRequestsByVendorIdAsync(int vendorId);
        Task<ActionResult<IEnumerable<OrderRequest>>> GetRequestsByHawkerIdAsync(int hawkerId);

      
       


    }
}

