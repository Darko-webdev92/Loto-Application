using System.ComponentModel.DataAnnotations;

namespace LotoApp.Models.ViewModels
{
    public class TicketViewModel
    {
        [Display(Name = "Number 1")]
        [Range(1, 37, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Number_1 { get; set; }

        [Display(Name = "Number 2")]

        [Range(1, 37, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Number_2 { get; set; }

        [Display(Name = "Number 3")]

        [Range(1, 37, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Number_3 { get; set; }
        [Display(Name = "Number 4")]
        [Range(1, 37, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Number_4 { get; set; }

        [Display(Name = "Number 5")]
        [Range(1, 37, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Number_5 { get; set; }

        [Range(1, 37, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        [Display(Name = "Number 6")]
        public int Number_6 { get; set; }

        [Display(Name = "Number 7")]
        [Range(1, 37, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Number_7 { get; set; }
    }
}
