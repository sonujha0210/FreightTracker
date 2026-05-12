using FreightTrack.Application.DTO.Request;
using FreightTrack.Application.DTO.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreightTrack.Application.Services.Interface
{
    public interface IShipmentService
    {
        Task<IEnumerable<ShipmentDto>> GetAllAsync();

        Task<ShipmentDto> GetByIdAsync(int id);

        Task AddAsync(CreateShipmentDto dto);
    }
}
