using FreightTrack.Application.Interface;
using FreightTrack.Domain.Models;
using FreightTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreightTrack.Infrastructure.Repositories
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly FreightTrackDbContext _context;
        public ShipmentRepository(FreightTrackDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Shipment shipment)
        {
           await _context.Shipments.AddAsync(shipment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var shipment = await _context.Shipments.FindAsync(id);
            if (shipment != null) {
            _context.Shipments.Remove(shipment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Shipment>> GetAllAsync()
        {
            return await _context.Shipments.ToListAsync();
        }

        public async Task<Shipment> GetByIdAsync(int id)
        {
            return await _context.Shipments.FindAsync(id);
        }

        public async Task UpdateAsync(Shipment shipment)
        {
            _context.Shipments.Update(shipment);
            await _context.SaveChangesAsync();
        }
    }
}
