using Common.EFCore;
using Microsoft.EntityFrameworkCore;
using PassBox.Domain.Models;
using PassBox.Infrastructure.Data.Configurations;

namespace PassBox.Infrastructure.Data;

public class ApplicationContext : DataBaseContext<ApplicationContext>
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        //TODO: Разобраться с первым созданием базы, прикрутить миграцию
        Database.EnsureCreated();

        //options.UseSqlite("");
    }

    public DbSet<Site> Sites { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new SiteConfiguration());
        base.OnModelCreating(builder);
    }
}