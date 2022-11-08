using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PassBox.Mobile.Models;

namespace PassBox.Mobile.DataBase.Configurations;

public class PasswordInfoConfiguration : EncryptEntityConfiguration<PasswordInfo>
{
    public override void Configure(EntityTypeBuilder<PasswordInfo> buider)
    {
        base.Configure(buider);
        buider.Property(o => o.Data).IsRequired();
    }
}