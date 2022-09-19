using PassBox.Mobile.Views;

namespace PassBox.Mobile.ViewModels
{
    public partial class RegisterPageViewModel : LiginPageViewModel
    {
        public override async void Login()
        {
            await Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
        }

        public async override void Register()
        {
            //TODO: Логика регистрации
            Login();
        }
    }
}
