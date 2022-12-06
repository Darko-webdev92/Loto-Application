using LotoApp.DomainModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApp.DAL
{
    public class Seed
    {
        public void SeedData(ModelBuilder builder)
        {
            IdentityRole role = new IdentityRole 
            {
                Name = "Admin",
                NormalizedName = "Admin".ToUpper()
            };

            const string ADMIN_ID = "b30am3c1-hg09-bbf0-bd17-007daka4e575";
            var hasher = new PasswordHasher<ApplicationUserDto>();
            var user = new ApplicationUserDto()
            {
                Id = ADMIN_ID,
                FirstName = "Admin",
                LastName = "Angelovski",
                Email = "admin@example.com",
                //RoleId = "3",
                UserName = "admin@example.com",
                NormalizedUserName = "admin@example.com",
                NormalizedEmail = "admin@example.com",
                PasswordHash = hasher.HashPassword(null, "Admin123!"),
                SecurityStamp = string.Empty,
                EmailConfirmed = true,
            };

            IdentityUserRole<string> userRole = new IdentityUserRole<string>()
            {
               UserId = ADMIN_ID,
               RoleId = role.Id,
            };

            builder.Entity<IdentityRole>().HasData(role);
            builder.Entity<ApplicationUserDto>().HasData(user);
            builder.Entity<IdentityUserRole<string>>().HasData(userRole);



        }
    }
}
