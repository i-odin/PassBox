﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PassBox.Domain.Models;

namespace PassBox.Infrastructure.Data.Configurations;

public class AccountConfiguration : EncryptEntityConfiguration<Account>
{
    public override void Configure(EntityTypeBuilder<Account> buider)
    {
        buider.ToTable(nameof(Account));

        base.Configure(buider);
        buider.Property(o => o.Description).IsRequired(false);
    }
}
