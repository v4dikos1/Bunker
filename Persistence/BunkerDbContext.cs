using Application.Common.Interfaces;
using Application.Disasters;
using Application.Facts;
using Application.Healths;
using Application.Hobbies;
using Application.Luggages;
using Application.Packs;
using Application.Pictures;
using Application.Professions;
using Application.Users;
using Domain.Entities.BunkerContext;
using Microsoft.EntityFrameworkCore;
using Persistence.EntityTypeConfigurations;
using BunkerBuff = Application.BunkerBuffs.BunkerBuff;
using BunkerBuilding = Application.BunkerBuildings.BunkerBuilding;
using BunkerDebuff = Application.BunkerDebuffs.BunkerDebuff;

namespace Persistence
{
    public class BunkerDbContext : DbContext, IBunkerDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Pack> Packs { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<Fact> Facts { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Luggage> Luggages { get; set; }
        public DbSet<Health> Healths { get; set; }
        public DbSet<Disaster> Disasters { get; set; }
        public DbSet<BunkerBuilding> BunkerBuildings { get; set; }
        public DbSet<BunkerBuff> BunkerBuffs { get; set; }
        public DbSet<BunkerDebuff> BunkerDebuffs { get; set; }

        public BunkerDbContext(DbContextOptions<BunkerDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new PictureConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessionConfiguration());
            modelBuilder.ApplyConfiguration(new LuggageConfiguration());
            modelBuilder.ApplyConfiguration(new HobbyConfiguration());
            modelBuilder.ApplyConfiguration(new HealthConfiguration());
            modelBuilder.ApplyConfiguration(new DisasterConfiguration());
            modelBuilder.ApplyConfiguration(new BunkerBuildingsConfiguration());
            modelBuilder.ApplyConfiguration(new BunkerBuffsConfiguration());
            modelBuilder.ApplyConfiguration(new BunkerDebuffsConfiguration());
            modelBuilder.ApplyConfiguration(new PackConfiguration());
        }
    }
}
