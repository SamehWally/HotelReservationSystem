using Application.DTOs.Room;
using Application.Services;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;
using Presentation.ViewModels.Room;
using Presentation.ViewModels.Room.Presentation.ViewModels.Room;

namespace Presentation.Controllers
{
    public class RoomController : BaseAPIsController
    {
        private readonly RoomService _roomService;
        private readonly IWebHostEnvironment _env;

        public RoomController(RoomService roomService, IWebHostEnvironment env)
        {
            _roomService = roomService;
            _env = env;
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

        //[HttpGet("{id}")]
        //public ResponseViewModel<GetRoomViewModel> GetRoomById(int id)
        //{
        //    var room = _roomService.GetRoomById(id);
        //    if (room == null)
        //    {
        //        return new ErrorResponseViewModel<GetRoomViewModel>
        //                    (ErrorCode.RoomNotFound, $"Not found room with id {id}");
        //    }

        //    var viewModel = new GetRoomViewModel
        //    {
        //        Id = room!.Id,
        //        Name = room.Name
        //    };

        //    return new SuccessResponseViewModel<GetRoomViewModel>(viewModel);
        //}

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
        //[HttpPut("{id}")]
        //[Consumes("multipart/form-data")]
        //public async Task<ActionResult<GetRoomDto>> UpdateRoom(int id, [FromForm] EditRoomViewModel vm)
        //{
        //    if (id != vm.Id)
        //        return BadRequest("Id mismatch");

        //    // ✅ Save new pictures if uploaded
        //    var pictureUrls = new List<string>();
        //    if (vm.NewPictures != null && vm.NewPictures.Any())
        //    {
        //        pictureUrls = await SavePictures(vm.NewPictures);
        //    }

        //    // ✅ Keep old pictures if needed
        //    if (vm.ExistingPictureUrlsToKeep != null)
        //    {
        //        pictureUrls.AddRange(vm.ExistingPictureUrlsToKeep);
        //    }

        //    var dto = new EditRoomDto
        //    {
        //        Id = vm.Id,
        //        Name = vm.Name,
        //        Type = vm.Type,
        //        PricePerNight = vm.PricePerNight,
        //        Description = vm.Description,
        //        FacilityIds = vm.FacilityIds,
        //        PictureUrls = pictureUrls
        //    };

        //    try
        //    {
        //        var updatedRoom = _roomService.UpdateRoom(dto);
        //        return Ok(updatedRoom);
        //    }
        //    catch (ArgumentException ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //}



        [HttpDelete("id")]
        public bool Delete(int id) {

            var success = _roomService.SoftDeleteRoom(id);
            if (!success) {
                return false;
            
            }
            
            return true;
        
        
        }

    }
}
