using Domain.Models.Auth.Models;
using Domain.Models.Users;

namespace Application.SecurityInterfaces
{
    public interface ICredentialsAuthenticator
    {
        Task<AuthClaimsDataDto?> AuthenticateStaffAsync(
            IQueryable<Staff> staffQuery,
            string usernameOrEmail,
            string password);

        Task<AuthClaimsDataDto?> AuthenticateCustomerAsync(
            IQueryable<Customer> customerQuery,
            string usernameOrEmail,
            string password);
    }
}
