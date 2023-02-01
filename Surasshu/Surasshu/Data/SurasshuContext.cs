using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Surasshu.Areas.Identity.Data;
using Surasshu.Models;

namespace Surasshu.Data
{
    public class SurasshuContext : DbContext
    {
        public SurasshuContext(DbContextOptions<SurasshuContext> options) : base(options)
        {
        }

        public DbSet<Warrior> Warriors { get; set; }

        public DbSet<WarriorTeam> WarriorTeams { get; set; }

        public DbSet<SurasshuUser> AspNetUsers { get; set; }

        public DbSet<IdentityUserClaim<string>> AspNetUserClaims { get; set; }

        public DbSet<IdentityUserToken<string>> UserTokens { get; set; }

        public DbSet<IdentityUserRole<string>> Roles { get; set; } 

        public DbSet<Quirk> Quirks { get; set; }

        public DbSet<OwnedQuirk> OwnedQuirks { get; set; }
    }
}
