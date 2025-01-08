using LotoApp.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LotoApp.DAL
{
    internal class Seed
    {
        internal void SeedData(ModelBuilder builder)
        {
            IdentityRole role = new IdentityRole 
            {
                Name = "Admin",
                NormalizedName = "Admin".ToUpper()
            };

            IdentityRole AddUserRole = new IdentityRole
            {
                Name = "User",
                NormalizedName = "User".ToUpper()
            };

            builder.Entity<IdentityRole>().HasData(AddUserRole);

            var hasher = new PasswordHasher<ApplicationUser>();
            var user = new ApplicationUser()
            {
                FirstName = "Admin",
                LastName = "Angelovski",
                Email = "admin@example.com",
                UserName = "admin@example.com",
                NormalizedUserName = "admin@example.com",
                NormalizedEmail = "admin@example.com",
                PasswordHash = hasher.HashPassword(null, "Admin123!"),
                SecurityStamp = string.Empty,
                EmailConfirmed = true,
            };

            IdentityUserRole<string> userRole = new IdentityUserRole<string>()
            {
               UserId = user.Id,
               RoleId = role.Id,
            };

            builder.Entity<IdentityRole>().HasData(role);
            builder.Entity<ApplicationUser>().HasData(user);
            builder.Entity<IdentityUserRole<string>>().HasData(userRole);
        }
    }
}
