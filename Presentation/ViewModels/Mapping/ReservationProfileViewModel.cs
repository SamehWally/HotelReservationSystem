using Application.DTOs;
using AutoMapper;

namespace Presentation.ViewModels.Mapping
{
    public class ReservationProfileViewModel : Profile
    {
        public ReservationProfileViewModel()
        {
            // VM <-> DTO
            CreateMap<GetReservationByRoomIdDto, GetReservationByRoomIdVM>().ReverseMap();
        }
    }
}
