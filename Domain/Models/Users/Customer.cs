namespace Domain.Models.Users
{
    public class Customer : BaseModel
    {
        public int UserId { get; set; }
        public User User { get; set; } = default!;
        public DateTime? DateOfBirth { get; set; }
        public string? NationalId { get; set; }
        public ICollection<Reservation.Reservation> Reservations { get; set; } = new List<Reservation.Reservation>();
    }
}
