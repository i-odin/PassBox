using Common.EFCore;
using Microsoft.EntityFrameworkCore;

namespace PassBox.Dal;

public class ApplicationContext : DataBaseContext<ApplicationContext>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        //TODO: Разобраться с первым созданием базы, прикрутить миграцию
        Database.EnsureCreated();
    }

    //public DbSet<Site> Sites { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //builder.ApplyConfiguration(new PasswordInfoConfiguration());
        base.OnModelCreating(builder);
    }
}