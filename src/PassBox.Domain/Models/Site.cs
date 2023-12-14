using PassBox.Domain.Models.Base;

namespace PassBox.Domain.Models;

public class Site : PassBoxEntity
{
    public string Address { get; set; }
    public List<Account> Accounts { get; set; }
}