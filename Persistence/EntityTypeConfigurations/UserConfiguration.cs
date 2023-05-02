using Application.Pictures;
using Application.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(u => u.Id).HasName("UserId");

            builder.Property(u => u.Nickname).IsRequired().HasMaxLength(20);
            builder.HasIndex(u => u.Nickname).IsUnique();

            builder.Property(u => u.Email).IsRequired();
            builder.HasIndex(u => u.Email).IsUnique();

            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.PasswordSalt).IsRequired();

            builder
                .HasOne(u => u.Picture)
                .WithOne(p => p.User)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey<Picture>(p => p.UserId);
        }
    }
}
