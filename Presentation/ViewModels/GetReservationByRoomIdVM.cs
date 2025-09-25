using Domain.Enums;

namespace Presentation.ViewModels
{
    public class GetReservationByRoomIdVM
    {
        public int Id { get; set; } // RoomId
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public ReservationStatus? Status { get; set; }
    }
}
