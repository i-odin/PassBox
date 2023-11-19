using Common.EFCore.Configurations;
using PassBox.Dal.Models.Base;

namespace PassBox.Dal.Configurations;

public class EncryptEntityConfiguration<TEntity> : EntityConfiguration<TEntity> where TEntity : EncryptEntity
{
}
