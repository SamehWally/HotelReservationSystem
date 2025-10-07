using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.User;
using Domain.Repositories;

namespace Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserInfoDto> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);

            // I will use AutoMapper in the future
            var userDto = new UserInfoDto()
            {
                Id= user.Id,
                FullName = (string)user.FirstName.Concat(user.LastName),
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,

            };
            return userDto;
        }

        public async Task<UserInfoDto> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);
            // I will use AutoMapper in the future
            var userDto = new UserInfoDto()
            {
                Id = user.Id,
                FullName = (string)user.FirstName.Concat(user.LastName),
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
            return userDto;
        }

        public async Task<bool> AddUserAsync(AddUserDto userDto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(userDto.Email);
            if (existingUser != null)
            {
                return false; // User with the same Email already exists
            }
            // I will use AutoMapper in the future
            var user = new Domain.Models.Users.User()
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                Username = userDto.Username,
                PasswordHash = userDto.Password,// In a real application, ensure to hash the password properly
                Address= userDto.Address,
                City= userDto.City,
                Country= userDto.Country
            };
            await _userRepository.AddAsync(user);
            return true;
        }




    }
}
