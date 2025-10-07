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
           // builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
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

            app.UseAuthorization();

            app.UseStaticFiles();

            app.MapControllers();

            app.Run();
        }
    }
}
