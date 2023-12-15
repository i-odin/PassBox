using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using PassBox.Domain.Models;
using PassBox.Infrastructure.Data;
using PassBox.Mobile.ViewModels.Base;
using PassBox.Mobile.Views;
using PassBox.Services;
using PassBox.Services.Cryptography;
using PassBox.Services.Dto;
using System.Collections.ObjectModel;

namespace PassBox.Mobile.ViewModels;

/*public partial class SiteViewModel : BaseViewModel
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
    public async Task GetAccounts(Guid id)
    {
        var site = Sites.FirstOrDefault(x => x.Id == id);
        if(site != null)
        {
            if (IsExpanded)
            {
                await _applicationContext.Sites.Entry(site).Collection(x => x.Accounts).LoadAsync();
                foreach (var item in site.Accounts)
                    _encryptionService.Decrypt(item, "123");   
            }
            else
            {
                foreach (var item in site.Accounts)
                    _encryptionService.Encrypt(item, "123");

                site.Accounts.Clear();
            }
        }
    }
    
    public void Load()
    {
        Sites.Clear();
        
        foreach (var item in _applicationContext.Sites.AsNoTracking())
        {
            item.Accounts = new List<Account>();
            Sites.Add(item);
        }
    }

    [RelayCommand]
    public async Task ClipBoard(string text) =>
        await Clipboard.Default.SetTextAsync(text);

    [RelayCommand]
    public async Task Add() =>
        await Shell.Current.GoToAsync($"//{nameof(SiteEditPage)}");
}*/

public partial class SiteViewModel : BaseViewModel
{
    private readonly IAccountSiteService _accountSiteService;
    public SiteViewModel(IAccountSiteService accountSiteService)
    {
        _accountSiteService = accountSiteService;
    }

    public ObservableCollection<AccountSiteDto> AccountSites { get; set; } = new ObservableCollection<AccountSiteDto>();
    public bool IsExpanded { get; set; }

    [RelayCommand]
    public async Task GetAccounts(Guid id)
    {
        var site = AccountSites.FirstOrDefault(x => x.Site.Id == id);
        if (site != null)
        {
            if (IsExpanded)
                await _accountSiteService.LoadAccountAsync(site);
            else
                site.Accounts.Clear();
        }
    }

    public void Load()
    {
        AccountSites.Clear();
        foreach (var item in _accountSiteService.GetList())
            AccountSites.Add(item);
    }

    [RelayCommand]
    public async Task ClipBoard(string text) =>
        await Clipboard.Default.SetTextAsync(text);

    [RelayCommand]
    public async Task Add() =>
        await Shell.Current.GoToAsync(SiteEditPage.Location);
}