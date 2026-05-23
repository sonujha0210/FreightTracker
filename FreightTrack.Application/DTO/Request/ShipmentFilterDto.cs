using System;
using System.Collections.Generic;
using System.Text;

namespace FreightTrack.Application.DTO.Request
{
    public class ShipmentFilterDto
    {
        public string Status { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
