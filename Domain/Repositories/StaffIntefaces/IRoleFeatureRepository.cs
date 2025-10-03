using Domain.Models.AccessControl;

namespace Infrastructure.Repository.Staff
{
    public interface IRoleFeatureRepository
    {
        IQueryable<RoleFeature> Query();
    }
}
