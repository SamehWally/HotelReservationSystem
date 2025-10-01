using Domain.Models.Auth.Models;
using Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Auth.Interfaces
{
    public interface ICredentialsAuthenticator
    {
        Task<AuthClaimsData?> AuthenticateStaffAsync(
            IQueryable<Staff> staffQuery,
            string usernameOrEmail,
            string password);

        Task<AuthClaimsData?> AuthenticateCustomerAsync(
            IQueryable<Customer> customerQuery,
            string usernameOrEmail,
            string password);
    }
}
