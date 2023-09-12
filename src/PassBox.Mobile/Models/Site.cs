using PassBox.Mobile.Models.Base;

namespace PassBox.Mobile.Models;

public class Site : PassBoxEntity
{
    public string Address { get; set; }
    public List<SiteAccount> Accounts { get; set; }
}
