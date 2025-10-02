using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Enums.RoomType;
using Domain.Models;
using Domain.Models.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.DTOs.Room;
using Domain.Repositories;

namespace Application.Services
{
    public class RoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public RoomService(IRoomRepository roomRepository, IMapper mapper)
        {
            _roomRepository = roomRepository;
            _mapper = mapper;
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
        public  GetRoomDto? GetRoomById(int id)
        {
            var room = _roomRepository.GetRoomById(id);
            var roomDto = _mapper.Map<GetRoomDto>(room);
            return roomDto;
        }
        public IEnumerable<GetAllRoomsDto> GetAllRooms()
        {
            var query = _roomRepository.GetAllRooms();
            var roomsDTO = query.Select(room => new GetAllRoomsDto
            {
                Id = room.Id,
                Name = room.Name,
                Type = (int)room.Type,
                PricePerNight = room.PricePerNight,
                Description = room.Description,
                PictureUrls = room.Pictures.Select(p => new RoomPictureDto { Url = p.Url, Id = p.Id }).ToList(),
                RoomFasilities = room.RoomFacilities.Select(rf => new RoomFacilityDto
                {
                    Id = rf.Facility.Id,
                    Name = rf.Facility.Name,

                }).ToList()
            }).ToList();
            return roomsDTO;

        }
        public async Task<IEnumerable<AvailableRoomsDto>> GetAllAvailableRooms(DateTime checkIn, DateTime checkOut)
        {
            var query = _roomRepository.GetAvailableRooms(checkIn, checkOut);

            var avilableRooms = await query
                .AsNoTracking()
                .ProjectTo<AvailableRoomsDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return avilableRooms;
        }
        public void UpdateRoom(EditRoomDto roomDTO)
        {
            var roomInDb = _roomRepository.GetRoomById(roomDTO.Id);
            if (roomInDb == null)
                throw new ArgumentException($"Room with ID {roomDTO.Id} not found");
            roomInDb.Name = roomDTO.Name;
            roomInDb.Type = (RoomType)roomDTO.Type;
            roomInDb.PricePerNight = roomDTO.PricePerNight;
            roomInDb.Description = roomDTO.Description;
            roomInDb.RoomFacilities.Clear();
            roomInDb.RoomFacilities = roomDTO.FacilityIds
                .Select(id => new RoomFacility { FacilityId = id, RoomId = roomInDb.Id })
                .ToList();
            roomInDb.Pictures.Clear();
            roomInDb.Pictures = roomDTO.PictureUrls
                .Select(url => new RoomPicture { Url = url, RoomId = roomInDb.Id })
                .ToList();

            _roomRepository.UpdateRoom(roomInDb);
        }
        public bool SoftDeleteRoom(int id)
        {

            var room = _roomRepository.GetRoomById(id);
            if (room == null)
            {
                return false;
            }
            _roomRepository.DeleteRoom(id);
            return true;
        }
    }
}