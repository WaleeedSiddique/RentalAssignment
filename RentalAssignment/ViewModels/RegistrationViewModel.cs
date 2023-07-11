using LibGit2Sharp;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace RentalAssignment.ViewModels
{
    public class RegistrationViewModel
    {
       
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [Remote(action:"IsEmailInUse",controller:"Account")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password",ErrorMessage = "Credential Did not match")]
        public string Confirmpassword { get; set; }
    }
}
