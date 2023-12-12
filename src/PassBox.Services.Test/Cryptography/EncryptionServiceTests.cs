using PassBox.Services.Cryptography;

namespace PassBox.Services.Test.Cryptography;

public class EncryptionServiceTests
{
    [Theory]
    [InlineData("Hello", "123")]
    public void EncriptPassword(string text, string master)
    {
        IEncryptionService encryptionService = new EncryptionService(new AlgorithmFactory());

        var encryptTest = new Test { Data = text };
        encryptionService.Encrypt(encryptTest, master);

        encryptionService.Decrypt(encryptTest, master);

        Assert.Equal(expected: text, actual: encryptTest.Data);
    }

    public class Test : IEncrypt
    {
        public string Data { get; set; }
        public string EncKey { get; set; }
        public string PrivKey { get; set; }
        public DataType DataType { get; set; }
        public EncType EncType { get; set; }
        public MasterType MasterType { get; set; }
    }
}
