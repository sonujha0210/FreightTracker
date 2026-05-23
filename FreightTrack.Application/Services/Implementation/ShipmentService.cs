using FreightTrack.Application.DTO.Request;
using FreightTrack.Application.DTO.Response;
using FreightTrack.Application.Interface;
using FreightTrack.Application.Services.Interface;
using FreightTrack.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreightTrack.Application.Services.Implementation
{
    public class ShipmentService : IShipmentService
    {
        private readonly IShipmentRepository _shipmentRepository;

        public ShipmentService(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        public async Task<IEnumerable<ShipmentDto>> GetAllAsync()
        {
            var shipments = await _shipmentRepository.GetAllAsync();

            return shipments.Select(s => new ShipmentDto
            {
                Id = s.Id,
                TrackingNumber = s.TrackingNumber,
                Status = s.Status,
                Origin = s.Origin,
                Destination = s.Destination,
                CustomerId = s.CustomerId,
                CreatedAt = s.CreatedAt
            });
        }

        public async Task<ShipmentDto> GetByIdAsync(int id)
        {
            var shipment = await _shipmentRepository.GetByIdAsync(id);

            if (shipment == null) return null;


            return new ShipmentDto
            {
                Id = shipment.Id,
                TrackingNumber = shipment.TrackingNumber,
                Status = shipment.Status,
                Origin = shipment.Origin,
                Destination = shipment.Destination,
                CustomerId = shipment.CustomerId,
                CreatedAt = shipment.CreatedAt
            };
        }

        public async Task AddAsync(CreateShipmentDto dto)
        {
            var shipment = new Shipment
            {
                Origin = dto.Origin,
                Destination = dto.Destination,
                CustomerId = dto.CustomerId,
                Status = "Created",
                TrackingNumber = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.UtcNow
            };

            await _shipmentRepository.AddAsync(shipment);
        }

       
       public async Task UpdateAsync(int id, CreateShipmentDto dto)
        {
            var shipment = await _shipmentRepository.GetByIdAsync(id);
            if (shipment == null) return;
            shipment.Origin = dto.Origin;
            shipment.Destination = dto.Destination;
            shipment.UpdatedAt = DateTime.UtcNow;

            await _shipmentRepository.UpdateAsync(id, shipment);
        }

        public Task DeleteAsync(int id)
        {
            return _shipmentRepository.DeleteAsync(id);
        }
        public async Task AddTrackingEventAsync(int shipmentId, AddTrackingEventDto dto)
        {
            var trackingEvent = new TrackingEvent
            {
                Status = dto.Status,
                Location = dto.Location,
                Notes = dto.Notes
            };

            await _shipmentRepository.AddTrackingEventAsync(shipmentId, trackingEvent);
        }

        public async Task<IEnumerable<TrackingEventDto>> GetTrackingHistoryAsync(int shipmentId)
        {
            var events = await _shipmentRepository.GetTrackingHistoryAsync(shipmentId);

            return events.Select(e => new TrackingEventDto
            {
                Id = e.Id,
                Status = e.Status,
                Location = e.Location,
                Timestamp = e.Timestamp,
                Notes = e.Notes
            });
        }
        public async Task<IEnumerable<ShipmentDto>> GetFilteredAsync(ShipmentFilterDto filter)
        {
            var shipments = await _shipmentRepository.GetFilteredAsync(filter);

            return shipments.Select(s => new ShipmentDto
            {
                Id = s.Id,
                TrackingNumber = s.TrackingNumber,
                Status = s.Status,
                Origin = s.Origin,
                Destination = s.Destination,
                CustomerId = s.CustomerId,
                CreatedAt = s.CreatedAt
            });
        }
    }
}
