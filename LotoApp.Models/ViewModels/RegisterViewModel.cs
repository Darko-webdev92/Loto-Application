using System.ComponentModel.DataAnnotations;

namespace LotoApp.InterfaceModels
{
    public class RegisterViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string Password { get; set; }

        [Required]
        [StringLength(30, MinimumLength =5)]
        public string ConfirmPassword { get; set; }

    }
}
