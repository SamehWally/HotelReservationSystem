using Domain.Enums;

namespace Presentation.ViewModels.Reservation
{
    public class UpdateReservationDateVM
    {
        public int Id { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public ReservationStatus? Status { get; set; }
    }
}
