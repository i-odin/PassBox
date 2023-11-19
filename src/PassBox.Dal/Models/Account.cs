using PassBox.Dal.Models.Base;

namespace PassBox.Dal.Models;

public class Account : EncryptEntity
{
    public string Password { get; set; }
    public string Description { get; set; }
}

public class SiteAccount : Account
{
    public int SiteId { get; set; }
}

public class OtherAccount : Account
{
    public int OtherId { get; set; }
}
