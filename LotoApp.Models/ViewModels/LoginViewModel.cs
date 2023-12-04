using System.ComponentModel.DataAnnotations;

namespace LotoApp.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string Password { get; set; }
    }
}
