using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.AccessControl
{
    public class Role : BaseModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = default!;
        public string? Description { get; set; }

        public virtual ICollection<RoleFeature> RoleFeatures { get; set; } = new HashSet<RoleFeature>();
        public virtual ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
    }
}
