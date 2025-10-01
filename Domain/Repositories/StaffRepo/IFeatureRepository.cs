using Domain.Models.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.StaffRepo
{
    public interface IFeatureRepository
    {
        IQueryable<Feature> Query();
    }
}
