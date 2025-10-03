using Domain.Models.Auth.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace Infrastructure.Repository.StaffRepo
{
    public class StaffAuthRepository : IStaffAuthRepository
    {
        private readonly Context _context;
        public StaffAuthRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<Domain.Models.Users.Staff> Query()
        {
            return _context.Staff.AsNoTracking();
        }
    }
}
