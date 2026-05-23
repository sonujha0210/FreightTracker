using FreightTrack.Application.DTO.Request;
using FreightTrack.Application.Services.Implementation;
using FreightTrack.Application.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace FreightTrack.API.Controllers
{
    [Authorize]

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
        [HttpPost]
        public async Task<IActionResult> CreateShipment([FromBody] CreateShipmentDto dto)
        {
            await _shipmentService.AddAsync(dto);
            return Ok("Shipment created successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateShipment(int id, [FromBody] CreateShipmentDto dto)
        {
            await _shipmentService.UpdateAsync(id, dto);
            return Ok("Shipment updated successfully");
        }
        [Authorize(Roles ="Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShipment(int id)
        {
            await _shipmentService.DeleteAsync(id);
            return Ok("Shipment deleted successfully");
        }
        [HttpPost("{id}/events")]
        public async Task<IActionResult> AddTrackingEvent(int id, [FromBody] AddTrackingEventDto dto)
        {
            await _shipmentService.AddTrackingEventAsync(id, dto);
            return Ok("Tracking event added successfully");
        }

        [HttpGet("{id}/history")]
        public async Task<IActionResult> GetTrackingHistory(int id)
        {
            var history = await _shipmentService.GetTrackingHistoryAsync(id);
            return Ok(history);
        }
        [HttpGet("filter")]
        public async Task<IActionResult> GetFiltered([FromQuery] ShipmentFilterDto filter)
        {
            var result = await _shipmentService.GetFilteredAsync(filter);
            return Ok(result);
        }
        [HttpGet("export")]
        public async Task<IActionResult> ExportShipments()
        {
            var shipments = await _shipmentService.GetAllAsync();

            var csv = new StringBuilder();
            csv.AppendLine("Id,TrackingNumber,Status,Origin,Destination,CustomerId,CreatedAt");

            foreach (var s in shipments)
            {
                csv.AppendLine($"{s.Id},{s.TrackingNumber},{s.Status},{s.Origin},{s.Destination},{s.CustomerId},{s.CreatedAt}");
            }

            var bytes = Encoding.UTF8.GetBytes(csv.ToString());
            return File(bytes, "text/csv", "shipments.csv");
        }
    }
}
