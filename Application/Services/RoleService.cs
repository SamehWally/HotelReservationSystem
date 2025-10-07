using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Response;
using Domain.Models.AccessControl;
using Domain.Repositories;
using Domain.Enums;


namespace Application.Services
{
    public class RoleService 
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<ResponseDTO<Role>> AddRoleAsync(Role role)
        {
            await _roleRepository.AddAsync(role);
            return ResponseDTO<Role>.Success(role, "Role added successfully.");
        }

        public async Task<ResponseDTO<bool>> DeleteRoleAsync(int id)
        {
            var result = await _roleRepository.DeleteAsync(id);
            return result
                ? ResponseDTO<bool>.Success(true, "Role deleted successfully.")
                : ResponseDTO<bool>.Failure(ErrorCode.FaildResponseDto,"Role not found or failed to delete.");
        }

        public async Task<ResponseDTO<Role?>> GetRoleByIdAsync(int id)
        {
            var role = await _roleRepository.GetByIdAsync(id);
            return role != null
                ? ResponseDTO<Role?>.Success(role, "Role found.")
                : ResponseDTO<Role?>.Failure(ErrorCode.FaildResponseDto,"Role not found.");
        }

        public async Task<ResponseDTO<Role?>> GetRoleByNameAsync(string roleName)
        {
            var role = await _roleRepository.GetByNameAsync(roleName);
            return role != null
                ? ResponseDTO<Role?>.Success(role, "Role found.")
                : ResponseDTO<Role?>.Failure(ErrorCode.FaildResponseDto,"Role not found.");
        }
    }

}
