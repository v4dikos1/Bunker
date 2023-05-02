using Application.BunkerBuffs;
using Application.BunkerBuildings;
using Application.BunkerDebuffs;
using Application.Disasters;
using Application.Facts;
using Application.Healths;
using Application.Hobbies;
using Application.Luggages;
using Application.Packs;
using Application.Pictures;
using Application.Professions;
using Application.Users;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IBunkerDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Pack> Packs { get; set; }
        DbSet<Profession> Professions { get; set; }
        DbSet<Fact> Facts { get; set; }
        DbSet<Hobby> Hobbies { get; set; }
        DbSet<Picture> Pictures { get; set; }
        DbSet<Luggage> Luggages { get; set; }
        DbSet<Health> Healths { get; set; }
        DbSet<Disaster> Disasters { get; set; }
        DbSet<BunkerBuilding> BunkerBuildings { get; set; }
        DbSet<BunkerBuff> BunkerBuffs { get; set; }
        DbSet<BunkerDebuff> BunkerDebuffs { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
