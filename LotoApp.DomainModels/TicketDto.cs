using LotoApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApp.DomainModels
{
    public class TicketDto : TicketNumbers
    {
        [Key]
        public int Id { get; set; }

        public DateTime TicketPurchased { get; set; }
        public int Session { get; set; }

        //Navigation properties
        public string UserId { get; set; }
        public ApplicationUserDto User { get; set; }

    }
}
