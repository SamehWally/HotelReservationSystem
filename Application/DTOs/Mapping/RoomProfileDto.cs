using Application.DTOs.Room;
using AutoMapper;
using Domain.Enums.RoomType;
using Domain.Models.Room;

namespace Application.DTOs.Mapping
{
    public class RoomProfileDto : Profile
    {
        public RoomProfileDto()
        {
            //Room -> AvilableRoomsDto
            CreateMap<Domain.Models.Room.Room, AvailableRoomsDto>()
                .ForMember(d => d.Type, o => o.MapFrom(s => (int)s.Type))
                .ForMember(d => d.PictureUrls, o => o.MapFrom(s => s.Pictures.Select(p => p.Url)))
                .ForMember(d => d.FacilityIds, o => o.MapFrom(s => s.RoomFacilities.Select(rf => rf.FacilityId)));

            //AvilableRoomsDto -> Room
            CreateMap<AvailableRoomsDto, Domain.Models.Room.Room>()
                .ForMember(s => s.Type, o => o.MapFrom(d => (RoomType)d.Type))
                .ForMember(s => s.Pictures, o => o.MapFrom(d => d.PictureUrls.Select(u => new RoomPicture { Url = u })))
                .ForMember(s => s.RoomFacilities, o => o.MapFrom(d => d.FacilityIds.Select(id => new RoomFacility { FacilityId = id })))
                .ForMember(s => s.Reservations, o => o.Ignore())
                .ForMember(s => s.IsAvailable, o => o.Ignore());


            //Room -> GetRoomDto
            CreateMap<Domain.Models.Room.Room, GetRoomDto>()
            .ForMember(d => d.Type, o => o.MapFrom(s => s.Type.ToString()))
            .ForMember(d => d.Facilities, o => o.MapFrom(s => s.RoomFacilities.Select(rf => rf.FacilityId)))
            .ForMember(d => d.Pictures, o => o.MapFrom(s => s.Pictures.Select(p => p.Url)));


        }
    }
}
