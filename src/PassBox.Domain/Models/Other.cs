using PassBox.Domain.Models.Base;

namespace PassBox.Domain.Models;

public class Other : PassBoxEntity
{
    public List<Account> Accounts { get; set; }
}