using System;
using FishMarket.Domain.Fishes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FishMarket.Infrastructure.Domain.Fishes
{
 
    public class FishEntityTypeConfiguration : IEntityTypeConfiguration<Fish>
    {
        public void Configure(EntityTypeBuilder<Fish> builder)
        {
            builder.ToTable("Fishes");
            builder.HasKey(a => a.Id);
            builder.Ignore(p => p.Image);
            builder.Property(f => f.ImagePath).HasColumnName("imagePath");
            builder.Property(f => f.Name).HasColumnName("name").HasMaxLength(200);
        }
    }
}

