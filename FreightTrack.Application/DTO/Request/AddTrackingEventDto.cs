using System;
using System.Collections.Generic;
using System.Text;

namespace FreightTrack.Application.DTO.Request
{
    public class AddTrackingEventDto
    {
        public string Status { get; set; }
        public string Location { get; set; }
        public string Notes { get; set; }
    }
}
