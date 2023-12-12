using Common.EFCore.Configurations;
using PassBox.Domain.Models.Base;

namespace PassBox.Infrastructure.Data.Configurations;

public class EncryptEntityConfiguration<TEntity> : EntityConfiguration<TEntity> where TEntity : EncryptEntity
{
}
