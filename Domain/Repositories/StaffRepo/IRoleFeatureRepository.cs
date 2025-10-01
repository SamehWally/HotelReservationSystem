using Domain.Models.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Staff
{
    public interface IRoleFeatureRepository
    {
        IQueryable<RoleFeature> Query();
    }
}
