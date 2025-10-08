using Application.Helpers.PWHashing;
using Application.SecurityInterfaces;
using Application.Services;
using Domain.Models.Auth.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<RoomService>();
            services.AddScoped<ReservationService>();
            services.AddScoped<Application.Services.CustomerService>();
            services.AddScoped<ICredentialsAuthenticator, CredentialsAuthenticator>();
            services.AddScoped<IPasswordHasher, BcryptPasswordHasher>();
            services.AddScoped<ITokenService, TokenService>();  

            return services;
        }
    }
}
