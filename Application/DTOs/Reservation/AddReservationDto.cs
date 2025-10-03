using Domain.Enums;

namespace Application.DTOs.Reservation
{
    public class AddReservationDto
    {
        public int Number { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public ReservationStatus Status { get; set; }

        public int RoomId { get; set; }
        public int CustomerId { get; set; }
      
    }
}
