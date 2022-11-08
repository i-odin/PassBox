using PassBox.Mobile.Models.Base;

namespace PassBox.Mobile.Models;

public class Other : PassBoxEntity
{
    public List<Account> Accounts { get; set; }
}