using System;
using System.Collections.Generic;
using System.Text;

namespace FreightTrack.Application.DTO.Request
{
    public class CreateShipmentDto
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public int CustomerId { get; set; }
    }
}
