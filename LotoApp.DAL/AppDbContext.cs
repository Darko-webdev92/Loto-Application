using LotoApp.DomainModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApp.DAL
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<ApplicationUserDto> Users { get; set; }

        public DbSet<TicketDto> Tickets { get; set; }
        public DbSet<Draw> Draws { get; set; }
        public DbSet<WinnerDto> Winners { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            Seed seed = new Seed();
            seed.SeedData(builder);

        }
    }
}
