using PassBox.Mobile.Views;

namespace PassBox.Mobile.ViewModels;

public partial class RegisterPageViewModel : LoginPageViewModel
{
    public override async Task Login()
    {
        await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
    }

    public async override Task Register()
    {
        //TODO: Логика регистрации
        await base.Login();
    }
}