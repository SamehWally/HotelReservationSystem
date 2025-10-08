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
    public class RoleFeatureController : ControllerBase
    {
        private readonly RoleFeatureService _roleFeatureService;

        public RoleFeatureController(RoleFeatureService roleFeatureService)
        {
            _roleFeatureService = roleFeatureService;
        }

        [HttpPost("assign")]
        [Authorize]
        [TypeFilter<Filters.CustomAuthorizeFilter>(Arguments = new object[] { "CanAssignFeatureToRole" })] // to use custom authorization filter]

        public async Task<ResponseViewModel<bool>> AssignFeatureToRole(int roleId, int featureId)
        {
            var result = await _roleFeatureService.AssignFeatureToRoleAsync(roleId, featureId);
            return result.IsSuccess
                ? new SuccessResponseViewModel<bool>(true, result.Message)
                : new ErrorResponseViewModel<bool>(ErrorCode.OperationFailed, result.Message);
        }

        [HttpDelete("remove")]
        public async Task<ResponseViewModel<bool>> RemoveFeatureFromRole(int roleId, int featureId)
        {
            var result = await _roleFeatureService.RemoveFeatureFromRoleAsync(roleId, featureId);
            return result.IsSuccess
                ? new SuccessResponseViewModel<bool>(true, result.Message)
                : new ErrorResponseViewModel<bool>(ErrorCode.OperationFailed, result.Message);
        }

        [HttpGet("get-features/{roleId}")]
        public async Task<ResponseViewModel<IEnumerable<Feature>>> GetFeaturesByRole(int roleId)
        {
            var result = await _roleFeatureService.GetFeaturesByRoleAsync(roleId);
            return result.IsSuccess
                ? new SuccessResponseViewModel<IEnumerable<Feature>>(result.Data!, result.Message)
                : new ErrorResponseViewModel<IEnumerable<Feature>>(ErrorCode.NotFound, result.Message);
        }
    }

}
