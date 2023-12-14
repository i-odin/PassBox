using PassBox.Domain.Models.Enums;
using PassBox.Domain.Models.Interface;
using System.Security.Cryptography;
using System.Text;

namespace PassBox.Services.Cryptography;

public interface IEncryptionService
{
    void Decrypt(IEncrypt input, string unlockKey);
    void Encrypt(IEncrypt input, string unlockKey);
}

public class EncryptionService : IEncryptionService
{
    private readonly IAlgorithmFactory _factory;
    public EncryptionService(IAlgorithmFactory factory)
    {
        _factory = factory;
    }

    public void Decrypt(IEncrypt input, string unlockKey)
    {
        var arrayUnlockKey = _factory.CreateMasterAlgorithm(input.MasterType).Hash(unlockKey);
        var arrayEncKey = Convert.FromBase64String(input.EncKey);
        var arrayPrivKey = Convert.FromBase64String(input.PrivKey);
        var arrayData = Convert.FromBase64String(input.Data);

        arrayEncKey = _factory.CreateKeyEncryptAlgorithm(input.EncType, arrayUnlockKey).Decrypt(arrayEncKey, arrayPrivKey);
        arrayData = _factory.CreateDataAlgorithm(input.DataType, arrayEncKey).Decrypt(arrayData);

        input.Data = Encoding.UTF8.GetString(arrayData);
    }

    //https://habr.com/ru/companies/yandex/articles/344382/
    public void Encrypt(IEncrypt source, string unlockKey)
    {
        source.MasterType = MasterType.Rfc_10000_sha256;
        source.DataType = DataType.EAS;
        source.EncType = EncType.RSA_OAEP;

        var arrayEncKey = GetEncKey();
        var arrayData = Encoding.UTF8.GetBytes(source.Data);
        var arrayUnlockKey = _factory.CreateMasterAlgorithm(source.MasterType).Hash(unlockKey);

        arrayData = _factory.CreateDataAlgorithm(source.DataType, arrayEncKey).Encrypt(arrayData);
        arrayEncKey = _factory.CreateKeyEncryptAlgorithm(source.EncType, arrayUnlockKey).Encrypt(arrayEncKey, out byte[] privKey);

        source.PrivKey = Convert.ToBase64String(privKey);
        source.EncKey = Convert.ToBase64String(arrayEncKey);
        source.Data = Convert.ToBase64String(arrayData);
    }

    private byte[] GetEncKey()
    {
        var result = new byte[32];
        RandomNumberGenerator.Create().GetBytes(result);
        return result;
    }
}