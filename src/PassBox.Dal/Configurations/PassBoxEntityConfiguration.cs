using Common.EFCore.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PassBox.Dal.Models.Base;

namespace PassBox.Dal.Configurations;

internal class PassBoxEntityConfiguration<TEntity> : EntityConfiguration<TEntity>
    where TEntity : PassBoxEntity
{
    public override void Configure(EntityTypeBuilder<TEntity> buider)
    {
        base.Configure(buider);
        buider.Property(o => o.Name).IsRequired();
    }
}