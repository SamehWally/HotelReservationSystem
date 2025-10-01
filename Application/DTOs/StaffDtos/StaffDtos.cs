using Domain.Models.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.StaffDtos
{
    public record AddStaffDto(string Username, string Email, string Password, int RoleId);
    public record StaffDto(int Id, string Username, string Email);
}
