using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace PassBox.Mobile.ViewModels
{
    public partial class LiginPageViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _userName;

        [ObservableProperty]
        private string _password;

        [RelayCommand]
        public void Login()
        {
            //LoginCommand.Execute(this);
        }
    }
}
