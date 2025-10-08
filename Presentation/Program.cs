using System.Text;
using Application;
using Application.DTOs;
using Application.DTOs.Mapping;
using Application.Helpers;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Models.Room;
using Domain.Repositories;
using Infrastructure;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using Presentation.Middlewares;
using Presentation.ViewModels.Mapping;
using Application.DTOs.Reservation;
using Application.DI;

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
            //builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));
            //var jwt = builder.Configuration.GetSection("Jwt").Get<JwtOptions>();
            //var key = System.Text.Encoding.ASCII.GetBytes(jwt.Key);
            //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.RequireHttpsMetadata = false;
            //        options.SaveToken = true;
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateIssuer = true,
            //            ValidIssuer = jwt.Issuer,
            //            ValidateAudience = true,
            //            ValidAudience = jwt.Audience,
            //            ValidateIssuerSigningKey = true,
            //            IssuerSigningKey = new SymmetricSecurityKey(key),
            //            ValidateLifetime = true,
            //            ClockSkew = TimeSpan.Zero,
            //            NameClaimType = ClaimTypes.Name,
            //            RoleClaimType = ClaimTypes.Role
            //        };
            //    });
            #endregion

            //AutoMapper
            builder.Services.AddAutoMapper(typeof(RoomProfileViewModel).Assembly,
                typeof(RoomProfileDto).Assembly);
            builder.Services.AddAutoMapper(typeof(ReservationProfileViewModel).Assembly,
                typeof(UpdateReservationDto).Assembly);

            builder.Services.AddScoped<GlobalErrorHandlerMiddleware>();
            // builder.Services.AddAutoMapper(typeof(ReservationProfile));


            #region Jwt
            var key = Encoding.ASCII.GetBytes(Constant.SecretKey);
            builder.Services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    //Define the Secret Key used for encrypting the token
                    IssuerSigningKey = new SymmetricSecurityKey(key),

                    //set of parameters to be validated (who Generate the Toke)
                    ValidIssuer = "yourdomain.com",

                    //set of parameters to be validated (who will use the Toke)
                    ValidAudience = "yourdomain.com-Front",

                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,

                };
            }); 
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
