using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels.Feedback
{
    public class AddFeedbackViewModel
    {
        public int CustomerId { get; set; }
        public int ReservationId { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

        [MaxLength(1000)]
        public string Comment { get; set; } = string.Empty;
    }
}
