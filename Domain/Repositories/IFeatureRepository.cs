using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
