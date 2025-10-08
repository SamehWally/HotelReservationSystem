using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
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
        public async Task AddAsync(Customer customer)
        {
            await _context.Users.AddAsync(customer.User);
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            customer.User.IsDeleted = true;
            customer.IsDeleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAll()
        {
            return await _context.Customers
                .Where(c => !c.IsDeleted && !c.User.IsDeleted)
                .ToListAsync();
        }

        public async Task<Customer> GetByEmailAsync(string email)
        {
            var customer=await _context.Customers
                .FirstOrDefaultAsync(c => c.User.Email == email && !c.IsDeleted && !c.User.IsDeleted);

            return customer!;
        }

        public async Task<Customer> GetById(int id)
        {
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Id == id && !c.IsDeleted && !c.User.IsDeleted);
            return customer!;
        }

        public async Task<Customer> GetWhere(Expression<Func<Customer, bool>> predicate)
        {
            //var customer = await _context.Customers
            //    .Where(predicate).FirstOrDefaultAsync();
            var customer =await _context.Customers
                .FirstOrDefaultAsync( predicate );
            return customer!;
        }

        public async Task UpdateAsync(Customer customer)
        {
             _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
