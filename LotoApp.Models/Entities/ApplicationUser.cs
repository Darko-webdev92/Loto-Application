using Microsoft.AspNetCore.Identity;

namespace LotoApp.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Navigation properties
        public List<Ticket> Ticket { get; set; }
    }
}
