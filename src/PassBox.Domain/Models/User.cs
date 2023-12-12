using PassBox.Domain.Models.Base;

namespace PassBox.Domain.Models;

public class User : EncryptEntity
{
    public string Password { get; set; }
}