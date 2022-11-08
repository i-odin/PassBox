using Common.EFCore.Configurations;
using PassBox.Mobile.Models.Base;

namespace PassBox.Mobile.DataBase.Configurations;

public class EncryptEntityConfiguration<TEntity> : EntityConfiguration<TEntity> where TEntity : EncryptEntity
{
}
