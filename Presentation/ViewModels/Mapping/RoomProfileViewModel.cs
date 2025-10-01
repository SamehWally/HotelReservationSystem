using Application.DTOs.Room;
using AutoMapper;
using Domain.Enums.RoomType;
using Domain.Models.Room;
using Presentation.ViewModels.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.ViewModels.Mapping
{
    internal class RoomProfileViewModel : Profile
    {
        public RoomProfileViewModel()
        {
            // Room -> AvailableRoomsVM
            CreateMap<Domain.Models.Room.Room, AvailableRoomsVM>()
                .ForMember(d => d.Type, o => o.MapFrom(s => (int)s.Type))
                .ForMember(d => d.PictureUrls, o => o.MapFrom(s => s.Pictures.Select(p => p.Url)))
                .ForMember(d => d.FacilityIds, o => o.MapFrom(s => s.RoomFacilities.Select(rf => rf.FacilityId)));


            // AvailableRoomsVM -> Room
            CreateMap<AvailableRoomsVM, Domain.Models.Room.Room>()
                .ForMember(s => s.Type, o => o.MapFrom(d => (RoomType)d.Type))
                .ForMember(s => s.Pictures, o => o.MapFrom(d => d.PictureUrls.Select(u => new RoomPicture { Url = u })))
                .ForMember(s => s.RoomFacilities, o => o.MapFrom(d => d.FacilityIds.Select(id => new RoomFacility { FacilityId = id })))
                .ForMember(s => s.Reservations, o => o.Ignore())
                .ForMember(s => s.IsAvailable, o => o.Ignore());

            //AvailableRoomsDto -> AvailableRoomsVM
            CreateMap<AvailableRoomsDto, AvailableRoomsVM>().ReverseMap();

            CreateMap<GetRoomDto, GetRoomViewModel>().ReverseMap();
        }
    }
}
