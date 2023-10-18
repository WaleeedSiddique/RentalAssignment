using System.ComponentModel.DataAnnotations;

namespace RentalAssignment.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        [Required]
        public int EmployeeAge { get; set; }
        public string EmployeeExperience { get; set; }
        public string EmployeeOccupation { get; set; }
        [Required]
        public string EmployeeCNIC { get; set; }
        public string EmployeeFatherName { get; set; }

    }
}
