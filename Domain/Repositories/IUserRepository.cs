using Domain.Models.Users;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);

        Task<User> GetByEmailAsync(string email);

        Task<User> GetWhere(Expression<Func<User, bool>> predicate);

        Task AddAsync(User user);
        Task UpdateAsync(User entity);
        Task DeleteAsync(int id);
    }
}
