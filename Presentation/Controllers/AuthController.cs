using Application.DTOs.Login;
using Application.Services;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Presentation.ViewModels.Response;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ResponseViewModel<LoginResponseDto>> Login([FromBody] LoginRequestDto dto)
        {
            var result = await _authService.LoginAsync(dto);

            if (result == null)
            {
                return new ErrorResponseViewModel<LoginResponseDto>(
                   ErrorCode.InvalidCredentials,
                    "Invalid username or password."
                );
            }

            return new SuccessResponseViewModel<LoginResponseDto>(
                result,
                "Login successful."
            );
        }
    }

}
