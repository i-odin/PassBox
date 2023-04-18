using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PassBox.Mobile.Models;
using PassBox.Mobile.ViewModels.Base;
using PassBox.Mobile.Views;

namespace PassBox.Mobile.ViewModels;

[QueryProperty(nameof(Site), nameof(Site))]
public partial class SiteEditModel : BaseViewModel
{
    [ObservableProperty]
    private Site _site = new Site();

    [RelayCommand]
    public async void Submit()
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