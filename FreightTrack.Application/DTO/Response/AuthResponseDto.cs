using System;
using System.Collections.Generic;
using System.Text;

namespace FreightTrack.Application.DTO.Response
{
    public class AuthResponseDto
    {

        public string Token { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
    }
}
