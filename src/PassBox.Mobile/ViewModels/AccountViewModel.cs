using CommunityToolkit.Mvvm.Input;
using PassBox.Domain.Models;
using PassBox.Mobile.ViewModels.Base;

namespace PassBox.Mobile.ViewModels;

public partial class AccountViewModel : BaseViewModel
{
    public IEnumerable<Account> Accounts
    {
        get
        {
            return new List<Account> { new Account { Name = "Логин", Data = "фывлт2ш315тр198нат9фн1" }, new Account { Name = "фрпфыыджпфжд", Data = "фылафлыт 3215735", Description = "aadngn35" } };
        }
    }
}

public partial class SiteAccountViewModel : AccountViewModel
{
    public string Qwe { get; set; }
    [RelayCommand]
    public void Print(Guid id)
    {
        Qwe = "ДА!";
    }
}