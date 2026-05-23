using FreightTrack.Application.DTO.Request;
using FreightTrack.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreightTrack.Application.Interface
{
    public interface IShipmentRepository
    {
        Task<Shipment> GetByIdAsync(int id);
        Task<IEnumerable<Shipment>> GetAllAsync();
        Task AddAsync(Shipment shipment);
        Task UpdateAsync(int id, Shipment shipment);
        Task DeleteAsync(int id);
        Task AddTrackingEventAsync(int shipmentId, TrackingEvent trackingEvent);
        Task<IEnumerable<TrackingEvent>> GetTrackingHistoryAsync(int shipmentId);
        Task<IEnumerable<Shipment>> GetFilteredAsync(ShipmentFilterDto filter);
    }
}
