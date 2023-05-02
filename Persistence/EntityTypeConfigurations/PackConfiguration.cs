using Application.Packs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations
{
    public class PackConfiguration : IEntityTypeConfiguration<Pack>
    {
        public void Configure(EntityTypeBuilder<Pack> builder)
        {
            builder.ToTable("Pack");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(50).IsRequired();

            builder.HasOne(p => p.Owner)
                .WithMany(p => p.Packs)
                .HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(p => p.Facts)
                .WithOne(f => f.Pack);

            builder.HasMany(p => p.Professions)
                .WithOne(f => f.Pack);

            builder.HasMany(p => p.Healths)
                .WithOne(f => f.Pack);

            builder.HasMany(p => p.Hobbies)
                .WithOne(f => f.Pack);

            builder.HasMany(p => p.Disasters)
                .WithOne(f => f.Pack);

            builder.HasMany(p => p.BunkerBuffs)
                .WithOne(f => f.Pack);

            builder.HasMany(p => p.BunkerDebuffs)
                .WithOne(f => f.Pack);

            builder.HasMany(p => p.BunkerBuildings)
                .WithOne(f => f.Pack);

            builder.HasMany(p => p.Luggages)
                .WithOne(f => f.Pack);
        }
    }
}
