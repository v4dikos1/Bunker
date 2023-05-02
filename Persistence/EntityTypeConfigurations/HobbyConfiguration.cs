using Application.Hobbies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations
{
    public class HobbyConfiguration : IEntityTypeConfiguration<Hobby>
    {
        public void Configure(EntityTypeBuilder<Hobby> builder)
        {
            builder.ToTable("Hobby");

            builder.HasKey(x => x.Id);

            builder.Property(p => p.Name).HasMaxLength(20).IsRequired();

            builder.HasOne(p => p.Pack)
                .WithMany(p => p.Hobbies)
                .HasForeignKey(p => p.PackId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
