using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApp.DomainModels
{
    public class ApplicationUserDto : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }



        // Navigation properties
        public List<TicketDto> Ticket { get; set; }
    }
}
