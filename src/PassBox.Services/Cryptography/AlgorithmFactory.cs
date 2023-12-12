namespace PassBox.Services.Cryptography;

public interface IAlgorithmFactory
{
    IDataAlgorithm CreateDataAlgorithm(DataType type, byte[] key);
    IKeyEncryptAlgorithm CreateKeyEncryptAlgorithm(EncType type, byte[] key);
    IMasterAlgorithm CreateMasterAlgorithm(MasterType type);
}

public class AlgorithmFactory : IAlgorithmFactory
{
    public IDataAlgorithm CreateDataAlgorithm(DataType type, byte[] key)
    {
        return type switch
        {
            DataType.EAS => new AesAlgorithm(key),
            _ => throw new NotSupportedException(),
        };
    }

    public IKeyEncryptAlgorithm CreateKeyEncryptAlgorithm(EncType type, byte[] key)
    {
        return type switch
        {
            EncType.RSA_OAEP => new RsaOaepAndPkcs8Algorithm(key),
            _ => throw new NotSupportedException(),
        };
    }

    public IMasterAlgorithm CreateMasterAlgorithm(MasterType type)
    {
        return type switch
        {
            MasterType.Rfc_10000_sha256 => new RfcAlgorithm(),
            _ => throw new NotSupportedException(),
        };
    }
}