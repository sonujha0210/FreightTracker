using System;
using System.Collections.Generic;
using System.Text;

namespace FreightTrack.Application.DTO.Request
{
    public class CreateCustomerDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
