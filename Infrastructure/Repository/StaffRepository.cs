using Domain.Models.Users;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class StaffRepository : IStaffRepository
    {
        private readonly Context _context;
        public StaffRepository(Context context)
        {
            _context = context;
        }


        public async Task<bool> AddAsync(Staff staff)
        {
            await _context.Users.AddAsync(staff.User);
            await _context.Staff.AddAsync(staff);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Staff
                .AnyAsync(s => s.Id == id && !s.IsDeleted && !s.User.IsDeleted);
        }
        public IQueryable<Staff> GetAll()
        {
            return _context.Staff
                .Where(s => !s.IsDeleted && !s.User.IsDeleted);
        }
        public IQueryable<Staff> GetByDepartment(string department)
        {
            return _context.Staff
                .Where(s => s.Department == department && !s.IsDeleted);
        }
        public async Task<Staff> GetByEmailAsync(string email)
        {
            var staff = await _context.Staff
                .FirstOrDefaultAsync(c => c.User.Email == email && !c.IsDeleted && !c.User.IsDeleted);

            return staff!;
        }
        public async Task<Staff?> GetByIdAsync(int id)
        {
            return await _context.Staff
                .FirstOrDefaultAsync(s => s.Id == id && !s.IsDeleted && !s.User.IsDeleted);
        }
        public async Task<bool> SoftDeleteAsync(int id)
        {
            await _context.Staff
                .Where(s => s.Id == id)
                .ExecuteUpdateAsync(s => s.SetProperty(s => s.IsDeleted, true));
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> Update(Staff staff)
        {
            _context.Update(staff);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
