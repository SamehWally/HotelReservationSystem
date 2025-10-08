using Domain.Enums.RoomType;

namespace Domain.Models.Room
{
    public class Room : BaseModel
    {
        public string Name { get; set; } = string.Empty;
        public int Number { get; set; }
        public RoomType Type { get; set; } 
        public decimal PricePerNight { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }

        public List<RoomPicture> Pictures { get; set; } = new();
        public List<RoomFacility> RoomFacilities { get; set; } = new();
        public List<Reservation.Reservation> Reservations { get; set; } = new();
    }
}
