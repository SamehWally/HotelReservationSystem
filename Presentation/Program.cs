using AutoMapper;
using Application;
using Infrastructure;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Presentation.Middlewares;
using Domain.Models.Room;
using Application.DTOs.Mapping;
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

            //AutoMapper
            builder.Services.AddAutoMapper(typeof(RoomProfileViewModel).Assembly,
                typeof(RoomProfileDto).Assembly);

            builder.Services.AddScoped<GlobalErrorHandlerMiddleware>();
            builder.Services.AddAutoMapper(typeof(ReservationProfile));


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
