using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PassBox.Domain.Models;

namespace PassBox.Infrastructure.Data.Configurations;

public class SiteConfiguration : PassBoxEntityConfiguration<Site>
{
    public override void Configure(EntityTypeBuilder<Site> buider)
    {
        base.Configure(buider);
        buider.Property(x => x.Address).IsRequired();
        buider.HasMany(x => x.Accounts).WithMany();
    }
}