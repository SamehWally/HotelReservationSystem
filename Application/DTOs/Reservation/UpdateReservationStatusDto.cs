using Domain.Enums;

namespace Application.DTOs.Reservation
{
    public class UpdateReservationStatusDto
    {
        public int Id { get; set; }
        public ReservationStatus  Status { get; set; } 
    }
}
