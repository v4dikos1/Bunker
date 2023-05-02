using Application.BunkerBuildings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations
{
    public class BunkerBuildingsConfiguration : IEntityTypeConfiguration<BunkerBuilding>
    {
        public void Configure(EntityTypeBuilder<BunkerBuilding> builder)
        {
            builder.ToTable("BunkerBuilding");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).HasMaxLength(20).IsRequired();

            builder.HasOne(p => p.Pack)
                .WithMany(p => p.BunkerBuildings)
                .HasForeignKey(p => p.PackId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
