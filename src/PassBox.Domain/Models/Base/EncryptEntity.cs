using PassBox.Domain.Models.Enums;
using PassBox.Domain.Models.Interface;

namespace PassBox.Domain.Models.Base;

public abstract class EncryptEntity : PassBoxEntity, IEncrypt
{
    public string Data { get; set; }
    public string EncKey { get; set; }
    public string PrivKey { get; set; }
    public DataType DataType { get; set; }
    public EncType EncType { get; set; }
    public MasterType MasterType { get; set; }
}