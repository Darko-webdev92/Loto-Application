using LotoApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApp.DomainModels
{
    public class WinnerDto : TicketNumbers
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Prize { get; set; }

        public int SessionId { get; set; }

    }
}
