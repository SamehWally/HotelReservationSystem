using Domain.Models.Users;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly Context _context;
        public CustomerRepository(Context context)
        {
            _context = context;
        }

        public IQueryable<Customer> Query()
        {
            return _context.Customers.AsNoTracking();
        }
    }
}
