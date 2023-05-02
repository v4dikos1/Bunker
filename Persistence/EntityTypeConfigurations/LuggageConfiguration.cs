using Application.Luggages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations
{
    public class LuggageConfiguration : IEntityTypeConfiguration<Luggage>
    {
        public void Configure(EntityTypeBuilder<Luggage> builder)
        {
            builder.ToTable("Luggage");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).HasMaxLength(20).IsRequired();

            builder.HasOne(p => p.Pack)
                .WithMany(p => p.Luggages)
                .HasForeignKey(p => p.PackId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
