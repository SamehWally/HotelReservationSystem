using Domain.Enums.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Users
{
    public class Staff : User
    {
        public Role Role { get; set; }
        public string? Department { get; set; } 
        public DateTime HireDate { get; set; } = DateTime.Now;
    }
}
