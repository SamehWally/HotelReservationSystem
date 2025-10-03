using Domain.Models.AccessControl;
namespace Domain.Repositories.StaffRepo
{
    public interface IFeatureRepository
    {
        IQueryable<Feature> Query();
    }
}
