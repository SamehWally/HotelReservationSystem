using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.AccessControl
{
    public class Feature : BaseModel
    {
        [Required]
        [MaxLength(150)]
        public string Key { get; set; } = default!;
        [Required]
        [MaxLength(150)]
        public string Name { get; set; } = default!;
        [MaxLength(300)]
        public string? Description { get; set; }
        [MaxLength(300)]
        public virtual ICollection<RoleFeature> RoleFeatures { get; set; } = new HashSet<RoleFeature>();
    }
}
