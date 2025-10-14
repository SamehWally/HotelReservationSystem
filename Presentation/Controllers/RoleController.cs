using Application.DTOs.Role;
using Application.Services;
using AutoMapper;
using Domain.Enums;
using Domain.Models.AccessControl;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Response;
using Presentation.ViewModels.Role;
using Presentation.ViewModels.Room;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;
        private readonly IMapper _mapper;
        public RoleController(RoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ResponseViewModel<Role>> AddRole([FromBody] AddRoleVM model)
        {
            var roleDto = _mapper.Map<AddRoleDto>(model);

            var result = await _roleService.AddRoleAsync(roleDto);

            return result.IsSuccess
                ? new SuccessResponseViewModel<Role>(result.Data!, result.Message)
                : new ErrorResponseViewModel<Role>(ErrorCode.OperationFailed, result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<ResponseViewModel<bool>> DeleteRole(int id)
        {
            var result = await _roleService.DeleteRoleAsync(id);
            return result.IsSuccess
                ? new SuccessResponseViewModel<bool>(true, result.Message)
                : new ErrorResponseViewModel<bool>(ErrorCode.OperationFailed, result.Message);
        }

        [HttpGet("{id}")]
        public async Task<ResponseViewModel<Role?>> GetRoleById(int id)
        {
            var result = await _roleService.GetRoleByIdAsync(id);
            return result.IsSuccess
                ? new SuccessResponseViewModel<Role?>(result.Data!, result.Message)
                : new ErrorResponseViewModel<Role?>(ErrorCode.NotFound, result.Message);
        }

        [HttpGet("{name}")]
        public async Task<ResponseViewModel<Role?>> GetRoleByName(string name)
        {
            var result = await _roleService.GetRoleByNameAsync(name);
            return result.IsSuccess
                ? new SuccessResponseViewModel<Role?>(result.Data!, result.Message)
                : new ErrorResponseViewModel<Role?>(ErrorCode.NotFound, result.Message);
        }
    }

}
