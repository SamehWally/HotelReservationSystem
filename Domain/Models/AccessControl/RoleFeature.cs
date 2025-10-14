namespace Domain.Models.AccessControl
{
    public class RoleFeature : BaseModel
    {
        public int RoleId { get; set; }
        public virtual Role Role { get; set; } = default!;

        public int FeatureId { get; set; }
        public virtual Feature Feature { get; set; } = default!;
    }
}
