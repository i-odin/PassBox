using System.Security.Cryptography;

namespace PassBox.Services.Cryptography;

public interface IMasterAlgorithm
{
    byte[] Hash(string source);
}

public class RfcAlgorithm : IMasterAlgorithm
{
    private readonly byte[] _salt = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16];
    public byte[] Hash(string source)
    {
        using (var rfc = new Rfc2898DeriveBytes(source, _salt, 10000, HashAlgorithmName.SHA256))
        {
            return rfc.GetBytes(32);
        }
    }
}