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

        public IEnumerable<Room> GetAllRooms() 
        {
            return _roomRepository.GetAllRooms();
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
     
        public bool SoftDeleteRoom(int id)
        {

            var room = _roomRepository.GetRoomById(id);
            if (room==null)
            {
                return false;
            }
            _roomRepository.DeleteRoom(id);
            return true;


        }

    }
}
