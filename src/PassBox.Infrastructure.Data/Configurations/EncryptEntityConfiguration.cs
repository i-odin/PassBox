using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PassBox.Domain.Models.Base;

namespace PassBox.Infrastructure.Data.Configurations;

public class EncryptEntityConfiguration<TEntity> : PassBoxEntityConfiguration<TEntity>
    where TEntity : EncryptEntity
{
    public override void Configure(EntityTypeBuilder<TEntity> buider)
    {
        base.Configure(buider);
        buider.Property(o => o.Data).IsRequired();
        buider.Property(o => o.EncKey).IsRequired();
        buider.Property(o => o.PrivKey).IsRequired();
        buider.Property(o => o.DataType).IsRequired();
        buider.Property(o => o.EncType).IsRequired();
        buider.Property(o => o.MasterType).IsRequired();
    }
}
