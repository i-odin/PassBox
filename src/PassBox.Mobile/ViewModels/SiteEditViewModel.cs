using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PassBox.Dal.Models;
using PassBox.Mobile.ViewModels.Base;
using PassBox.Mobile.Views;
using System.Collections.ObjectModel;

namespace PassBox.Mobile.ViewModels;

[QueryProperty(nameof(Site), nameof(Site))]
public partial class SiteEditViewModel : BaseViewModel
{
    public SiteEditViewModel()
    {
        InitializeSiteAndAccount();
    }

    [ObservableProperty]
    private Site _site;

    public ObservableCollection<SiteAccount> SiteAccounts { get; set; }

    [RelayCommand]
    public async Task Submit()
    {
        var qwe = Site;
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
        SiteAccounts.Add(SiteAccount.Make<SiteAccount>());
    }

    private void InitializeSiteAndAccount()
    {
        Site = Site.Make<Site>();
        if (SiteAccounts == null)
            SiteAccounts = new ObservableCollection<SiteAccount> { SiteAccount.Make<SiteAccount>() };
        else
        {
            SiteAccounts.Clear();
            AddAccount();
        }
    }
}