using Domain.Models.AccessControl;
using Domain.Repositories.StaffRepo;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.StaffRepo
{
    public sealed class FeatureRepository : IFeatureRepository
    {
        private readonly Context _context;
        public FeatureRepository(Context context)
        {
            _context = context;
        }
        public IQueryable<Feature> Query()
        {
            return _context.Set<Feature>().AsNoTracking();
        }
    }
}
