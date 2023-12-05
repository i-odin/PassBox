using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PassBox.Mobile.ViewModels.Base;
using PassBox.Mobile.Views;

namespace PassBox.Mobile.ViewModels;

public partial class LoginPageViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _userName;

    [ObservableProperty]
    private string _password;

    [RelayCommand]
    public async virtual Task Login()
    {
        //TODO: Логика проверки логина и пароля
        await Shell.Current.GoToAsync(SiteViewPage.Location);
    }

    [RelayCommand]
    public async virtual Task Register()
    {
        await Shell.Current.GoToAsync(RegisterPage.Location);
    }
}