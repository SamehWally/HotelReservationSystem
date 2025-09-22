using Application.DTOs.Room;
using Application.DTOs.Room.DTO;
using Application.Services;
using AutoMapper;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;
using Presentation.ViewModels.Response;
using Presentation.ViewModels.Room;
using Presentation.ViewModels.Room.Presentation.ViewModels.Room;
using System.Collections;

namespace Presentation.Controllers
{

    public class RoomController : BaseAPIsController
    {
        private readonly RoomService _roomService;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;

        public RoomController(RoomService roomService, IWebHostEnvironment env, IMapper mapper)
        {
            _roomService = roomService;
            _env = env;
            _mapper = mapper;
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<ResponseViewModel<int>> AddRoom([FromForm] AddRoomViewModel viewModel)
        {
            var pictureUrls = await SavePictures(viewModel.PictureUrls);

            var roomDto = new AddRoomDto
            {
                Name = viewModel.Name,
                Type = viewModel.Type,
                PricePerNight = viewModel.PricePerNight,
                Description = viewModel.Description,
                FacilityIds = viewModel.FacilityIds,
                PictureUrls = pictureUrls
            };

            var newRoomId = _roomService.AddRoom(roomDto);

            return new SuccessResponseViewModel<int>(newRoomId, "Room added successfully");
        }

        private async Task<List<string>> SavePictures(List<IFormFile> pictures)
        {
            var urls = new List<string>();
            var folderPath = Path.Combine(_env.WebRootPath, "images", "rooms");

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            var allowedTypes = new[] { "image/jpeg", "image/png", "image/webp" };
            const long maxSize = 5 * 1024 * 1024; // 5MB

            foreach (var picture in pictures)
            {
                if (!allowedTypes.Contains(picture.ContentType)) continue;
                if (picture.Length > maxSize) continue;

                var extension = Path.GetExtension(picture.FileName);
                var fileName = $"{Guid.NewGuid()}{extension}";
                var filePath = Path.Combine(folderPath, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await picture.CopyToAsync(stream);
                }

                urls.Add($"/images/rooms/{fileName}");
            }

            return urls;
        }
        [HttpPut]
        [Consumes("multipart/form-data")]
        public async Task<ResponseViewModel<string>> UpdateRoom([FromForm] EditRoomViewModel viewModel)
        {
            var pictureUrls = await SavePictures(viewModel.PictureUrls);

            var roomDto = new EditRoomDto
            {
                Id = viewModel.Id,
                Name = viewModel.Name,
                Type = viewModel.Type,
                PricePerNight = viewModel.PricePerNight,
                Description = viewModel.Description,
                FacilityIds = viewModel.FacilityIds,
                PictureUrls = pictureUrls
            };

            _roomService.UpdateRoom(roomDto);

            return new SuccessResponseViewModel<string>("Room updated successfully");
        }
        [HttpDelete("id")]
        public bool Delete(int id)
        {

            var success = _roomService.SoftDeleteRoom(id);
            if (!success)
            {
                return false;

            }

            return true;


        }
        [HttpGet("id")]
        public  ResponseViewModel<GetRoomViewModel> GetRoomById(int id)
        {
            var room = _roomService.GetRoomById(id);
            var roomVM = _mapper.Map<GetRoomViewModel>(room);

            if (roomVM is not null)
                return new SuccessResponseViewModel<GetRoomViewModel>(roomVM);
            
            return new ErrorResponseViewModel<GetRoomViewModel>(ErrorCode.RoomNotFound);
        }
        [HttpGet]
        public ResponseViewModel<List<GetAllRoomsViewModel>> GetAllRooms()
        {
            var rooms = _roomService.GetAllRooms();
            var viewModels = rooms.Select(room => new GetAllRoomsViewModel
            {
                Name = room.Name,
                Type = room.Type,
                PricePerNight = room.PricePerNight,
                Description = room.Description,
                PictureUrls = room.PictureUrls.Select(url => new RoomPicturesViewModel { Url = url.Url }).ToList(),
                RoomFacilities = room.RoomFasilities.Select(fac => new RoomFacilityViewModel { Name = fac.Name }).ToList()
            }).ToList();
            return new SuccessResponseViewModel<List<GetAllRoomsViewModel>>(viewModels);
        }
        [HttpGet]
        public async Task<ResponseViewModel<IEnumerable<AvailableRoomsVM>>> GetAllAvailableRooms(DateTime checkIn, DateTime checkOut)
        {
            var availableRooms = await _roomService.GetAllAvailableRooms(checkIn, checkOut);
            var roomsVm = _mapper.Map<IEnumerable<AvailableRoomsVM>>(availableRooms);

            return new SuccessResponseViewModel<IEnumerable<AvailableRoomsVM>>(roomsVm);
        }

    }
}
