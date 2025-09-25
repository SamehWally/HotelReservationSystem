using AutoMapper;
using Domain.Models.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Mapping
{
    internal class ReservationProfileDto : Profile
    {
        public ReservationProfileDto() 
        {
            CreateMap<UpdateReservationDto, Reservation>()
             .ForMember(d => d.RoomId, o => o.MapFrom(s => s.Id))
             .ForMember(d => d.CheckIn, o => o.MapFrom(s => s.CheckIn))
             .ForMember(d => d.CheckOut, o => o.MapFrom(s => s.CheckOut))
             .ForMember(d => d.Status, o => o.MapFrom(o => o.Status));

            CreateMap<UpdateReservationDateDto, Reservation>()
           .ForMember(d => d.RoomId, o => o.MapFrom(s => s.Id))
           .ForMember(d => d.CheckIn, o => o.MapFrom(s => s.CheckIn))
           .ForMember(d => d.CheckOut, o => o.MapFrom(s => s.CheckOut));
        }
    }
}
