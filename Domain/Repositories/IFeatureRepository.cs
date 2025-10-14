using Domain.Models.AccessControl;

namespace Domain.Repositories
{
    public interface IFeatureRepository
    {
        Task<Feature?> GetByNameAsync(string roleName);
        Task<Feature?> GetByIdAsync(int id);
        Task AddAsync(Feature entity);
        Task<bool> DeleteAsync(int id);
    }
}
