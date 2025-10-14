using Application.DTOs.Feature;
using Application.Services;
using AutoMapper;
using Domain.Enums;
using Domain.Models.AccessControl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Feature;
using Presentation.ViewModels.Response;
using static Presentation.ViewModels.Feature.AddFeatureVM;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class FeatureController : ControllerBase
    {
        private readonly FeatureService _featureService;
        private readonly IMapper _mapper;
        public FeatureController(FeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<ResponseViewModel<Feature>> AddFeature([FromBody] AddFeatureVM model)
        {
            var featureDto = _mapper.Map<AddFeatureDto>(model);
            var result = await _featureService.AddFeatureAsync(featureDto);

            return result.IsSuccess
                ? new SuccessResponseViewModel<Feature>(result.Data!, result.Message)
                : new ErrorResponseViewModel<Feature>(ErrorCode.OperationFailed, result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<ResponseViewModel<bool>> DeleteFeature(int id)
        {
            var result = await _featureService.DeleteFeatureAsync(id);
            return result.IsSuccess
                ? new SuccessResponseViewModel<bool>(true, result.Message)
                : new ErrorResponseViewModel<bool>(ErrorCode.OperationFailed, result.Message);
        }

        [HttpGet("{id}")]
        public async Task<ResponseViewModel<Feature?>> GetFeatureById(int id)
        {
            var result = await _featureService.GetFeatureByIdAsync(id);
            return result.IsSuccess
                ? new SuccessResponseViewModel<Feature?>(result.Data!, result.Message)
                : new ErrorResponseViewModel<Feature?>(ErrorCode.NotFound, result.Message);
        }

        [HttpGet("{name}")]
        public async Task<ResponseViewModel<Feature?>> GetFeatureByName(string name)
        {
            var result = await _featureService.GetFeatureByNameAsync(name);
            return result.IsSuccess
                ? new SuccessResponseViewModel<Feature?>(result.Data!, result.Message)
                : new ErrorResponseViewModel<Feature?>(ErrorCode.NotFound, result.Message);
        }
    }

}
