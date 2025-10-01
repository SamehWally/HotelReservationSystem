using Application.DTOs.Login;
using Domain.Models.Auth.Interfaces;
using Domain.Models.Auth.Models;
using Domain.Repositories.StaffRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.StaffServices
{
    public sealed class StaffAuthService : IStaffAuthService
    {
        private readonly IStaffRepository _staffRepository;
        private readonly ICredentialsAuthenticator _authenticator;
        private readonly ITokenService _tokenService;

        public StaffAuthService(
         IStaffRepository staffRepository,
         ICredentialsAuthenticator authenticator,
         ITokenService tokenService)
        {
            _staffRepository = staffRepository;
            _authenticator = authenticator;
            _tokenService = tokenService;
        }

        public async Task<TokenResponseDto?> LoginAsync(LoginRequestDto dto)
        {
            var q = _staffRepository.Query();

            var claims = await _authenticator.AuthenticateStaffAsync(q, dto.UsernameOrEmail, dto.Password);
            if (claims is null) return null;

            var token = _tokenService.GenerateToken(claims);
            return token;
        }
    }
}
