using Domain.Models.Users;

namespace Domain.Repositories.CustomerInterfaces
{
    public interface ICustomerAuthRepository
    {
        IQueryable<Customer> Query();
    }
}
