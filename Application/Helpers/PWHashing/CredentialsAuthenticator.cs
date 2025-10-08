using Application.SecurityInterfaces;
using Domain.Models.Auth.Interfaces;
using Domain.Models.Auth.Models;
using Domain.Models.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Helpers.PWHashing
{
    public class CredentialsAuthenticator : ICredentialsAuthenticator
    {
        private readonly IPasswordHasher _hasher;
        public CredentialsAuthenticator(IPasswordHasher hasher)
        {
            _hasher = hasher;
        }

        public Task<AuthClaimsDataDto?> AuthenticateCustomerAsync(IQueryable<Customer> customerQuery, string usernameOrEmail, string password)
        {
            throw new NotImplementedException();
        }

        public Task<AuthClaimsDataDto?> AuthenticateStaffAsync(IQueryable<Staff> staffQuery, string usernameOrEmail, string password)
        {
            throw new NotImplementedException();
        }


        //public async Task<AuthClaimsDataDto?> AuthenticateStaffAsync(
        //     IQueryable<Staff> staffQuery,
        //     string usernameOrEmail,
        //     string password)
        //{
        //    if (string.IsNullOrWhiteSpace(usernameOrEmail) || string.IsNullOrEmpty(password))
        //        return null;

        //    var key = usernameOrEmail.Trim().ToLower();

        //    var user = await staffQuery
        //        .Where(s =>
        //            (s.Username != null && s.Username.ToLower() == key) ||
        //            (s.Email != null && s.Email.ToLower() == key))
        //        .Select(s => new
        //        {
        //            s.Id,
        //            s.Username,
        //            s.Email,
        //            s.PasswordHash,
        //            s.RoleId,
        //            RoleName = s.Role != null ? s.Role.Name : null
        //        })
        //        .FirstOrDefaultAsync();

        //    if (user is null) return null;
        //    if (!_hasher.Verify(user.PasswordHash, password)) return null;

        //    var featureKeys = await staffQuery
        //        .Where(s => s.Id == user.Id && s.Role != null)
        //        .SelectMany(s => s.Role.RoleFeatures.Select(rf => rf.Feature.Key))
        //        .ToListAsync();

        //    return new AuthClaimsDataDto(
        //        UserId: user.Id,
        //        RoleId: user.RoleId,
        //        RoleName: user.RoleName ?? "Staff",
        //        FeatureKeys: featureKeys,
        //        Username: user.Username,
        //        Email: user.Email
        //    );
        //}

        //Customer
        //public async Task<AuthClaimsDataDto?> AuthenticateCustomerAsync(
        //  IQueryable<Customer> customerQuery,
        //  string usernameOrEmail,
        //  string password)
        //{
        //    if (string.IsNullOrWhiteSpace(usernameOrEmail) || string.IsNullOrEmpty(password))
        //        return null;

        //    var key = usernameOrEmail.Trim().ToLower();

        //    var user = await customerQuery
        //        .Where(c =>
        //            (c.Username != null && c.Username.ToLower() == key) ||
        //            (c.Email != null && c.Email.ToLower() == key))
        //        .Select(c => new
        //        {
        //            c.Id,
        //            c.Username,
        //            c.Email,
        //            c.PasswordHash
        //        })
        //        .FirstOrDefaultAsync();

        //    if (user is null) return null;
        //    if (!_hasher.Verify(user.PasswordHash, password)) return null;

        //    return new AuthClaimsDataDto(
        //        UserId: user.Id,
        //        RoleId: null,
        //        RoleName: null,
        //        FeatureKeys: Array.Empty<string>(),
        //        Username: user.Username,
        //        Email: user.Email
        //    );
        //}
    }
}
