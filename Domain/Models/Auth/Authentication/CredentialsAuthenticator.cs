using Domain.Models.Auth.Interfaces;
using Domain.Models.Auth.Models;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Auth.Authentication
{
    public class CredentialsAuthenticator : ICredentialsAuthenticator
    {
        private readonly IPasswordHasher _hasher;
        public CredentialsAuthenticator(IPasswordHasher hasher)
        {
            _hasher = hasher;
        }


        public async Task<AuthClaimsData?> AuthenticateStaffAsync(
             IQueryable<Staff> staffQuery,
             string usernameOrEmail,
             string password)
        {
            if (string.IsNullOrWhiteSpace(usernameOrEmail) || string.IsNullOrEmpty(password))
                return null;

            var key = usernameOrEmail.Trim().ToLower();

            var user = await staffQuery
                .Where(s =>
                    (s.Username != null && s.Username.ToLower() == key) ||
                    (s.Email != null && s.Email.ToLower() == key))
                .Select(s => new
                {
                    s.Id,
                    s.Username,
                    s.Email,
                    s.PasswordHash,
                    s.RoleId,
                    RoleName = s.Role != null ? s.Role.Name : null
                })
                .FirstOrDefaultAsync();

            if (user is null) return null;
            if (!_hasher.Verify(user.PasswordHash, password)) return null;

            var featureKeys = await staffQuery
                .Where(s => s.Id == user.Id && s.Role != null)
                .SelectMany(s => s.Role.RoleFeatures.Select(rf => rf.Feature.Key))
                .ToListAsync();

            return new AuthClaimsData(
                UserId: user.Id,
                RoleId: user.RoleId,
                RoleName: user.RoleName ?? "Staff",
                FeatureKeys: featureKeys,
                Username: user.Username,
                Email: user.Email
            );
        }

        //Customer
        public Task<AuthClaimsData?> AuthenticateCustomerAsync(IQueryable<Customer> customerQuery, string usernameOrEmail, string password)
        {
            throw new NotImplementedException();
        }
    }
}
