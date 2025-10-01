using Application.DTOs.StaffDtos;
using Application.Services.StaffServices;
using AutoMapper;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;
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

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<ResponseViewModel<StaffVM>> Add([FromQuery] AddStaffVM vm)
        {
            if (!ModelState.IsValid)
                return new ErrorResponseViewModel<StaffVM>(
                    ErrorCode.InvalidInput, "Invalid input data.");

            try
            {
                var dto = _mapper.Map<AddStaffDto>(vm);
                var created = await _staffService.AddAsync(dto);
                var result = _mapper.Map<StaffVM>(created);
                return new SuccessResponseViewModel<StaffVM>(result);
            }
            catch (InvalidOperationException)
            {
                return new ErrorResponseViewModel<StaffVM>(
                    ErrorCode.Conflict, "Username or email already exists.");
            }
        }
    }
}
