using Application.Disasters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations
{
    public class DisasterConfiguration : IEntityTypeConfiguration<Disaster>
    {
        public void Configure(EntityTypeBuilder<Disaster> builder)
        {
            builder.ToTable("Disaster");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(100).IsRequired();

            builder.HasOne(p => p.Pack)
                .WithMany(p => p.Disasters)
                .HasForeignKey(p => p.PackId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
