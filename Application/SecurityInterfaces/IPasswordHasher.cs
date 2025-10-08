namespace Domain.Models.Auth.Interfaces
{
    public interface IPasswordHasher
    {
        string Hash(string plainPassword);
        bool Verify(string hashedPassword, string plainPassword);
    }
}
