using Application.DTOs.Reservation;
using AutoMapper;
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
            CreateMap<Domain.Models.Reservation.Reservation, UpdateReservationStatusDto>().ReverseMap();
        }
    }
}
