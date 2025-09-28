namespace Presentation.ViewModels.Mapping.Resrvation;

public class ReservationViewModel
{
    public int Id { get; set; }
    public int Number { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public string Status { get; set; } = string.Empty;
    public int RoomId { get; set; }
    public int CustomerId { get; set; }
}
