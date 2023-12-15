using Microsoft.EntityFrameworkCore;
using PassBox.Domain.Models;
using PassBox.Infrastructure.Data;
using PassBox.Services.Cryptography;
using PassBox.Services.Dto;

namespace PassBox.Services;

public interface IAccountSiteService
{
    Task CreateAsync(AccountSiteDto dto);
    Task LoadAccountAsync(AccountSiteDto dto);
    IEnumerable<AccountSiteDto> GetList();
}

public class AccountSiteService : IAccountSiteService
{
    private const string Master = "123";
    private readonly IEncryptionService _encryptionService;
    private readonly ApplicationContext _applicationContext;
    public AccountSiteService(ApplicationContext applicationContext, IEncryptionService encryptionService)
    {
        _encryptionService = encryptionService;
        _applicationContext = applicationContext;
    }

    public Task CreateAsync(AccountSiteDto dto)
    {
        var site = Site.Make<Site>(dto.Site);
        foreach (var item in dto.Accounts)
        {
            var account = Account.Make<Account>(item);
            _encryptionService.Encrypt(account, Master);
            site.Accounts.Add(account);
        }

        _applicationContext.Sites.Add(site);
        return _applicationContext.SaveChangesAsync();
    }

    public IEnumerable<AccountSiteDto> GetList()
    {
        foreach (var item in _applicationContext.Sites.AsNoTracking().Select(x => (AccountSiteDto)x))
            yield return item;
    }

    public async Task LoadAccountAsync(AccountSiteDto dto)
    {
        var site = (Site)dto.Site;
        await _applicationContext.Sites.Entry(site).Collection(x => x.Accounts).LoadAsync();
        foreach (var item in site.Accounts)
        {
            _encryptionService.Decrypt(item, "123");
            dto.Accounts.Add(item);
        }
    }
}