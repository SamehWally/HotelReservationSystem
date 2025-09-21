using Application.DTOs.Room;
using Domain.Enums.RoomType;
using Domain.Models;
using Domain.Models.Room;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class RoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public int AddRoom(AddRoomDto roomDto) 
        {
            if (string.IsNullOrWhiteSpace(roomDto.Name) || roomDto.PricePerNight <= 0)
                throw new ArgumentException("Invalid room data");

            var newRoom = new Room
            {
                Name = roomDto.Name,
                Type = (RoomType)roomDto.Type,
                PricePerNight = roomDto.PricePerNight,
                Description = roomDto.Description,
                RoomFacilities = roomDto.FacilityIds
                                .Select(id => new RoomFacility { FacilityId = id })
                                .ToList(),
                Pictures = roomDto.PictureUrls
                                .Select(url => new RoomPicture { Url = url })
                                .ToList()
            };
            _roomRepository.AddRoom(newRoom);
            return newRoom.Id;
        }

        public GetRoomDto? GetRoomById(int id) 
        {
            var room = _roomRepository.GetRoomById(id);
            var roomDTO = new GetRoomDto
            {
                Id = room.Id,
                Name = room.Name
            };
            return roomDTO;
        }

        public IEnumerable<GetAllRoomsDto> GetAllRooms() 
        {
            var query=_roomRepository.GetAllRooms();
            var roomsDTO = query.Select(room => new GetAllRoomsDto
            {
                Id = room.Id,
                Name = room.Name,
                Type = (int)room.Type,
                PricePerNight = room.PricePerNight,
                Description = room.Description,
                PictureUrls = room.Pictures.Select(p => new RoomPictureDto { Url = p.Url ,Id=p.Id}).ToList(),
                RoomFasilities = room.RoomFacilities.Select(rf => new RoomFacilityDto
                {
                    Id = rf.Facility.Id,
                    Name = rf.Facility.Name,
                    
                }).ToList()
            }).ToList();
            return roomsDTO;

        }

        public void UpdateRoom(EditRoomDto roomDTO) 
        {
            var roomInDb = _roomRepository.GetRoomById(roomDTO.Id);
            if (roomInDb == null) 
            {
                roomInDb!.Name = roomDTO.Name;
            }

            _roomRepository.UpdateRoom(roomInDb);
        }
    }
}
