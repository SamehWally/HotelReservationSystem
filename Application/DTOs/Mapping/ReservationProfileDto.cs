using Application.DTOs.Reservation;
using AutoMapper;
using Domain.Models.Reservation;

namespace Application.Mappings
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
           
            CreateMap<Reservation, SearchReservationDto>();

            CreateMap<Reservation, ReservationDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));

           
            CreateMap<Reservation, ReservationDetailsDto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()));
        }
    }
}
