using Application.DTOs.FeedbackDto;
using AutoMapper;
using Presentation.ViewModels.Feedback;

namespace Presentation.ViewModels.Mapping
{
    public class FeedbackProfileViewModel : Profile
    {
        public FeedbackProfileViewModel()
        {
            CreateMap<AddFeedbackViewModel, AddFeedbackDto>();

            CreateMap<GetAllFeedbacksDto, GetAllFeedbacksViewModel>();
        }
    }
}
