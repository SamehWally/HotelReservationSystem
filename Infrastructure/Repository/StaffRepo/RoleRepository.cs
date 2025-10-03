using Domain.Models.AccessControl;
using Domain.Repositories.Staff;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.StaffRepo
{
    public sealed class RoleRepository : IRoleRepository
    {
        private readonly Context _context;
        public RoleRepository(Context context)
        {
            _context = context;
        }
        public IQueryable<Role> Query()
        {
            return _context.Set<Role>().AsNoTracking();
        }
    }
}
