using Domain.Models.Users;

namespace Domain.Repositories
{
    public interface IStaffRepository
    {
        Task<Staff?> GetByIdAsync(int id);
        Task<bool> ExistsAsync(int id);
        Task<bool> AddAsync(Staff staff);
        Task<bool> Update(Staff staff);
        Task<bool> SoftDeleteAsync(int id);
        IQueryable<Staff> GetByDepartment(string department);
        Task<Staff> GetByEmailAsync(string email);
        IQueryable<Staff> GetAll();
    }
}
