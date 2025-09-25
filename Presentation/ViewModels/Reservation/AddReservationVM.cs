using Domain.Enums;

namespace Presentation.ViewModels.Reservation
{
    public class AddReservationVM
    {
        public int Number { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public ReservationStatus Status { get; set; }

        public int RoomId { get; set; }
        public int CustomerId { get; set; }
    }
}
