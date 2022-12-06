using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApp.Models
{
    public class DrawnNumbers
    {
        public int[] Nums  { get; set; }
        public DateTime? StartSession { get; set; }
        public DateTime? EndSession { get; set; }

    }
}
