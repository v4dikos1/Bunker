using Application.Professions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations
{
    public class ProfessionConfiguration : IEntityTypeConfiguration<Profession>
    {
        public void Configure(EntityTypeBuilder<Profession> builder)
        {
            builder.ToTable("Profession");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).HasMaxLength(20).IsRequired();

            builder.HasOne(p => p.Pack)
                .WithMany(p => p.Professions)
                .HasForeignKey(p => p.PackId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
