using Domain.Enums;

namespace Presentation.ViewModels.Mapping.Resrvation;

public class SearchReservationViewModel
{
    public int? RoomId { get; set; }
    public int? CustomerId { get; set; }
    public DateOnly? From { get; set; }
    public DateOnly? To { get; set; }
    public ReservationStatus? Status { get; set; }
}
