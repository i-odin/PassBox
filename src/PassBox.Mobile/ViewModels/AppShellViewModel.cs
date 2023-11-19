using CommunityToolkit.Mvvm.Input;
using PassBox.Mobile.ViewModels.Base;
using PassBox.Mobile.Views;

namespace PassBox.Mobile.ViewModels;

public partial class AppShellViewModel : BaseViewModel
{
    [RelayCommand]
    public async void SignOut()
    {
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }
}