namespace Application.DTOs.Reservation
{
    public class ReservationResponse
    {
       // public int Number { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
       
        public string Message { get; set; }
        public int RoomId { get; set; }
        public int CustomerId { get; set; }
    }
}
