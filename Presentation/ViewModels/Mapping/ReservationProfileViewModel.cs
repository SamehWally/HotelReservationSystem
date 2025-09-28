using Application.DTOs.Reservation;
using AutoMapper;
using Domain.Models.Reservation;
using Presentation.ViewModels.Mapping.Resrvation;

public class ReservationProfile : Profile
{
    public ReservationProfile()
    {
        // GetById => DTO
        CreateMap<Reservation, ReservationDto>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

        // GetDetails => ViewModel
        CreateMap<Reservation, ReservationDetailsViewModel>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
    }
}