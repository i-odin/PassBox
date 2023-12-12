using System.Security.Cryptography.Pkcs;
using System.Security.Cryptography;

namespace PassBox.Services.Cryptography;

public interface IKeyEncryptAlgorithm
{
    byte[] Decrypt(byte[] data, byte[] privateKey);
    byte[] Encrypt(byte[] data, out byte[] privateKey);
}

public class RsaOaepAndPkcs8Algorithm : IKeyEncryptAlgorithm
{
    private readonly byte[] _key;
    public RsaOaepAndPkcs8Algorithm(byte[] key)
    {
        _key = key;
    }

    public byte[] Decrypt(byte[] data, byte[] privateKey)
    {
        using (var rsa = new RSACryptoServiceProvider())
        {
            rsa.ImportEncryptedPkcs8PrivateKey(_key, privateKey, out int _);
            return rsa.Decrypt(data, true);
        }
    }

    public byte[] Encrypt(byte[] data, out byte[] privateKey)
    {
        using (var rsa = new RSACryptoServiceProvider())
        {
            privateKey = Pkcs8PrivateKeyInfo.Create(rsa).Encrypt(_key, new PbeParameters(PbeEncryptionAlgorithm.Aes256Cbc, HashAlgorithmName.SHA256, 10000));
            return rsa.Encrypt(data, true);
        }
    }
}