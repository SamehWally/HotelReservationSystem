using Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<RoomService>();
            services.AddScoped<ReservationService>();
            // سجل باقي الخدمات هنا
            return services;
        }
    }
}
