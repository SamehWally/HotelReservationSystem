using Domain.Models.Auth.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Auth.Authentication
{
    public class BcryptPasswordHasher : IPasswordHasher
    {
        public bool Verify(string hashedPassword, string plainPassword)
        {
            if (string.IsNullOrWhiteSpace(hashedPassword) || string.IsNullOrEmpty(plainPassword))
                return false;

            return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
        }
    }
}
