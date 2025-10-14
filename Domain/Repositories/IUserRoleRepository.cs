using Domain.Models.AccessControl;

namespace Domain.Repositories
{
    public interface IUserRoleRepository
    {
        Task<bool> AssignRoleToUserAsync(int userId, int roleId);
        Task<bool> HardRemoveRoleFromUserAsync(int userId, int roleId);
        Task<IList<Role>> GetUserRolesAsync(int userId);
        Task<bool> SoftRemoveRoleFromUserAsync(int userId, int roleId);

        //Task<IList<int>> GetRolesByUserIdAsync(int userId);
        //Task<IList<int>> GetUsersByRoleIdAsync(int roleId);
    }
}
