using Application.DTOs.Room;

namespace Presentation.ViewModels.Room
{
    public class GetAllRoomsViewModel
    {
        public string Name { get; set; }
        public int Type { get; set; } 
        public decimal PricePerNight { get; set; }
        public string Description { get; set; }
        public List<RoomPicturesViewModel> PictureUrls { get; set; }
        public List<RoomFacilityViewModel> RoomFacilities { get; set; }

    }
}
