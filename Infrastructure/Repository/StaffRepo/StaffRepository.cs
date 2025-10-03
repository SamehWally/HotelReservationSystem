using Domain.Repositories.StaffRepo;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Repository.StaffRepo
{
    public class StaffRepository : IStaffRepository
    {
        private readonly Context _context;
        public StaffRepository(Context context)
        {
            _context = context;
        }
        public IQueryable<Domain.Models.Users.Staff> Query()
        {
            return _context.Set<Domain.Models.Users.Staff>().AsNoTracking();
        }

        public async Task AddAsync(Domain.Models.Users.Staff staff)
        {
            await _context.AddAsync(staff);
            await _context.SaveChangesAsync();
        }
    }
}
