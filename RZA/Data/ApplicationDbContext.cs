using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RZA.Models;

namespace RZA.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<RZA.Models.Admins> Admins { get; set; } = default!;
        public DbSet<RZA.Models.Bookings> Bookings { get; set; } = default!;
        public DbSet<RZA.Models.Contact_Us> Contact_Us { get; set; } = default!;
        public DbSet<RZA.Models.Loyalty_Programs> Loyalty_Programs { get; set; } = default!;
        public DbSet<RZA.Models.Newsletters> Newsletters { get; set; } = default!;
        public DbSet<RZA.Models.Reviews> Reviews { get; set; } = default!;
        public DbSet<RZA.Models.Services> Services { get; set; } = default!;
        public DbSet<RZA.Models.Hotels> Hotels { get; set; } = default!;
    }
}
