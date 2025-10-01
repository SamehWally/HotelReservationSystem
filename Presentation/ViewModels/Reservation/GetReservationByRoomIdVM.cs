using Domain.Enums;

namespace Presentation.ViewModels.Reservation
{
    public class GetReservationByRoomIdVM
    {
        public int Id { get; set; } // RoomId
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public ReservationStatus? Status { get; set; }
    }
}
