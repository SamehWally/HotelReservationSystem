using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Response;
using Domain.Enums;
using Domain.Models.AccessControl;
using Domain.Repositories;

namespace Application.Services
{
    public class UserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;

        public UserRoleService(IUserRoleRepository userRoleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task<ResponseDTO<bool>> AssignRoleToUserAsync(int userId, int roleId)
        {
            var result = await _userRoleRepository.AssignRoleToUserAsync(userId, roleId);
            return result
                ? ResponseDTO<bool>.Success(true, "Role assigned successfully.")
                : ResponseDTO<bool>.Failure(ErrorCode.FaildRoleAssignment,"Failed to assign role.");
        }

        public async Task<ResponseDTO<bool>> SoftRemoveRoleFromUserAsync(int userId, int roleId)
        {
            var result = await _userRoleRepository.SoftRemoveRoleFromUserAsync(userId, roleId);
            return result
                ? ResponseDTO<bool>.Success(true, "Role removed (soft delete) successfully.")
                : ResponseDTO<bool>.Failure(ErrorCode.FaildResponseDto,"Failed to soft remove role.");
        }

        public async Task<ResponseDTO<bool>> HardRemoveRoleFromUserAsync(int userId, int roleId)
        {
            var result = await _userRoleRepository.HardRemoveRoleFromUserAsync(userId, roleId);
            return result
                ? ResponseDTO<bool>.Success(true, "Role removed permanently.")
                : ResponseDTO<bool>.Failure(ErrorCode.FaildResponseDto,"Failed to hard remove role.");
        }

        public async Task<ResponseDTO<IList<Role>>> GetUserRolesAsync(int userId)
        {
            var roles = await _userRoleRepository.GetUserRolesAsync(userId);
            return roles != null && roles.Count > 0
                ? ResponseDTO<IList<Role>>.Success(roles, "Roles retrieved successfully.")
                : ResponseDTO<IList<Role>>.Failure(ErrorCode.FaildResponseDto,"No roles found for this user.");
        }
    }

}
