using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PassBox.Mobile.Models;
using PassBox.Mobile.Views;
using System.Collections.ObjectModel;

namespace PassBox.Mobile.ViewModels
{
    public partial class PasswordInfoListViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<PasswordInfo> _passwordInfos;

        [RelayCommand]
        public async void AddUpdatePasswordInfo()
        {
            await Shell.Current.GoToAsync($"//{nameof(PasswordInfoAddUpdatePage)}");
        }

        [RelayCommand]
        public async void DicplayAction(PasswordInfo info)
        {
            var responce = await Shell.Current.DisplayActionSheet("Select option", "OK", null, "Edit", "Delete");
            if(responce == "Edit")
            {
                var @params = new Dictionary<string, object>
                {
                    { nameof(PasswordInfo), info }
                };
                await Shell.Current.GoToAsync($"//{nameof(PasswordInfoAddUpdatePage)}", @params);
            }
            else if(responce == "Delete")
            {
                if (PasswordInfoService.Remove(info))
                {
                    _passwordInfos = new ObservableCollection<PasswordInfo>(PasswordInfoService.GetPasswordInfos());
                }
            }
        }

        public void Load()
        {
            if(IsBusy) return;

            IsBusy = true;
            try
            {
                PasswordInfos = new ObservableCollection<PasswordInfo>(PasswordInfoService.GetPasswordInfos());
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}