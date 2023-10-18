using System.ComponentModel.DataAnnotations;

namespace RentalAssignment.ViewModels
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }
        public string roleid { get; set; }
        [Required(ErrorMessage ="Role Name is Required")]
        public string roleName { get; set; }
        public List<string> Users { get;set; }
    }
}
