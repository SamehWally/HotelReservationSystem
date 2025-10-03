using Application.DTOs.StaffDtos;
using AutoMapper;
using Domain.Models.Auth.Interfaces;
using Domain.Models.Users;
using Domain.Repositories.Staff;
using Domain.Repositories.StaffRepo;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.StaffServices
{
    public class StaffService
    {
        private readonly IStaffRepository _repo;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher _hasher;
        private readonly IRoleRepository _roleRepo;

        public StaffService(IStaffRepository repo, IMapper mapper, IPasswordHasher hasher, IRoleRepository roleRepo)
        {
            _repo = repo;
            _mapper = mapper;
            _hasher = hasher;
            _roleRepo = roleRepo;
        }

        public async Task<StaffDto> AddAsync(AddStaffDto dto)
        {
            var username = dto.Username?.Trim();
            var email = dto.Email?.Trim();

            var exists = await _repo.Query()
            .AnyAsync(s => s.Username == username || s.Email == email);
            if (exists)
                throw new InvalidOperationException("Username or email already exists.");

            var roleExists = await _roleRepo.Query().AnyAsync(r => r.Id == dto.RoleId);
            if (!roleExists)
                throw new InvalidOperationException("Role not found.");

            var staff = _mapper.Map<Staff>(dto);
            staff.PasswordHash = _hasher.Hash(dto.Password);
            staff.RoleId = dto.RoleId;

            await _repo.AddAsync(staff);

            return _mapper.Map<StaffDto>(staff);
        }
    }
}
