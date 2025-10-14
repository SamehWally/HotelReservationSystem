using Application.DTOs.StaffDtos;
using Application.Helpers;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Models.Users;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;


namespace Application.Services
{
    public class StaffService
    {
        private readonly IStaffRepository _repo;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public StaffService(IStaffRepository repo, IMapper mapper, IUserRepository userRepository)
        {
            _repo = repo;
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<StaffDto> RegisterStaffAsync(CreateStaffDto dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));
            if (string.IsNullOrWhiteSpace(dto.FirstName)) throw new ArgumentException("FirstName is required.", nameof(dto.FirstName));
            if (string.IsNullOrWhiteSpace(dto.LastName)) throw new ArgumentException("LastName is required.", nameof(dto.LastName));
            if (string.IsNullOrWhiteSpace(dto.Email)) throw new ArgumentException("Email is required.", nameof(dto.Email));
            if (string.IsNullOrWhiteSpace(dto.Password)) throw new ArgumentException("Password is required.", nameof(dto.Password));

            var existing = await _repo.GetByEmailAsync(dto.Email);
            if (existing != null)
                throw new InvalidOperationException("This email already exists.");

            var user = new User
            {
                Email = dto.Email,
                PasswordHash = HashHelper.ComputeHash(dto.Password),
                Username = HashHelper.ComputeHash(dto.UserName),
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                City = dto.City,
                Country = dto.Country,
                PhoneNumber = dto.Phone,
                Address = dto.Address
            };

            var staff = new Staff
            {
                User = user,
                HireDate = dto.HireDate,
                Department = dto.Department,
            };

            var saved = await _repo.AddAsync(staff);
            if (!saved)
                throw new InvalidOperationException("Failed to create staff.");

            staff.User = user;

            return _mapper.Map<StaffDto>(staff);
        }
        public async Task<IEnumerable<StaffDto>> GetAllStaffsAsync()
        {
            var staffs = await _repo.GetAll()
                .ProjectTo<StaffDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return staffs;
        }
        public async Task<StaffDto> GetStaffByIdAsync(int id)
        {
            var staff = await _repo.GetByIdAsync(id);
            if (staff == null)
                throw new KeyNotFoundException("Staff not found.");
            return _mapper.Map<StaffDto>(staff);
        }
        public async Task<StaffDto> GetStaffByEmailAsync(string email)
        {
            var staff = await _repo.GetByEmailAsync(email);
            if (staff == null)
                throw new KeyNotFoundException("Staff not found.");
            return _mapper.Map<StaffDto>(staff);
        }
        public async Task<IEnumerable<StaffDto>> GetStaffByDepartmentAsync(string department)
        {
            var staff = await _repo.GetByDepartment(department)
                .ProjectTo<StaffDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            if (staff == null)
                throw new KeyNotFoundException("Staff not found.");

            return staff;
        }
        public async Task<bool> SoftDelete(int id)
        {
            var exists = await _repo.ExistsAsync(id);
            if (!exists)
                throw new KeyNotFoundException("Staff not found.");
            var deleted = await _repo.SoftDeleteAsync(id);
            if (!deleted)
                throw new InvalidOperationException("Failed to delete staff.");
            return true;
        }
        public async Task<bool> UpdateAsync( StaffUpdateDto dto)
        {
            if(dto is null) throw new ArgumentNullException(nameof(dto));

            var staff = await _repo.GetByIdAsync(dto.Id);
            if(staff is null)
                throw new KeyNotFoundException("Staff not found.");
            var user = await _userRepository.GetByIdAsync(staff.UserId);

            if (!string.IsNullOrWhiteSpace(dto.FirstName)) user.FirstName = dto.FirstName;
            if (!string.IsNullOrWhiteSpace(dto.LastName)) user.LastName = dto.LastName;
            if (!string.IsNullOrWhiteSpace(dto.Email)) user.Email = dto.Email;
            if (!string.IsNullOrWhiteSpace(dto.UserName)) user.Username = dto.UserName;
            if (!string.IsNullOrWhiteSpace(dto.Phone)) user.PhoneNumber = dto.Phone;
            if (!string.IsNullOrWhiteSpace(dto.Address)) user.Address = dto.Address;
            if (!string.IsNullOrWhiteSpace(dto.City)) user.City = dto.City;
            if (!string.IsNullOrWhiteSpace(dto.Country)) user.Country = dto.Country;
            if (!string.IsNullOrWhiteSpace(dto.Department)) staff.Department = dto.Department;

            return await _repo.Update(staff);
        }
    }
}
