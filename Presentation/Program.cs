using Application.DI;
using Application.DTOs.Mapping;
using Application.DTOs.Reservation;
using Application.Mappings;
using Domain.Models.Auth.Models;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Presentation.Middlewares;
using Presentation.ViewModels.Mapping;
using System.Security.Claims;

namespace Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<GlobalErrorHandlerMiddleware>();
            builder.Services.AddScoped<TransactionMiddleware>();
            builder.Services.AddAuthorization();

            //JWT Authentication
            #region JWT
            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
            var jwt = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();
            var key = System.Text.Encoding.ASCII.GetBytes(jwt.Key);
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwt.Issuer,
                        ValidateAudience = true,
                        ValidAudience = jwt.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        NameClaimType = ClaimTypes.Name,
                        RoleClaimType = ClaimTypes.Role
                    };
                });
            #endregion

            //AutoMapper
            #region AutoMapper
            builder.Services.AddAutoMapper(
            typeof(RoomProfileViewModel).Assembly,
            typeof(RoomProfileDto).Assembly,
            typeof(TokenProfileViewModel).Assembly,
            typeof(StaffProfileDto).Assembly,
            typeof(StaffProfileViewModel).Assembly,
            typeof(ReservationProfileViewModel).Assembly,
            typeof(UpdateReservationDto).Assembly,
            typeof(ReservationProfile).Assembly);
            #endregion


            var app = builder.Build();

            app.UseMiddleware<GlobalErrorHandlerMiddleware>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseStaticFiles();

            app.UseMiddleware<TransactionMiddleware>();
            app.MapControllers();

            app.Run();
        }
    }
}
