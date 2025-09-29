using Application;

using Application.DTOs;
using Application.DTOs.Mapping;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Models.Room;
using Domain.Repositories;
using Infrastructure.Repository;

using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
