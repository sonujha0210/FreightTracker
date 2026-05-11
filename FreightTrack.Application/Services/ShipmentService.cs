using FreightTrack.Application.Interface;
using FreightTrack.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreightTrack.Application.Services
{
    public class ShipmentService
    {
        private readonly IShipmentRepository _shipmentRepository;
        public ShipmentService(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }
        public async Task<IEnumerable<Shipment>> GetAllShipment()
        {
            return await _shipmentRepository.GetAllAsync();
        }
        public async Task<Shipment> GetById(int id)
        { 
        return await _shipmentRepository.GetByIdAsync(id);
        }

        public async Task AddShipment(Shipment shipment)
        {
            await _shipmentRepository.AddAsync(shipment);
        }
        public async Task UpdateShipment(Shipment shipment)
        {
            await _shipmentRepository.UpdateAsync(shipment);
        }
        public async Task DeleteShipment(int id)
        {
            await _shipmentRepository.DeleteAsync(id);
        }

    }
}
