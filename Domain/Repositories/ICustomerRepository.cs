using Domain.Models.Users;

namespace Domain.Repositories
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> Query();
    }
}
