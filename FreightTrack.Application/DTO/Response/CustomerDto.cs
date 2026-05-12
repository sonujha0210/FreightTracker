using System;
using System.Collections.Generic;
using System.Text;

namespace FreightTrack.Application.DTO.Response
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
