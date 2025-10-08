using Application.Services;
using Domain.Enums;
using Domain.Models.AccessControl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Response;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeatureController : ControllerBase
    {
        private readonly FeatureService _featureService;

        public FeatureController(FeatureService featureService)
        {
            _featureService = featureService;
        }

        [HttpPost("add")]
        [Authorize]

        public async Task<ResponseViewModel<Feature>> AddFeature([FromBody] Feature feature)
        {
            var result = await _featureService.AddFeatureAsync(feature);
            return result.IsSuccess
                ? new SuccessResponseViewModel<Feature>(result.Data!, result.Message)
                : new ErrorResponseViewModel<Feature>(ErrorCode.OperationFailed, result.Message);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ResponseViewModel<bool>> DeleteFeature(int id)
        {
            var result = await _featureService.DeleteFeatureAsync(id);
            return result.IsSuccess
                ? new SuccessResponseViewModel<bool>(true, result.Message)
                : new ErrorResponseViewModel<bool>(ErrorCode.OperationFailed, result.Message);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<ResponseViewModel<Feature?>> GetFeatureById(int id)
        {
            var result = await _featureService.GetFeatureByIdAsync(id);
            return result.IsSuccess
                ? new SuccessResponseViewModel<Feature?>(result.Data!, result.Message)
                : new ErrorResponseViewModel<Feature?>(ErrorCode.NotFound, result.Message);
        }

        [HttpGet("get-by-name/{name}")]
        public async Task<ResponseViewModel<Feature?>> GetFeatureByName(string name)
        {
            var result = await _featureService.GetFeatureByNameAsync(name);
            return result.IsSuccess
                ? new SuccessResponseViewModel<Feature?>(result.Data!, result.Message)
                : new ErrorResponseViewModel<Feature?>(ErrorCode.NotFound, result.Message);
        }
    }

}
