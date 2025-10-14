using Domain.Models.AccessControl;

namespace Domain.Repositories
{
    public interface IRoleFeatureRepository
    {
        Task<bool> AssignFeatureToRoleAsync(int roleId, int featureId);
        Task<bool> HardRemoveFeatureFromRoleAsync(int roleId, int featureId);
        Task<IList<Feature>> GetFeatuesOfRoleAsync(int roleId);
        Task<bool> SoftRemoveFeatureFromRoleAsync(int roleId, int featureId);
        Task<bool> CheckFeatureAccessAsync(List<int> roleIds, string featureName);
    }
}
