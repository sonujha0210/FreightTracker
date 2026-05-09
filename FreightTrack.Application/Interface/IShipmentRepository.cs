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
        Task UpdateAsync(Shipment shipment);
        Task DeleteAsync(int id);
    }
}
