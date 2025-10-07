using Domain.Models.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Users
{
    public class Staff : BaseModel
    {
        public int UserId { get; set; }
        public User User { get; set; }=default!;
        public string? Department { get; set; } 
        public DateTime HireDate { get; set; } = DateTime.Now;
    }
}
