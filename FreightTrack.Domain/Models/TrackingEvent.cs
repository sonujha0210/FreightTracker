using System;
using System.Collections.Generic;
using System.Text;

namespace FreightTrack.Domain.Models
{
    public class TrackingEvent
    {
        public int Id { get; set; }
        public int ShipmentId { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public DateTime Timestamp { get; set; }
        public string Notes { get; set; }

        public Shipment Shipment { get; set; }
    }
}
