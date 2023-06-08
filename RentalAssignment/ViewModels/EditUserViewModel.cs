﻿using System.ComponentModel.DataAnnotations;

namespace RentalAssignment.ViewModels
{
    public class EditUserViewModel
    {    

        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
