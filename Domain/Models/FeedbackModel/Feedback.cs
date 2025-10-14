using Domain.Models.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models.FeedbackModel
{
    public class Feedback : BaseModel
    {
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        [ForeignKey("Reservation")]
        public int ReservationId { get; set; }
        public Reservation.Reservation? Reservation { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [MaxLength(1000)]
        public string Comment { get; set; } = string.Empty;

        public bool IsReplied { get; set; } = false;
        public string? Reply { get; set; }
    }
}
