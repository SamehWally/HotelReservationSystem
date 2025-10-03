using Domain.Models.AccessControl;

namespace Domain.Repositories.Staff
{
    public interface IRoleRepository
    {
        IQueryable<Role> Query();
    }
}
