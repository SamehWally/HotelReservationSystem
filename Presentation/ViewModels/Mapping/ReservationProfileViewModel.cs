
﻿using Application.DTOs.Reservation;
using AutoMapper;
using Presentation.ViewModels.Reservation;

﻿using Application.DTOs.Reservation;
using AutoMapper;
using Presentation.ViewModels.Reservation;

using Application.DTOs;
using AutoMapper;

namespace Presentation.ViewModels.Mapping
{
    public class ReservationProfileViewModel : Profile
    {
        public ReservationProfileViewModel()
        {
            CreateMap<AddReservationDto, AddReservationVM>().ReverseMap();

            CreateMap<CancelReservationViewModel,CancelReservationDto>().ReverseMap();
            CreateMap<ConfirmReservationViewModel,ConfirmReservationDto>().ReverseMap();

            //      UpdateReservationVM <-> UpdateReservationDto
            CreateMap<UpdateReservationVM, UpdateReservationDto>().ReverseMap();

            CreateMap<UpdateReservationDateVM, UpdateReservationDateDto>().ReverseMap();

            // VM <-> DTO
            CreateMap<GetReservationByRoomIdDto, GetReservationByRoomIdVM>().ReverseMap();
        }
    }
}
