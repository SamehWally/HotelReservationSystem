using Domain.Enums;

namespace Application.DTOs.Reservation
{
    public class GetReservationByRoomIdDto
    {
        public int Id { get; set; } // <-- RoomId
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public ReservationStatus? Status { get; set; }
    }
}
