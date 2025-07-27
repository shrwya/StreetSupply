using Microsoft.AspNetCore.Mvc;
using StreetSupply.Interfaces.Services;
using StreetSupply.Models;

namespace StreetSupply.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _vendorService;

        public VendorController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendor>>> GetAllVendors()
        {
            return await _vendorService.GetAllVendorsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vendor>> GetVendorById(int id)
        {
            return await _vendorService.GetVendorByIdAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<Vendor>> CreateVendor(Vendor vendor)
        {
            return await _vendorService.CreateVendorAsync(vendor);
        }

        [HttpGet("{vendorId}/requests")]
        public async Task<ActionResult<IEnumerable<OrderRequest>>> GetRequestsByVendorId(int vendorId)
        {
            return await _vendorService.GetRequestsByVendorIdAsync(vendorId);
        }
    }
}
