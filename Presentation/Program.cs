using Application;
using Application.DTOs.Mapping;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Models.Auth.Models;
using Domain.Models.Room;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
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

            //AutoMapper
            builder.Services.AddAutoMapper(typeof(RoomProfileViewModel).Assembly,
                typeof(RoomProfileDto).Assembly);

            //JWT Authentication
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

            builder.Services.AddAuthorization();


            builder.Services.AddScoped<GlobalErrorHandlerMiddleware>();

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

            app.MapControllers();

            app.Run();
        }
    }
}
