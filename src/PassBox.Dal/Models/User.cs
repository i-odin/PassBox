using PassBox.Dal.Models.Base;

namespace PassBox.Dal.Models;

public class User : EncryptEntity
{
    public string Password { get; set; }
}