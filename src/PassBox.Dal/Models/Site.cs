using PassBox.Dal.Models.Base;

namespace PassBox.Dal.Models;

public class Site : PassBoxEntity
{
    public string Address { get; set; }
    public List<SiteAccount> Accounts { get; set; }
}