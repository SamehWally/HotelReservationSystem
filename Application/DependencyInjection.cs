using Application.Services;
using Domain.Models.Auth.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<RoomService>();
            services.AddScoped<ReservationService>();
            services.AddScoped<TokenService>();
            return services;
        }
    }
}
