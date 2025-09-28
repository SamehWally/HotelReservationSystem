using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Reservation;
using Domain.Models.Reservation;
using AutoMapper;
using Domain.Enums;

namespace Application.DTOs.Mapping
{
    internal class ReservationProfileDto : Profile
    {
        public ReservationProfileDto() 
        {
            CreateMap<CancelReservationDto, Domain.Models.Reservation.Reservation>()
             .ForMember(dest => dest.Status, opt => opt.MapFrom(src => ReservationStatus.Canceled));

            CreateMap<ConfirmReservationDto, Domain.Models.Reservation.Reservation>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => ReservationStatus.Confirmed));
                
        }
    }
}
