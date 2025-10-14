using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels.Role
{
    public class AddRoleVM
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = default!;

        public string? Description { get; set; }
    }
}
