using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PassBox.Mobile.Models;
using PassBox.Mobile.Views;

namespace PassBox.Mobile.ViewModels
{
    [QueryProperty(nameof(PasswordInfo), nameof(PasswordInfo))]
    public partial class PasswordInfoAddUpdateViewModel : BaseViewModel
    {
        [ObservableProperty]
        private PasswordInfo _passwordInfo = new PasswordInfo();

        [RelayCommand]
        public async void AddUpdatePasswordInfo()
        {
            var result = false;
            if(PasswordInfo.Id > 0)
            {
                result = PasswordInfoService.Update(PasswordInfo);
            }
            else
            {
                var item = PasswordInfo.Create();
                item.Data = PasswordInfo.Data;
                item.Name = PasswordInfo.Name;
                result = PasswordInfoService.Add(item);
            }

            if(result)
            {
                await Shell.Current.DisplayAlert("Password add", "Password added to PasswordInfo table", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Not added", "Something went wrong while adding password", "OK");
            }
        }

        [RelayCommand]
        public async void Back()
        {
            await Shell.Current.GoToAsync($"//{nameof(PasswordInfoListPage)}");
        }
    }
}
