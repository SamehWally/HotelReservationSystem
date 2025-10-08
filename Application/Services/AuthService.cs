using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DTOs.Login;
using Application.Helpers;
using Domain.Models.AccessControl;
using Domain.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Application.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly IUserRoleRepository _userRoleRepo;
        private readonly IRoleFeatureRepository _roleFeatureRepo;

        public AuthService(IUserRepository userRepo, IUserRoleRepository userRoleRepo, IRoleFeatureRepository roleFeatureRepo)
        {
            _userRepo = userRepo;
            _userRoleRepo = userRoleRepo;
            _roleFeatureRepo = roleFeatureRepo;
        }

        //Register

        public async Task<LoginResponseDto?> LoginAsync(LoginRequestDto dto)
        {
            string hashedPassword = HashHelper.ComputeHash(dto.Password);
            string hashedUserName = HashHelper.ComputeHash(dto.UserName);

            var user= await _userRepo.GetWhere(u=>u.PasswordHash==hashedPassword&&u.Username==hashedUserName);

            if (user == null)
            {
                return null; // User not found or invalid credentials
            }
            var roles =await  _userRoleRepo.GetUserRolesAsync(user.Id);
            var features = new List<Feature>();
            foreach (var role in roles)
            {
                features.AddRange(await _roleFeatureRepo.GetFeatuesOfRoleAsync(role.Id));
            }

            var token = TokenGenerator.GenerateToken(user.Id, user.Username, roles.Select(r => r.Name).ToList());

            var response= new LoginResponseDto
            {
                Token = token,
                UserName = user.Username,
                Roles = roles.Select(r => r.Name).ToList(),
                Features = features.Select(f => f.Name).ToList()
            };

            return response;



        }




    }
}
