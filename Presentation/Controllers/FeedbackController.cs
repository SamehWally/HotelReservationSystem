using Application.DTOs.FeedbackDto;
using Application.Services;
using AutoMapper;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Feedback;
using Presentation.ViewModels.Response;

namespace Presentation.Controllers
{
    public class FeedbackController : BaseAPIsController
    {
        private readonly FeedbackService _feedbackService;
        private readonly IMapper _mapper;

        public FeedbackController(FeedbackService feedbackService, IMapper mapper)
        {
            _feedbackService = feedbackService;
            _mapper = mapper;
        }

        #region SubmitFeedbackAsync
        [HttpPost("submit")]
        public async Task<IActionResult> SubmitFeedbackAsync([FromQuery] AddFeedbackViewModel addFeedbackViewModel)
        {
            var feedbackMapped = _mapper.Map<AddFeedbackDto>(addFeedbackViewModel);

            var result = await _feedbackService.AddFeedbackAsync(feedbackMapped);
            if (!result)
                return BadRequest(new ErrorResponseViewModel<bool>(ErrorCode.FeedbackFailed, "Unable to submit feedback."));

            return Ok(new SuccessResponseViewModel<bool>(true, "Feedback submitted successfully."));
        }
        #endregion

        #region GetAllFeedbacksAsync
        [HttpGet("all")]
        public async Task<ResponseViewModel<IEnumerable<GetAllFeedbacksViewModel>>> GetAllFeedbacksAsync()
        {
            var feedbacks = await _feedbackService.GetAllFeedbacksAsync();

            var feedbacksViewModels = _mapper.Map<IEnumerable<GetAllFeedbacksViewModel>>(feedbacks);

            return new SuccessResponseViewModel<IEnumerable<GetAllFeedbacksViewModel>>(feedbacksViewModels);
        }
        #endregion

        #region ReplyToFeedbackAsync
        [HttpPut("reply/{id}")]
        public async Task<IActionResult> ReplyToFeedbackAsync(int id, [FromQuery] ReplyToFeedbackDto dto)
        {
            if (id != dto.FeedbackId)
                return BadRequest(new ErrorResponseViewModel<bool>(ErrorCode.InvalidInput, "Feedback ID mismatch."));

            var result = await _feedbackService.ReplyToFeedbackAsync(dto);
            if (!result)
                return BadRequest(new ErrorResponseViewModel<bool>(ErrorCode.ReplyFailed, "Unable to reply to feedback."));

            return Ok(new SuccessResponseViewModel<bool>(true, "Reply submitted successfully."));
        }
        #endregion
    }
}
