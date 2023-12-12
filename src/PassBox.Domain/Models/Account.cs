using PassBox.Domain.Models.Base;

namespace PassBox.Domain.Models;

public class Account : EncryptEntity
{
    public string Password { get; set; }
    public string Description { get; set; }
}

public class OtherAccount : Account
{
    public int OtherId { get; set; }
}
