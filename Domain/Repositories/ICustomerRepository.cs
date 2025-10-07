using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Models.Users;

namespace Domain.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetById(int id);
        Task<List<Customer>> GetAll();
        Task<Customer> GetByEmailAsync(string email);
        Task<Customer> GetWhere(Expression<Func<Customer, bool>> predicate);
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(int id);

    }
}
