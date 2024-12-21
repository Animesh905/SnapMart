using System.Security.Cryptography;
using System.Text;

namespace SnapMart.Domain.Shared;

public static class PasswordHelper
{
    public static string GenerateSalt()
    {
        var saltBytes = new byte[16];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(saltBytes);
        }
        return Convert.ToBase64String(saltBytes);
    }
    public static string HashPassword(string password, string salt)
    {
        using (var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(salt)))
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var hashedBytes = hmac.ComputeHash(passwordBytes);
            return Convert.ToBase64String(hashedBytes);
        }
    }
}
