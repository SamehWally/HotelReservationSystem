using Domain.Models.Users;
using Domain.Repositories.Staff;
using Domain.Repositories.StaffRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.StaffRepo
{
    public class StaffRepository : IStaffRepository
    {
        private readonly Context _context;
        public StaffRepository(Context context)
        {
            _context = context;
        }
        public IQueryable<Domain.Models.Users.Staff> Query()
        {
            return _context.Set<Domain.Models.Users.Staff>().AsNoTracking();
        }
    }
}
