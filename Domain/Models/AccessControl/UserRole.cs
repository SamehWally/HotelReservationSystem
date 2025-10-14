using Domain.Models.Users;

namespace Domain.Models.AccessControl
{
    public class UserRole : BaseModel
    {
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;

    }
}
