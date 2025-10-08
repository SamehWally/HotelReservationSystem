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
    public class RoleRepository:IRoleRepository
    {
        private readonly Context _context;
        public RoleRepository(Context context)
        {
            _context = context;
        }

        public async Task AddAsync(Role entity)
        {
            await _context.Roles.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var role=await GetByIdAsync(id);
            if(role is not null)
            {
                role.IsDeleted=true;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r=>r.Id==id&&!r.IsDeleted);
            return role;
        }

        public async Task<Role?> GetByNameAsync(string roleName)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == roleName && !r.IsDeleted);
            return role;
        }

    }
}
