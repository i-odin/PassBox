using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PassBox.Domain.Models;
using PassBox.Infrastructure.Data;
using PassBox.Mobile.ViewModels.Base;
using PassBox.Mobile.Views;
using PassBox.Services.Cryptography;
using System.Collections.ObjectModel;

namespace PassBox.Mobile.ViewModels;

[QueryProperty(nameof(Site), nameof(Site))]
public partial class SiteEditViewModel : BaseViewModel
{
    public const string Master = "123";
    private readonly IEncryptionService _encryptionService;
    private readonly ApplicationContext _applicationContext;
    public SiteEditViewModel(ApplicationContext applicationContext, IEncryptionService encryptionService)
    {
        _encryptionService = encryptionService;
        _applicationContext = applicationContext;
        InitializeSiteAndAccount();
    }

    [ObservableProperty]
    private Site _site;

    public ObservableCollection<Account> Accounts { get; set; }

    [RelayCommand]
    public async Task Submit()
    {
        foreach (var item in Accounts)
        {
            _encryptionService.Encrypt(item, SiteEditViewModel.Master);

            if (Site.Accounts == null)
                Site.Accounts = new List<Account>();

            Site.Accounts.Add(item);
        }
        
        _applicationContext.Sites.Add(Site);

        try
        {
            await _applicationContext.SaveChangesAsync();
        }
        catch (Exception ex) { 
        }
        

        InitializeSiteAndAccount();
        await Back();
    }

    [RelayCommand]
    public async Task Back()
    {
        InitializeSiteAndAccount();
        await Shell.Current.GoToAsync(SiteViewPage.Location);
    }

    [RelayCommand]
    public void AddAccount()
    {
        Accounts.Add(Account.Make<Account>());
    }

    private void InitializeSiteAndAccount()
    {
        Site = Site.Make<Site>();
        if (Accounts == null)
            Accounts = new ObservableCollection<Account> { Account.Make<Account>() };
        else
        {
            Accounts.Clear();
            AddAccount();
        }
    }
}