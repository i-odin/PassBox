using PassBox.Domain.Models;

namespace PassBox.Services.Dto;

public record PassBoxEntityDto(string Name);
public record EncryptEntityDto(string Data, string Name) : PassBoxEntityDto(Name);
public record SiteDto(Guid Id, string Address,  string Name) : PassBoxEntityDto(Name)
{
    public static SiteDto Empty => new SiteDto(Guid.Empty, string.Empty, string.Empty);
     
    public static implicit operator Action<Site>(SiteDto dto) => o => { o.Id = dto.Id; o.Name = dto.Name; o.Address = dto.Address; o.Accounts = new List<Account>(); };
    public static implicit operator Site(SiteDto dto) => new Site { Id = dto.Id, Name = dto.Name, Address = dto.Address };
}
public record AccountDto(string Description, string Data, string Name) : EncryptEntityDto(Data, Name)
{
    public static AccountDto Empty => new AccountDto(string.Empty, string.Empty, string.Empty);
    public static implicit operator Action<Account>(AccountDto dto) => o => { o.Description = dto.Description; o.Data = dto.Data; o.Name = dto.Name; };
    public static implicit operator AccountDto(Account o) => new AccountDto(o.Description, o.Data, o.Name);
}
public record AccountSiteDto(SiteDto Site, List<AccountDto> Accounts)
{
    public static AccountSiteDto Empty => new AccountSiteDto(SiteDto.Empty, new List<AccountDto> { AccountDto.Empty });
    public static implicit operator AccountSiteDto(Site o) => new AccountSiteDto(new SiteDto(o.Id, o.Address, o.Name) , new List<AccountDto>());
}