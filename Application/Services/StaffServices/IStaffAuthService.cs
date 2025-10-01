using Application.DTOs.Login;
using Domain.Models.Auth.Models;
using Microsoft.AspNetCore.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Auth.Interfaces
{
    public interface IStaffAuthService
    {
        Task<TokenResponseDto?> LoginAsync(LoginRequestDto dto);
    }
}
