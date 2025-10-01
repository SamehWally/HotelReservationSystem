using Application.DTOs.Login;
using Application.Services.StaffServices;
using AutoMapper;
using Domain.Enums;
using Domain.Models.Auth.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels;
using Presentation.ViewModels.JWT;
using Presentation.ViewModels.Login;
using Presentation.ViewModels.Response;

namespace Presentation.Controllers
{
    public class StaffAuthController : BaseAPIsController
    {
        private readonly IStaffAuthService _authService;
        private readonly IMapper _mapper;
        public StaffAuthController(IStaffAuthService authService,IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        [HttpPost("login")]
        public async Task<ResponseViewModel<TokenResponseVM>> Login([FromQuery] LoginRequestVM request)
        {
            if (!ModelState.IsValid)
                return new ErrorResponseViewModel<TokenResponseVM>(
                    ErrorCode.InvalidInput, "Invalid input data.");

            var loginDto = _mapper.Map<LoginRequestDto>(request);

            var tokenDto = await _authService.LoginAsync(loginDto);
            if (tokenDto is null)
                return new ErrorResponseViewModel<TokenResponseVM>(
                    ErrorCode.Unauthorized, "Invalid username or password.");

            var tokenVm = _mapper.Map<TokenResponseVM>(tokenDto);
            return new SuccessResponseViewModel<TokenResponseVM>(tokenVm);
        }
    }
}
