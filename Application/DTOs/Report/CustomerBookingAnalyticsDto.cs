

namespace Application.DTOs.Report
{
    public class CustomerBookingAnalyticsDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = default!;
        public int TotalReservations { get; set; }
        public int LastReservationMonth { get; set; }
    }
}
