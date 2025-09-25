using Application.DTOs;
using AutoMapper;

namespace Presentation.ViewModels.Mapping
{
    public class ReservationProfileViewModel : Profile
    {
        public ReservationProfileViewModel()
        {
            //      UpdateReservationVM <-> UpdateReservationDto
            CreateMap<UpdateReservationVM, UpdateReservationDto>().ReverseMap();
        }
    }
}
