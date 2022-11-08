using Common.EFCore;
using Microsoft.EntityFrameworkCore;
using PassBox.Mobile.DataBase.Configurations;
using PassBox.Mobile.Models;

namespace PassBox.Mobile.DataBase;;

public class ApplicationContext : DataBaseContext<ApplicationContext>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {
        //TODO: Разобраться с первым созданием базы, прикрутить миграцию
        Database.EnsureCreated();
    }

    public DbSet<PasswordInfo> PasswordInfos { get; set; }
    //public DbSet<Site> Sites { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new PasswordInfoConfiguration());
        base.OnModelCreating(builder);
    }
}
