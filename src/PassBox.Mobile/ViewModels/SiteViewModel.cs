using CommunityToolkit.Mvvm.Input;
using PassBox.Mobile.Models;
using PassBox.Mobile.ViewModels.Base;
using PassBox.Mobile.Views;

namespace PassBox.Mobile.ViewModels;

public partial class SiteViewModel : BaseViewModel
{
    public IEnumerable<Site> Sites
    {
        get
        {
            return new List<Site> { new Site { Name = "1", Address = "2"}, new Site { Name = "3", Address = "4" }, new Site { Name = "5", Address = "6" } };
        }
    }

    [RelayCommand]
    public async void Edit()
    {
        await Shell.Current.GoToAsync($"//{nameof(SiteEditPage)}");
    }
}
