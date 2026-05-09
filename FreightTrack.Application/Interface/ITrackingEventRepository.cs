using FreightTrack.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FreightTrack.Application.Interface
{
    public  interface ITrackingEventRepository
    {
        Task AddAsync(TrackingEvent trackingEvent);
        Task<IEnumerable<TrackingEvent>> GetByShipmentIdAsync(int shipmentId);

    }
}
