using RentalAssignment.DatabaseContext;
using RentalAssignment.Interfaces;
using RentalAssignment.Models;

namespace RentalAssignment.Repository
{
    public class SqlEmployeeRepository : IEmployeeInterface
    {
        private readonly AddDbContext _context;

        public SqlEmployeeRepository(AddDbContext context)
        {
            this._context = context;
        }
        public Employee CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;

        }

        public Employee Delete(int EmployeeId)
        {
            var result = _context.Employees.Find(EmployeeId);
            if (result != null)
            {
                _context.Employees.Remove(result);
                _context.SaveChanges();
            }
            return result;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _context.Employees;
        }

        public Employee GetEmployee(int id)
        {
            var model = _context.Employees.FirstOrDefault(x => x.EmployeeId == id);
            return model;
        }

        public Employee Update(Employee EmployeeChanges)
        {
            var result = _context.Employees.Attach(EmployeeChanges);
            result.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return EmployeeChanges;
        }
    }
}
