using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PassBox.Dal.Models;
using PassBox.Mobile.ViewModels.Base;
using PassBox.Mobile.Views;

namespace PassBox.Mobile.ViewModels;

[QueryProperty(nameof(Site), nameof(Site))]
public partial class SiteEditViewModel : BaseViewModel
{
    [ObservableProperty]
    private Site _site = new Site();

    [RelayCommand]
    public void Submit()
    {
        var qwe = Site;
        Back();
    }

    [RelayCommand]
    public async void Back()
    {
        await Shell.Current.GoToAsync($"//{nameof(SiteViewPage)}");
    }
}