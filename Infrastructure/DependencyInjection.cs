using Application.Services;
using Application.Services.StaffServices;
using Domain.Models.Auth.Authentication;
using Domain.Models.Auth.Interfaces;
using Domain.Repositories;
using Domain.Repositories.Staff;
using Domain.Repositories.StaffRepo;
using Infrastructure.Repository;
using Infrastructure.Repository.Staff;
using Infrastructure.Repository.StaffRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleFeatureRepository, RoleFeatureRepository>();
            services.AddScoped<IFeatureRepository, FeatureRepository>();
            services.AddScoped<IStaffAuthService, StaffAuthService>();
            services.AddScoped<ICredentialsAuthenticator, CredentialsAuthenticator>();
            services.AddScoped<IPasswordHasher, BcryptPasswordHasher>();
            services.AddScoped<ITokenService, TokenService>();
            return services;
        }
    }
}
