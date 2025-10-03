using Domain.Models.AccessControl;

namespace Domain.Models.Users
{
    public class Staff : User
    {
        public Role Role { get; set; }
        public int RoleId { get; set; }
        public string? Department { get; set; } 
        public DateTime? HireDate { get; set; } = DateTime.Now;
    }
}
