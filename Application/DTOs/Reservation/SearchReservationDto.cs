using Domain.Enums;

namespace Application.DTOs.Reservation;
public class SearchReservationDto
{
    public int Number { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public ReservationStatus Status { get; set; }
    public int RoomId { get; set; }
    public int CustomerId { get; set; }

    public string? Description { get; set; }


    public DateOnly? From { get; set; }
    public DateOnly? To { get; set; }
}
