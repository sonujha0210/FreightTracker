using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FreightTrack.Domain.Models
{
    public class Shipment
    {
        [Key]
        public int Id { get; set; }
        public string TrackingNumber { get; set; }

        public string Status { get; set; } 
        public string Origin { get; set; }
        public string Destination {  get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Customer Customer { get; set; }
        public ICollection<TrackingEvent> TrackingEvents { get; set; }


    }
}
