using Application.DTOs.StaffDtos;
using Application.Services;
using AutoMapper;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Response;
using Presentation.ViewModels.Staff;

namespace Presentation.Controllers
{
    public class StaffController : BaseAPIsController
    {
        private readonly StaffService _staffService;
        private readonly IMapper _mapper;
        public StaffController(StaffService staffService, IMapper mapper)
        {
            _staffService = staffService;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ResponseViewModel<StaffVM>> RegisterStaff([FromQuery] AddStaffVM staffVM)
        {
            var dto = _mapper.Map<CreateStaffDto>(staffVM);
            try
            {
                var result = await _staffService.RegisterStaffAsync(dto);
                var staffResponse = _mapper.Map<StaffVM>(result);
                return new SuccessResponseViewModel<StaffVM>(staffResponse);
            }
            catch (Exception ex)
            {
                return new ErrorResponseViewModel<StaffVM>(ErrorCode.InternalError, ex.Message);
            }
        }
        [HttpGet("all")]
        public async Task<ResponseViewModel<IEnumerable<StaffVM>>> GetAll()
        {
            var dtos = await _staffService.GetAllStaffsAsync();
            var vms = _mapper.Map<IEnumerable<StaffVM>>(dtos);

            return new SuccessResponseViewModel<IEnumerable<StaffVM>>(vms);
        }
        [HttpGet("{id:int}")]
        public async Task<ResponseViewModel<StaffVM>> GetById(int id)
        {
            try
            {
                var dto = await _staffService.GetStaffByIdAsync(id);
                if (dto == null)
                    return new ErrorResponseViewModel<StaffVM>(ErrorCode.NotFound, "Staff not found");
                var vm = _mapper.Map<StaffVM>(dto);
                return new SuccessResponseViewModel<StaffVM>(vm);
            }
            catch (Exception ex)
            {
                return new ErrorResponseViewModel<StaffVM>(ErrorCode.InternalError, ex.Message);
            }
        }
        [HttpGet("by-email")]
        public async Task<ResponseViewModel<StaffVM>> GetByEmail(string email)
        {
            try
            {
                var dto = await _staffService.GetStaffByEmailAsync(email);
                if (dto == null)
                    return new ErrorResponseViewModel<StaffVM>(ErrorCode.NotFound, "Staff not found");
                var vm = _mapper.Map<StaffVM>(dto);
                return new SuccessResponseViewModel<StaffVM>(vm);
            }
            catch (Exception ex)
            {
                return new ErrorResponseViewModel<StaffVM>(ErrorCode.InternalError, ex.Message);
            }
        }
        [HttpGet("by-department")]
        public async Task<ResponseViewModel<IEnumerable<StaffVM>>> GetByDepartment(string department)
        {
            try
            {
                var dtos = await _staffService.GetStaffByDepartmentAsync(department);
                var vms = _mapper.Map<IEnumerable<StaffVM>>(dtos);
                return new SuccessResponseViewModel<IEnumerable<StaffVM>>(vms);
            }
            catch (Exception ex)
            {
                return new ErrorResponseViewModel<IEnumerable<StaffVM>>(ErrorCode.InternalError, ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ResponseViewModel<bool>> DeleteSoft(int id)
        {
            try
            {
                var deleted = await _staffService.SoftDelete(id);
                if (!deleted)
                    return new ErrorResponseViewModel<bool>(ErrorCode.NotFound, "Staff not found or could not be deleted");
                return new SuccessResponseViewModel<bool>(true);
            }
            catch (Exception ex)
            {
                return new ErrorResponseViewModel<bool>(ErrorCode.InternalError, ex.Message);
            }
        }
        [HttpPut]
        public async Task<ResponseViewModel<bool>> Update([FromQuery] StaffUpdateVM vm)
        {
            if (vm is null) return new ErrorResponseViewModel<bool>(ErrorCode.InvalidInput, "Invalid staff data.");

            var dto = _mapper.Map<StaffUpdateDto>(vm);
            try
            {
                var result = await _staffService.UpdateAsync(dto);
                if (!result)
                    return new ErrorResponseViewModel<bool>(ErrorCode.NotFound, "Staff not found or could not be updated");
                return new SuccessResponseViewModel<bool>(true, "Staff Updated successfully.");
            }
            catch (Exception ex)
            {
                return new ErrorResponseViewModel<bool>(ErrorCode.InternalError, ex.Message);
            }
        }
    }
}
