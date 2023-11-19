using PassBox.Dal.Models.Base;

namespace PassBox.Dal.Models;

public class Other : PassBoxEntity
{
    public List<Account> Accounts { get; set; }
}