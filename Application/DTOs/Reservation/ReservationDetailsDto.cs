namespace Application.DTOs.Reservation
{
    internal class ReservationDetailsDto : ReservationDto
    {
        public string? RoomName { get; set; }
        public string? CustomerName { get; set; }
    }
}
