using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Users;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }
        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var  user=await _context.Users.FirstOrDefaultAsync(u => u.Email == email&&!u.IsDeleted);
            return user!;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id && !u.IsDeleted);
            return user!;
        }

        public async Task<User> GetWhere(Expression<Func<User, bool>> predicate)
        {
            var user= await _context.Users.Where(predicate).FirstOrDefaultAsync();
            return user!;

        }


        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
