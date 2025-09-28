using Application.DTOs.Reservation;
using AutoMapper;
using Presentation.ViewModels.Reservation;

namespace Presentation.ViewModels.Mapping
{
    public class ReservationProfileViewModel : Profile
    {
        public ReservationProfileViewModel()
        { 
            CreateMap<CancelReservationViewModel,CancelReservationDto>().ReverseMap();
            CreateMap<ConfirmReservationViewModel,ConfirmReservationDto>().ReverseMap();
        }
    }
}
