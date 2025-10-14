using Application.DTOs.Feature;
using AutoMapper;
using Presentation.ViewModels.Feature;

namespace Presentation.ViewModels.Mapping
{
    public class FeatureProfile : Profile
    {
        public FeatureProfile()
        {
            CreateMap<AddFeatureVM, AddFeatureDto>();

            CreateMap<AddFeatureDto, Domain.Models.AccessControl.Feature>();

        }
    }
}
