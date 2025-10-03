using Application.DTOs.Login;
using Application.DTOs.StaffDtos;
using Application.Services.StaffServices;
using AutoMapper;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.JWT;
using Presentation.ViewModels.Login;
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

        [HttpPost("login")]
        public async Task<ResponseViewModel<TokenResponseVM>> Login([FromQuery] LoginRequestVM request)
        {
            if (!ModelState.IsValid)
                return new ErrorResponseViewModel<TokenResponseVM>(
                    ErrorCode.InvalidInput, "Invalid input data.");

            var loginDto = _mapper.Map<LoginRequestDto>(request);

            var tokenDto = await _staffService.LoginAsync(loginDto);
            if (tokenDto is null)
                return new ErrorResponseViewModel<TokenResponseVM>(
                    ErrorCode.Unauthorized, "Invalid username or password.");

            var tokenVm = _mapper.Map<TokenResponseVM>(tokenDto);
            return new SuccessResponseViewModel<TokenResponseVM>(tokenVm);
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
