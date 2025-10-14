using Domain.Models.FeedbackModel;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly Context _context;

        public FeedbackRepository(Context context)
        {
            _context = context;
        }

        public async Task AddFeedbackAsync(Feedback feedback)
        {
            await _context.Feedbacks.AddAsync(feedback);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Feedback>> GetFeedbacksAsync()
        {
            return await _context.Feedbacks
                .Include(f => f.Customer)
                .Include(f => f.Reservation)
                .OrderByDescending(f => f.CreatedDate)
                .ToListAsync();
        }

        public async Task<bool> ReplyToFeedbackAsync(int feedbackId, string reply)
        {
            var feedback = await _context.Feedbacks.FindAsync(feedbackId);
            if (feedback == null || feedback.IsDeleted || feedback.IsReplied)
                return false;

            feedback.Reply = reply;
            feedback.IsReplied = true;
            feedback.UpdatedDate = DateTime.Now;

            _context.Feedbacks.Update(feedback);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> HasExistingFeedbackAsync(int reservationId, int customerId)
        {
            return await _context.Feedbacks
                .AnyAsync(f => f.ReservationId == reservationId && f.CustomerId == customerId);
        }

    }
}
