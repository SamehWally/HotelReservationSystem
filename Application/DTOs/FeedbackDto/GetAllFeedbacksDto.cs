namespace Application.DTOs.FeedbackDto
{
    public class GetAllFeedbacksDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public int ReservationId { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; } = string.Empty;

        public bool IsReplied { get; set; } = false;
        public string? Reply { get; set; }

        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
