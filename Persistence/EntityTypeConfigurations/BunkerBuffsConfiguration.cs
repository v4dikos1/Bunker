using Application.BunkerBuffs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations
{
    public class BunkerBuffsConfiguration : IEntityTypeConfiguration<BunkerBuff>
    {
        public void Configure(EntityTypeBuilder<BunkerBuff> builder)
        {
            builder.ToTable("BunkerBuff");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).HasMaxLength(20).IsRequired();

            builder.HasOne(p => p.Pack)
                .WithMany(p => p.BunkerBuffs)
                .HasForeignKey(p => p.PackId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
