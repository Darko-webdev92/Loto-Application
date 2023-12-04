using System.ComponentModel.DataAnnotations;

namespace LotoApp.Models.ViewModels
{
    public class TicketViewModel
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
