using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Domain.Repositories.StaffRepo
{
    public interface IStaffRepository
    {
        IQueryable<Models.Users.Staff> Query();
    }
}
