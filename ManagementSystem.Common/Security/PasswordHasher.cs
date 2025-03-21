using System.Security.Cryptography;
using System.Text;

namespace ManagmentSystem.Common.Security;

public static class PasswordHasher
{
    public static string ComputeStringToSha256Hash(string plaintText)
    {
        using SHA256 sha256Hash = SHA256.Create();
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(plaintText));
        StringBuilder builder = new();
        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2"));
        }

        return builder.ToString();

    }
}