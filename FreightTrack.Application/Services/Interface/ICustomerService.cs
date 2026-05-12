using FreightTrack.Application.DTO.Request;
using FreightTrack.Application.DTO.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreightTrack.Application.Services.Interface
{
    public  interface ICustomerService
    {
        Task<CustomerDto> GetByIdAsync(int id);

        Task<CustomerDto> GetByEmailAsync(string email);

        Task AddAsync(CreateCustomerDto dto);
    }
}
