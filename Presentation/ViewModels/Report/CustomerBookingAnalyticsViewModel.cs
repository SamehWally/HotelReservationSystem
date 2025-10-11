namespace Presentation.ViewModels.Report
{

    public class CustomerBookingAnalyticsViewModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = default!;
        public int TotalReservations { get; set; }
        public int LastReservationMonth { get; set; }
    }
}