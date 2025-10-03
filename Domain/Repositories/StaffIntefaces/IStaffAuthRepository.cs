using Domain.Models.Users;

namespace Domain.Models.Auth.Interfaces
{

    public interface IStaffAuthRepository
    {
        IQueryable<Staff> Query(); 
    }
}
