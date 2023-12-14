using PassBox.Domain.Models.Enums;

namespace PassBox.Domain.Models.Interface;

public interface IEncrypt
{
    string Data { get; set; }
    string EncKey { get; set; }
    string PrivKey { get; set; }
    DataType DataType { get; set; }
    EncType EncType { get; set; }
    MasterType MasterType { get; set; }
}