using Microsoft.AspNetCore.Mvc;
using StreetSupply.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StreetSupply.Interfaces.Services
{
    public interface IHawkerService
    {
        Task<ActionResult<Hawker>> CreateHawkerAsync(Hawker hawker);
        Task<ActionResult<IEnumerable<Vendor>>> GetNearbyVendorsAsync(string pincode);
        Task<ActionResult> SendOrderRequestAsync(OrderRequest request);
        Task<ActionResult<IEnumerable<OrderRequest>>> GetOrderStatusAsync(int hawkerId);
        Task<ActionResult<IEnumerable<OrderHistory>>> GetOrderHistoryAsync(int hawkerId);
    }
}
