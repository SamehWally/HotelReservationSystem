using Domain.Enums;

namespace Application.DTOs.Reservation
{
    public class UpdateReservationDateDto
    {
        public int Id { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public ReservationStatus? Status { get; set; }
    }
}
