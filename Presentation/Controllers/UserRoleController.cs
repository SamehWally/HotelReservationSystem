using Application.Services;
using Domain.Enums;
using Domain.Models.AccessControl;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Response;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserRoleController : ControllerBase
    {
        private readonly UserRoleService _userRoleService;

        public UserRoleController(UserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpPost("assign")]
        public async Task<ResponseViewModel<bool>> AssignRole(int userId, int roleId)
        {
            var result = await _userRoleService.AssignRoleToUserAsync(userId, roleId);
            return result.IsSuccess
                ? new SuccessResponseViewModel<bool>(true, result.Message)
                : new ErrorResponseViewModel<bool>(ErrorCode.OperationFailed, result.Message);
        }

        [HttpDelete("remove-soft")]
        public async Task<ResponseViewModel<bool>> SoftRemoveRole(int userId, int roleId)
        {
            var result = await _userRoleService.SoftRemoveRoleFromUserAsync(userId, roleId);
            return result.IsSuccess
                ? new SuccessResponseViewModel<bool>(true, result.Message)
                : new ErrorResponseViewModel<bool>(ErrorCode.OperationFailed, result.Message);
        }

        [HttpDelete("remove-hard")]
        public async Task<ResponseViewModel<bool>> HardRemoveRole(int userId, int roleId)
        {
            var result = await _userRoleService.HardRemoveRoleFromUserAsync(userId, roleId);
            return result.IsSuccess
                ? new SuccessResponseViewModel<bool>(true, result.Message)
                : new ErrorResponseViewModel<bool>(ErrorCode.OperationFailed, result.Message);
        }

        [HttpGet("user-roles/{userId}")]
        public async Task<ResponseViewModel<IList<Role>>> GetUserRoles(int userId)
        {
            var result = await _userRoleService.GetUserRolesAsync(userId);
            return result.IsSuccess
                ? new SuccessResponseViewModel<IList<Role>>(result.Data!, result.Message)
                : new ErrorResponseViewModel<IList<Role>>(ErrorCode.NotFound, result.Message);
        }
    }

}
