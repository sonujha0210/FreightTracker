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
            var shipment = await _shipmentRepository.UpdateAsync(id, dto);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
