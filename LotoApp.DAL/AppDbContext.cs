using LotoApp.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LotoApp.DAL
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Draw> Draws { get; set; }
        public DbSet<Winner> Winners { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            Seed seed = new Seed();
            seed.SeedData(builder);

        }
    }
}
