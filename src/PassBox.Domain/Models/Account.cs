using PassBox.Domain.Models.Base;

namespace PassBox.Domain.Models;

public class Account : EncryptEntity
{
    public string Description { get; set; }
}