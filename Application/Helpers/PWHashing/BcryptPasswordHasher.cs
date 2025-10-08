using Domain.Models.Auth.Interfaces;

namespace Application.Helpers.PWHashing
{
    public class BcryptPasswordHasher : IPasswordHasher
    {
        public string Hash(string plainPassword)
        {
            if (string.IsNullOrWhiteSpace(plainPassword))
                throw new ArgumentException("Password is required.", nameof(plainPassword));

            return BCrypt.Net.BCrypt.HashPassword(plainPassword);
        }
        public bool Verify(string hashedPassword, string plainPassword)
        {
            if (string.IsNullOrWhiteSpace(hashedPassword) || string.IsNullOrEmpty(plainPassword))
                return false;

            return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
        }
    }
}
