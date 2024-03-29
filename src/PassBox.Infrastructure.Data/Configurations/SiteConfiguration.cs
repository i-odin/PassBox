﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PassBox.Domain.Models;

namespace PassBox.Infrastructure.Data.Configurations;

public class SiteConfiguration : PassBoxEntityConfiguration<Site>
{
    public override void Configure(EntityTypeBuilder<Site> buider)
    {
        buider.ToTable(nameof(Site));

        base.Configure(buider);
        buider.Property(x => x.Address).IsRequired();
        buider.HasMany(x => x.Accounts).WithMany();
    }
}