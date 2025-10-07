using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.AccessControl;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly Context _context;

        public UserRoleRepository(Context context)
        {
            _context = context;
        }

        public async Task<bool> AssignRoleToUserAsync(int userId, int roleId)
        {
            var userRole = new UserRole { UserId = userId, RoleId = roleId };
            await _context.UserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> HardRemoveRoleFromUserAsync(int userId, int roleId)
        {
            var userRole = await _context.UserRoles
                .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);

            if (userRole != null)
            {
                _context.UserRoles.Remove(userRole);
                await _context.SaveChangesAsync();
            }
            return true;
        }
        public async Task<bool> SoftRemoveRoleFromUserAsync(int userId, int roleId)
        {
            var userRole = await _context.UserRoles
                .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.RoleId == roleId);

            if (userRole != null)
            {
                userRole.IsDeleted=true;
                await _context.SaveChangesAsync();
            }
            return true;
        }

        public async Task<IList<Role>> GetUserRolesAsync(int userId)
        {
            var roles= await _context.UserRoles
                .Where(ur => ur.UserId == userId && !ur.IsDeleted)
                .Select(ur => ur.Role)
                .ToListAsync();
            return roles;
        }
    
    }
}
