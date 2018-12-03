using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PlayESLRazor.Models;

namespace PlayESLRazor.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<CompTeam> CompTeam { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<Tournament> Tournament { get; set; }
    }
}
