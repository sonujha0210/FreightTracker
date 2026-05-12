using System;
using System.Collections.Generic;
using System.Text;

namespace FreightTrack.Application.DTO.Response
{
    public class ShipmentDto
    {
        public int Id { get; set; }
        public string TrackingNumber { get; set; }
        public string Status { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
