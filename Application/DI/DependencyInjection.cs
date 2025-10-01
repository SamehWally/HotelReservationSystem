
using Application.Services;
using Application.Services.StaffServices;
using Domain.Models.Auth.Authentication;
using Domain.Models.Auth.Interfaces;
using Domain.Repositories.Staff;

using Application.Services;

using Microsoft.Extensions.DependencyInjection;

namespace Application.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<RoomService>();
            services.AddScoped<ReservationService>();

            services.AddScoped<TokenService>();
            services.AddScoped<StaffAuthService>();
            services.AddScoped<CredentialsAuthenticator>();
            services.AddScoped<BcryptPasswordHasher>();
            services.AddScoped<StaffService>();

            return services;
        }
    }
}
