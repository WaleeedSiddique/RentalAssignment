using RentalAssignment.Models;

namespace RentalAssignment.Interfaces
{
    public interface IEmployeeInterface
    {
        public Employee GetEmployee(int EmployeeId);
        public Employee CreateEmployee(Employee employee);
        public IEnumerable<Employee> GetAllEmployee();
        public Employee Update(Employee EmployeeChanges);
        public Employee Delete(int EmployeeId);
    }
}
