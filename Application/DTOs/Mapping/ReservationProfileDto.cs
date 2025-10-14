using Application.DTOs.Reservation;
using AutoMapper;
using Domain.Enums;
using Domain.Models.Reservation;

namespace Application.Mappings
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            #region GetAllReservations
            CreateMap<Reservation, GetAllReservationsDto>()
                .ForMember(dest => dest.RoomName, opt => opt.MapFrom(src => src.Room != null ? src.Room.Name : string.Empty))
                .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(src => src.Room != null ? src.Room.Number : 0))
                .ForMember(dest => dest.CustomerName, opt =>
                    opt.MapFrom(src => src.Customer != null && src.Customer.User != null
                        ? $"{src.Customer.User.FirstName} {src.Customer.User.LastName}"
                        : string.Empty));
            #endregion

            #region GetReservationsByCustomer
            CreateMap<Reservation, GetReservationsByCustomerDto>()
                .ForMember(dest => dest.RoomName, opt => opt.MapFrom(src => src.Room != null ? src.Room.Name : string.Empty))
                .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(src => src.Room != null ? src.Room.Number : 0))
                .ForMember(dest => dest.CustomerName, opt =>
                    opt.MapFrom(src => src.Customer != null && src.Customer.User != null
                        ? $"{src.Customer.User.FirstName} {src.Customer.User.LastName}"
                        : string.Empty))
                .ForMember(dest => dest.IsDeleted, opt => opt.MapFrom(src => src.IsDeleted))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => src.UpdatedDate))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy))
                .ForMember(dest => dest.UpdatedBy, opt => opt.MapFrom(src => src.UpdatedBy));
            #endregion

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
