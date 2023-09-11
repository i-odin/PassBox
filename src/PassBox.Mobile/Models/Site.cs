using PassBox.Mobile.Models.Base;

namespace PassBox.Mobile.Models;

public class Site : PassBoxEntity
{
    public string Address { get; set; }
    public IEnumerable<SiteAccount> Accounts { get; set; }
}
