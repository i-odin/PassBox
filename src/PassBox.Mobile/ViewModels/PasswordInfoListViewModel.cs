using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using PassBox.Mobile.DataBase;
using PassBox.Mobile.Models;
using PassBox.Mobile.Views;
using System.Collections.ObjectModel;

namespace PassBox.Mobile.ViewModels
{
    public partial class PasswordInfoListViewModel : BaseViewModel
    {
        private ApplicationContext _context;
        public PasswordInfoListViewModel(ApplicationContext context)
        {
            _context = context;
        }

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
                _passwordInfos.Remove(info);
                _context.Remove(info);
                _context.SaveChanges();
            }
        }

        public void Load()
        {
            if(IsBusy) return;

            IsBusy = true;
            try
            {
                PasswordInfos = new ObservableCollection<PasswordInfo>(_context.PasswordInfos);
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