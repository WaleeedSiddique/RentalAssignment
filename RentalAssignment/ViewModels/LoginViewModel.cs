using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace RentalAssignment.ViewModels
{
    public class LoginViewModel
    {
        [Required]        
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
        public string? ReturnURL { get; set; } = "~/";
        public IList<AuthenticationScheme>? ExternalLogins { get; set; }
    }
}
