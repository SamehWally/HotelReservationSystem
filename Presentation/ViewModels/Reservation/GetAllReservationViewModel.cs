using Domain.Enums;

namespace Presentation.ViewModels.Reservation
{
    public class GetAllReservationViewModel
    {
        public int Id { get; set; }

        public int Number { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public ReservationStatus Status { get; set; }

        public int RoomId { get; set; }
        public string RoomName { get; set; } = string.Empty;
        public int RoomNumber { get; set; } 

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
