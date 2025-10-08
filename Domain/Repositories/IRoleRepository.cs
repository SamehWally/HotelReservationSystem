using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
