using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PassBox.Mobile.Models;
using PassBox.Mobile.ViewModels.Base;
using PassBox.Mobile.Views;
using System.Collections.ObjectModel;

namespace PassBox.Mobile.ViewModels;

public partial class SiteViewModel : BaseViewModel
{
    public SiteViewModel() 
    {
        Sites = new ObservableCollection<Site> { new Site { Id = Guid.NewGuid(), Name = "Google", Address = "google.com" }, new Site { Id = Guid.NewGuid(), Name = "Yandex", Address = "yandex.ru" }, new Site { Id = Guid.NewGuid(), Name = "Vk", Address = "vk.ru" } };
        accounts = new List<Account>();
    }
    public ObservableCollection<Site> Sites { get; set; }

    [ObservableProperty]
    private IEnumerable<Account> accounts;

    //[ObservableProperty]
    //private bool isExpanded;

    [RelayCommand]
    public async void Edit()
    {
        await Shell.Current.GoToAsync($"//{nameof(SiteEditPage)}");
    }

    [RelayCommand]
    public void Print(Guid id)
    {
        //var qweq = IsExpanded;
        //Accounts.Add(new Account { Name = "Логин", Password = "фывлт2ш315тр198нат9фн1" });
        Accounts = new List<Account> { new Account { Name = "Логин", Password = "фывлт2ш315тр198нат9фн1" }, new Account { Name = "фрпфыыджпфжд", Password = "фылафлыт 3215735", Description = "aadngn35" } };
    }

    [RelayCommand]
    public async void DicplayAction(Site site)
    {
        var responce = await Shell.Current.DisplayActionSheet("Меню", null, null, "Отредактировать", "Удалить", "Добавить аккаунт", "Показать аккаунты");
        if (responce == "Отредактировать")
        {
            var @params = new Dictionary<string, object>
            {
                { "Name", site.Name },
                { "Site", site }
            };
            await Shell.Current.GoToAsync($"//{nameof(SiteEditPage)}", @params);
        }
        else if (responce == "Удалить")
        {
        }
        else if (responce == "Добавить аккаунт")
        {
        }
        else if (responce == "Показать аккаунты")
        {
        }
    }
}
