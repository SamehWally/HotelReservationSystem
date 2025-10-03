using Domain.Enums;

namespace Application.Filters
{
    public class ReservationFilter
    {
        public string? CustomerName { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public ReservationStatus? Status { get; set; }
        public int? RoomNumber { get; set; }
    }
}
