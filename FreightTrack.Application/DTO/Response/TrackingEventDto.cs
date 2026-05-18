using System;
using System.Collections.Generic;
using System.Text;

namespace FreightTrack.Application.DTO.Response
{
    public class TrackingEventDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public DateTime Timestamp { get; set; }
        public string Notes { get; set; }
    }
}
