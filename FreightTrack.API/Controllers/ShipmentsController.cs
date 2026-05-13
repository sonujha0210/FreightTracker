using FreightTrack.Application.Services.Implementation;
using FreightTrack.Application.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FreightTrack.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentsController : ControllerBase
    {
        private readonly IShipmentService _shipmentService;
        public ShipmentsController(IShipmentService shipmentService)
        {
             _shipmentService = shipmentService;
        }
        [HttpGet("GetAllShipment")]
        public async Task<IActionResult> GetAllShipmentAsync()
        {
            var Shipment = await _shipmentService.GetAllAsync();
            return Ok(Shipment);
        }
        [HttpGet("GetShipmentById{Id}")]
        public async Task<IActionResult>GetShipmentById(int Id)
        {
            var shipments = await _shipmentService.GetByIdAsync(Id);
            if(Id == null)
            {
                return NotFound();
            }
            return Ok(shipments);

        }
    }
}
