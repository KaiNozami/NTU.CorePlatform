
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NTU.CorePlatform.Domain.Entities.System.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace EduCore.CorePlatform.Infrastructure.Persistence.Configurations.Categories;

public class CountryConfiguration
    : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Countries");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255);
    }
}
