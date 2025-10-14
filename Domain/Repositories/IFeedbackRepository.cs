using Domain.Models.FeedbackModel;

namespace Domain.Repositories
{
    public interface IFeedbackRepository
    {
        Task AddFeedbackAsync(Feedback feedback);
        Task<IEnumerable<Feedback>> GetFeedbacksAsync();
        Task<bool> ReplyToFeedbackAsync(int feedbackId, string reply);
        Task<bool> HasExistingFeedbackAsync(int reservationId, int customerId);
    }
}
