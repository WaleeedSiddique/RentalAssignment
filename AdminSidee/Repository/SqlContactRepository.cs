using RentalAssignment.DatabaseContext;
using RentalAssignment.Interfaces;
using RentalAssignment.Models;

namespace RentalAssignment.Repository
{
    public class SqlContactRepository : IContactInterface
    {
        private readonly AddDbContext _context;

        public SqlContactRepository(AddDbContext context)
        {
            this._context = context;
        }

        public Contact AddContact(Contact contact)
        {
         _context.contact.Add(contact);
            _context.SaveChanges();
            return contact;
        }
    }
}
