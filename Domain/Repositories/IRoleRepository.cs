using Domain.Models.AccessControl;

namespace Domain.Repositories
{
    public interface IRoleRepository
    {
        Task<Role?> GetByNameAsync(string roleName);
        Task<Role?> GetByIdAsync(int id);
        Task AddAsync(Role entity);
        Task<bool> DeleteAsync(int id);

    }
}
