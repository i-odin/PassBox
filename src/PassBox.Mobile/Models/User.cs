using PassBox.Mobile.Models.Base;

namespace PassBox.Mobile.Models;

public class User : EncryptEntity
{
    public string Password { get; set; }
}
