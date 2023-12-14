using CommunityToolkit.Mvvm.Input;
using PassBox.Domain.Models;
using PassBox.Infrastructure.Data;
using PassBox.Mobile.ViewModels.Base;
using PassBox.Mobile.Views;
using System.Collections.ObjectModel;

namespace PassBox.Mobile.ViewModels;

public partial class SiteViewModel : BaseViewModel
{
    private readonly ApplicationContext _applicationContext;
    public SiteViewModel(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public ObservableCollection<Site> Sites { get; set; } = new ObservableCollection<Site>();
    public bool IsExpanded { get; set; }

    [RelayCommand]
    public void GetAccounts(Guid id)
    {
        foreach (var item in Sites)
        {
            item.Name = "!!!";
        }

        //Sites.Add(new Site { Name = "test", Address = "test" });

        //Расшифровку возможно нужно сделать
        var site = Sites.First(x => x.Id == id);
        if (IsExpanded)
        //foreach (var item in site.Accounts)
        {
            //if(site.Accounts != null) { site.Accounts.Add(new SiteAccount { Name = "test" }); }
            //item.Name = "Расшифровали";
            //site.Accounts = new List<SiteAccount> { new SiteAccount { Name = Guid.NewGuid().ToString(), Password = "фывлт2ш315тр198нат9фн1" }, new SiteAccount { Name = Guid.NewGuid().ToString(), Password = "фылафлыт 3215735", Description = "aadngn35" } };
        }
        else
        //foreach (var item in site.Accounts)
        {
            //site.Accounts = null;
            //item.Name = "Зашифровали";
        }
    }
    
    public void Load()
    {
        Sites.Clear();
        foreach (var item in _applicationContext.Sites)
            Sites.Add(item);

        /*Sites.Add(Site.Make<Site>(x =>
        {
            x.Name = "Google";
            x.Address = "google.com";
            x.Accounts = new List<Account> {
                    Account.Make<Account>(x => {
                        x.Name = "Google-пароль";
                        x.Data = Guid.NewGuid().ToString();
                        x.Description = "это Google";
                    }) };
        }));
        Sites.Add(Site.Make<Site>(x =>
        {
            x.Name = "Yandex";
            x.Address = "yandex.ru";
            x.Accounts = new List<Account> {
                    Account.Make<Account>(x => {
                        x.Name = "Yandex-пароль";
                        x.Data = Guid.NewGuid().ToString();
                        x.Description = "это Yandex";
                    }) };
        }));
        Sites.Add(Site.Make<Site>(x =>
        {
            x.Name = "Vk";
            x.Address = "vk.ru";
            x.Accounts = new List<Account> {
                    Account.Make<Account>(x => {
                        x.Name = "VK-пароль";
                        x.Data = Guid.NewGuid().ToString();
                        x.Description = "это VK";
                    })
                };
        }));
        Sites.Add(Site.Make<Site>(x =>
        {
            x.Name = "Mail";
            x.Address = "mail.ru";
            x.Accounts = new List<Account> {
                    Account.Make<Account>(x => {
                        x.Name = "Mail-пароль";
                        x.Data = Guid.NewGuid().ToString();
                        x.Description = "это mail";
                    })
                };
        }));*/
    }

    [RelayCommand]
    public async Task ClipBoard(string text) =>
        await Clipboard.Default.SetTextAsync(text);

    [RelayCommand]
    public async Task Add() =>
        await Shell.Current.GoToAsync($"//{nameof(SiteEditPage)}");
}