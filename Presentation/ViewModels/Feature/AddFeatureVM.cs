using System.ComponentModel.DataAnnotations;

namespace Presentation.ViewModels.Feature
{
    public class AddFeatureVM
    {
        
        public string Key { get; set; } = default!;

        
        public string Name { get; set; } = default!;

        
        public string? Description { get; set; }
    }
}
