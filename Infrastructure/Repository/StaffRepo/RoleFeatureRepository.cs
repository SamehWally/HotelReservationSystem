using Domain.Models.AccessControl;
using Infrastructure.Repository.Staff;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.StaffRepo
{
    public sealed class RoleFeatureRepository : IRoleFeatureRepository
    {
        private readonly Context _context;
        public RoleFeatureRepository(Context context)
        {
            _context = context;
        }
        public IQueryable<RoleFeature> Query()
        {
            return _context.Set<RoleFeature>().AsNoTracking();
        }
    }
}
