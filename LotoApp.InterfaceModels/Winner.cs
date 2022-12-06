using LotoApp.InterfaceModels.Enums;
using LotoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApp.InterfaceModels
{
    public class Winner : TicketNumbers
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Prize Prize { get; set; }
        public int SessionId { get; set; }

    }
}
