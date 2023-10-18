using RentalAssignment.Models;

namespace RentalAssignment.Interfaces
{
    public interface IUserRepository
    {
        public IEnumerable<ApplicationUser> GetPendingApprovals();
        public IEnumerable<ApplicationUser> GetApprovedUsers();
        public ApplicationUser GetUserbyId(string id);
        void UpdateUser(ApplicationUser user);
        void DeleteUser(ApplicationUser user);
    }
}
