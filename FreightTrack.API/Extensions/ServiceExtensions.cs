using FreightTrack.Application.Interface;
using FreightTrack.Application.Services.Implementation;
using FreightTrack.Application.Services.Interface;
using FreightTrack.Infrastructure.Repositories;

namespace FreightTrack.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IShipmentRepository, ShipmentRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IShipmentService, ShipmentService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
