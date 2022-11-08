using PassBox.Mobile.Models.Base;

namespace PassBox.Mobile.Models;

public class Account : EncryptEntity
{
    public string Password { get; set; }
    public string Description { get; set; }
}
