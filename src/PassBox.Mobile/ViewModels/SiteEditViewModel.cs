using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PassBox.Mobile.ViewModels.Base;
using PassBox.Mobile.Views;
using PassBox.Services;
using PassBox.Services.Dto;

namespace PassBox.Mobile.ViewModels;

//[QueryProperty(nameof(Site), nameof(Site))]
public partial class SiteEditViewModel : BaseViewModel
{
    private readonly IAccountSiteService _accountSiteService;
    public SiteEditViewModel(IAccountSiteService accountSiteService)
    {
        _accountSiteService = accountSiteService; 
        EmptyAccountSite();
    }

    [ObservableProperty]
    private AccountSiteDto _accountSite;

    [RelayCommand]
    public async Task Submit()
    {
        await _accountSiteService.CreateAsync(AccountSite);
        EmptyAccountSite();
        await Back();
    }

    [RelayCommand]
    public async Task Back()
    {
        EmptyAccountSite();
        await Shell.Current.GoToAsync(SiteViewPage.Location);
    }

    [RelayCommand]
    public void AddAccount() => AccountSite.Accounts.Add(AccountDto.Empty);

    private void EmptyAccountSite() => AccountSite = AccountSiteDto.Empty;
}