
﻿using Application.DTOs.Room.DTO;


﻿using Application.DTOs.Reservation;

using AutoMapper;
using Domain.Models.Reservation;
using Presentation.ViewModels.Mapping.Resrvation;


﻿using Application.DTOs.Reservation;
using AutoMapper;
using Presentation.ViewModels.Reservation;

﻿using Application.DTOs.Reservation;
using AutoMapper;
using Presentation.ViewModels.Reservation;

using Application.DTOs;
using AutoMapper;
using Presentation.ViewModels;

public class ReservationProfileViewModel : Profile
{
    public ReservationProfileViewModel()
    {

        // GetById => DTO
        CreateMap<Reservation, ReservationDto>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

        // GetDetails => ViewModel
        CreateMap<Reservation, ReservationDetailsViewModel>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));


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