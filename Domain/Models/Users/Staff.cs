using Domain.Models.AccessControl;

namespace Domain.Models.Users
{
    public class Staff : BaseModel
    {
        public int UserId { get; set; }
        public User User { get; set; }=default!;
        public string? Department { get; set; } 
        public DateTime? HireDate { get; set; } = DateTime.Now;
    }
}
