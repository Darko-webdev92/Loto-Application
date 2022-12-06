using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotoApp.InterfaceModels
{
    public class Ticket
    {
        [Range(1, 37, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Number_1 { get; set; }

        [Range(1, 37, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Number_2 { get; set; }

        [Range(1, 37, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Number_3 { get; set; }

        [Range(1, 37, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Number_4 { get; set; }

        [Range(1, 37, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Number_5 { get; set; }
        [Range(1, 37, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Number_6 { get; set; }
        [Range(1, 37, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Number_7 { get; set; }
        public DateTime TicketPurchased { get; set; } = DateTime.Now;

    }
}
