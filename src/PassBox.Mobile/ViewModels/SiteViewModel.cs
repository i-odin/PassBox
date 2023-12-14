using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using PassBox.Domain.Models;
using PassBox.Infrastructure.Data;
using PassBox.Mobile.ViewModels.Base;
using PassBox.Mobile.Views;
using PassBox.Services.Cryptography;
using System.Collections.ObjectModel;

namespace PassBox.Mobile.ViewModels;

public partial class SiteViewModel : BaseViewModel
{
    private readonly IEncryptionService _encryptionService;
    private readonly ApplicationContext _applicationContext;
    public SiteViewModel(ApplicationContext applicationContext, IEncryptionService encryptionService)
    {
        _encryptionService = encryptionService;
        _applicationContext = applicationContext;
    }

    public ObservableCollection<Site> Sites { get; set; } = new ObservableCollection<Site>();
    public bool IsExpanded { get; set; }

    [RelayCommand]
    public void GetAccounts(Guid id)
    {
        var site = Sites.FirstOrDefault(x => x.Id == id);
        if(site != null)
        {
            if (IsExpanded)
            {
                foreach (var item in site.Accounts)
                    _encryptionService.Decrypt(item, SiteEditViewModel.Master);   
            }
            else
            {
                foreach (var item in site.Accounts)
                    _encryptionService.Encrypt(item, SiteEditViewModel.Master);
            }
        }
    }
    
    public void Load()
    {
        Sites.Clear();
               
        foreach (var item in _applicationContext.Sites.Include(x => x.Accounts))
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