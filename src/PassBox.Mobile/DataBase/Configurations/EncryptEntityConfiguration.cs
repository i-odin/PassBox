using Common.EFCore.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PassBox.Mobile.Models;

namespace PassBox.Mobile.DataBase.Configurations
{
    public class EncryptEntityConfiguration<TEntity> : EntityConfiguration<TEntity> where TEntity : EncryptEntity
    {
        public override void Configure(EntityTypeBuilder<TEntity> buider)
        {
            base.Configure(buider);
            buider.Property(o => o.Name).IsRequired();
        }
    }
}
