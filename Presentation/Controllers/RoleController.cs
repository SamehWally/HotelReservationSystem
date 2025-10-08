using Application.Services;
using Domain.Enums;
using Domain.Models.AccessControl;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Response;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;

        public RoleController(RoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpPost("add")]
        public async Task<ResponseViewModel<Role>> AddRole([FromBody] Role role)
        {
            var result = await _roleService.AddRoleAsync(role);
            return result.IsSuccess
                ? new SuccessResponseViewModel<Role>(result.Data!, result.Message)
                : new ErrorResponseViewModel<Role>(ErrorCode.OperationFailed, result.Message);
        }

        [HttpDelete("delete/{id}")]
        public async Task<ResponseViewModel<bool>> DeleteRole(int id)
        {
            var result = await _roleService.DeleteRoleAsync(id);
            return result.IsSuccess
                ? new SuccessResponseViewModel<bool>(true, result.Message)
                : new ErrorResponseViewModel<bool>(ErrorCode.OperationFailed, result.Message);
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<ResponseViewModel<Role?>> GetRoleById(int id)
        {
            var result = await _roleService.GetRoleByIdAsync(id);
            return result.IsSuccess
                ? new SuccessResponseViewModel<Role?>(result.Data!, result.Message)
                : new ErrorResponseViewModel<Role?>(ErrorCode.NotFound, result.Message);
        }

        [HttpGet("get-by-name/{name}")]
        public async Task<ResponseViewModel<Role?>> GetRoleByName(string name)
        {
            var result = await _roleService.GetRoleByNameAsync(name);
            return result.IsSuccess
                ? new SuccessResponseViewModel<Role?>(result.Data!, result.Message)
                : new ErrorResponseViewModel<Role?>(ErrorCode.NotFound, result.Message);
        }
    }

}
