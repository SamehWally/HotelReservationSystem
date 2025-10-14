using Application.DTOs.FeedbackDto;
using AutoMapper;
using Domain.Models.FeedbackModel;
using Domain.Repositories;

namespace Application.Services
{
    public class FeedbackService
    {
        private readonly ReservationService _reservationService;
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IMapper _mapper;

        public FeedbackService(ReservationService reservationService,
            IFeedbackRepository feedbackRepository,
            IMapper mapper)
        {
            _reservationService = reservationService;
            _feedbackRepository = feedbackRepository;
            _mapper = mapper;
        }

        #region AddFeedbackAsync
        public async Task<bool> AddFeedbackAsync(AddFeedbackDto feedbackDto)
        {
            var reservation = await _reservationService.GetByIdAsync(feedbackDto.ReservationId);
            if (reservation == null || reservation.CustomerId != feedbackDto.CustomerId)
                return false;

            var hasFeedback = await _feedbackRepository.HasExistingFeedbackAsync(feedbackDto.ReservationId, feedbackDto.CustomerId);
            if (hasFeedback)
                return false;

            var feedback = _mapper.Map<Feedback>(feedbackDto);
            feedback.CreatedDate = DateTime.Now;

            await _feedbackRepository.AddFeedbackAsync(feedback);
            return true;
        }
        #endregion

        #region GetAllFeedbacksAsync
        public async Task<IEnumerable<GetAllFeedbacksDto>> GetAllFeedbacksAsync()
        {
            var feedbacks = await _feedbackRepository.GetFeedbacksAsync();
            var feedbacksMapped = _mapper.Map<IEnumerable<GetAllFeedbacksDto>>(feedbacks);
            return feedbacksMapped;
        }
        #endregion

        #region ReplyToFeedbackAsync
        public async Task<bool> ReplyToFeedbackAsync(ReplyToFeedbackDto dto)
        {
            var result = await _feedbackRepository.ReplyToFeedbackAsync(dto.FeedbackId, dto.Reply);
            return result;
        }
        #endregion
    }

}
