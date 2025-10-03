namespace Domain.Repositories.StaffRepo
{
    public interface IStaffRepository
    {
        IQueryable<Models.Users.Staff> Query();
        Task AddAsync(Domain.Models.Users.Staff staff);
    }
}
