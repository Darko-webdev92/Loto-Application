using LotoApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApp.DomainModels
{
    // author biography
    public class Draw : TicketNumbers
    {
        [Key]
        public int Id { get; set; }
        public DateTime? StartSession { get; set; }
        public DateTime? EndSession { get; set; }
        public bool IsSessionActive { get; set; }


    }
}
