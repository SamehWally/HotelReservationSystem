using Application.DTOs.Reservation;
using AutoMapper;
using Domain.Models.Reservation;
using Domain.Enums;

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

            CreateMap<AddReservationDto, Domain.Models.Reservation.Reservation>().ReverseMap();
            CreateMap<Domain.Models.Reservation.Reservation, ReservationResponse>();

            CreateMap<CancelReservationDto, Domain.Models.Reservation.Reservation>()
             .ForMember(dest => dest.Status, opt => opt.MapFrom(src => ReservationStatus.Canceled));

            CreateMap<ConfirmReservationDto, Domain.Models.Reservation.Reservation>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => ReservationStatus.Confirmed));
                
            CreateMap<UpdateReservationDto, Reservation>()
             .ForMember(d => d.RoomId, o => o.MapFrom(s => s.Id))
             .ForMember(d => d.CheckIn, o => o.MapFrom(s => s.CheckIn))
             .ForMember(d => d.CheckOut, o => o.MapFrom(s => s.CheckOut))
             .ForMember(d => d.Status, o => o.MapFrom(o => o.Status));

            CreateMap<UpdateReservationDateDto, Reservation>()
             .ForMember(d => d.RoomId, o => o.MapFrom(s => s.Id))
             .ForMember(d => d.CheckIn, o => o.MapFrom(s => s.CheckIn))
             .ForMember(d => d.CheckOut, o => o.MapFrom(s => s.CheckOut));

            //Reservation  -->  GetReservationByRoomIdDto
            CreateMap<Reservation, GetReservationByRoomIdDto>()
            .ForMember(d => d.Id, o => o.MapFrom(s => s.RoomId))
            .ForMember(d => d.CheckIn, o => o.MapFrom(s => s.CheckIn))
            .ForMember(d => d.CheckOut, o => o.MapFrom(s => s.CheckOut))
            .ForMember(d => d.Status, o => o.MapFrom(s => s.Status));
        }
    }
}
