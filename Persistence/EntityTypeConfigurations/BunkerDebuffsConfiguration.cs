using Application.BunkerDebuffs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations
{
    public class BunkerDebuffsConfiguration : IEntityTypeConfiguration<BunkerDebuff>
    {
        public void Configure(EntityTypeBuilder<BunkerDebuff> builder)
        {
            builder.ToTable("BunkerDebuff");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).HasMaxLength(20).IsRequired();

            builder.HasOne(p => p.Pack)
                .WithMany(p => p.BunkerDebuffs)
                .HasForeignKey(p => p.PackId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
