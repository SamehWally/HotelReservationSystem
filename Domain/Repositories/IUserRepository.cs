using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Users;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);

        Task<User> GetByEmailAsync(string email);

        Task<User>GetWhere(Expression<Func<User, bool>> predicate);

        Task AddAsync(User user);
        Task UpdateAsync(User entity);
        Task DeleteAsync(int id);
    }
}
