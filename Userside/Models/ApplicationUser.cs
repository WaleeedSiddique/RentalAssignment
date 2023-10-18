using Microsoft.AspNetCore.Identity;

namespace RentalAssignment.Models
{
    public class ApplicationUser :IdentityUser
    {      
        public bool IsApproved { get; set; }
    }
}
