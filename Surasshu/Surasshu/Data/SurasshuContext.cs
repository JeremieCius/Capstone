using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Surasshu.Areas.Identity.Data;
using Surasshu.Models;

namespace Surasshu.Data
{
    public class SurasshuContext : IdentityDbContext
    {
        public SurasshuContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Warrior> Warriors { get; set; }

        public DbSet<WarriorTeam> WarriorTeams { get; set; }

        public DbSet<SurasshuUser> AspNetUsers { get; set; }

        public DbSet<Quirk> Quirks { get; set; }

        public DbSet<OwnedQuirk> OwnedQuirks { get; set; }
    }
}
