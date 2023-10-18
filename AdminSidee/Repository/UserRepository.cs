using RentalAssignment.DatabaseContext;
using RentalAssignment.Interfaces;
using RentalAssignment.Models;

namespace RentalAssignment.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AddDbContext _context;

        public UserRepository(AddDbContext context)
        {
            this._context = context;
        }

        public void DeleteUser(ApplicationUser user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public IEnumerable<ApplicationUser> GetApprovedUsers()
        {
            return _context.Users.Where(u => u.IsApproved);
        }

        public IEnumerable<ApplicationUser> GetPendingApprovals()
        {
            return _context.Users.Where(u => !u.IsApproved);

        }

        public ApplicationUser GetUserbyId(string id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        public void UpdateUser(ApplicationUser user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
