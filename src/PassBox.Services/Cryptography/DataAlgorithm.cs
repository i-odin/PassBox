using System.Security.Cryptography;

namespace PassBox.Services.Cryptography;

public interface IDataAlgorithm
{
    byte[] Decrypt(byte[] data);
    byte[] Encrypt(byte[] data);
}

public class AesAlgorithm : IDataAlgorithm
{
    private readonly byte[] _key;
    public AesAlgorithm(byte[] key)
    {
        _key = key;
    }

    public byte[] Decrypt(byte[] data)
    {
        using (var aes = CreateAes())
        {
            var result = new List<byte>(data.Length);
            using (var stream = new MemoryStream(data))
            {
                using (var crypto = new CryptoStream(stream, aes.CreateDecryptor(aes.Key, aes.IV), CryptoStreamMode.Read))
                {
                    int input;
                    while ((input = crypto.ReadByte()) != -1)
                        result.Add((byte)input);
                }
            }

            return result.ToArray();
        }
    }

    private Aes CreateAes()
    {
        var aes = Aes.Create();
        aes.IV = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16];
        aes.Key = _key;
        return aes;
    }

    public byte[] Encrypt(byte[] data)
    {
        using (var aes = CreateAes())
        {
            using (var stream = new MemoryStream())
            {
                using (var crypto = new CryptoStream(stream, aes.CreateEncryptor(aes.Key, aes.IV), CryptoStreamMode.Write))
                    crypto.Write(data, 0, data.Length);

                return stream.ToArray();
            }
        }
    }
}