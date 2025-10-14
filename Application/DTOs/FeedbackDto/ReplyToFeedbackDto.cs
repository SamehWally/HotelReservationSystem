namespace Application.DTOs.FeedbackDto
{
    public class ReplyToFeedbackDto
    {
        public int FeedbackId { get; set; }
        public string Reply { get; set; } = string.Empty;
    }
}
