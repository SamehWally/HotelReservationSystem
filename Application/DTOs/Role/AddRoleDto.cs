using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Role
{
    public class AddRoleDto
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
    }
}
