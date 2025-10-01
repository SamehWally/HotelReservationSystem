using Domain.Models.AccessControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories.Staff
{
    public interface IRoleRepository
    {
        IQueryable<Role> Query();
    }
}
