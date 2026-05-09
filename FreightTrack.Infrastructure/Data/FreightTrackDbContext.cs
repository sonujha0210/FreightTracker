using FreightTrack.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreightTrack.Infrastructure.Data
{
    public class FreightTrackDbContext : DbContext
    {
        public FreightTrackDbContext(DbContextOptions<FreightTrackDbContext> options) : base(options)
        {
        }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<TrackingEvent> TrackingEvents { get; set; }
    }
}
