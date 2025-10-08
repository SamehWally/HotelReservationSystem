using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.AccessControl;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class FeatureRepository : IFeatureRepository
    {
        private readonly Context _context;

        public FeatureRepository(Context context)
        {
            _context = context;
        }


        public async Task<Feature?> GetByIdAsync(int id)
        {
            var feature= await _context.Features.FindAsync(id);
            return feature;
        }

        public async Task<Feature?> GetByNameAsync(string featureName)
            => await _context.Features.FirstOrDefaultAsync(f => f.Name == featureName);

        public async Task AddAsync(Feature entity)
        {
            await _context.Features.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var feature = await GetByIdAsync(id);
            if (feature is not null)
            {
                feature.IsDeleted = true;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
