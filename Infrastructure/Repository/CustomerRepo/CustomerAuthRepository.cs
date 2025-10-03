using Domain.Models.Users;
using Domain.Repositories.CustomerInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository.CustomerRepo
{
    public class CustomerAuthRepository : ICustomerAuthRepository
    {
        private readonly Context _context;
        public CustomerAuthRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<Customer> Query()
        {
            return _context.Customers.AsNoTracking();
        }
    }
}
