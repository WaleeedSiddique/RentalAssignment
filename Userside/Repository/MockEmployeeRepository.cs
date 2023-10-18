using RentalAssignment.Enums;
using RentalAssignment.Interfaces;
using RentalAssignment.Models;

namespace RentalAssignment.Repository
{
    public class MockEmployeeRepository : IEmployeeInterface
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee()  {EmployeeId =1 ,EmployeeName = "Sohail",EmployeeFatherName = "Imdaad", EmployeeAge = 20,EmployeeCNIC = "40023-53352352-2",EmployeeExperience = "2 Years",EmployeeOccupation = "Larkana"},
                new Employee()  {EmployeeId =2 ,EmployeeName = "Nadir",EmployeeFatherName = "Imdaad", EmployeeAge = 20,EmployeeCNIC = "40023-53352352-2",EmployeeExperience = "2 Years",EmployeeOccupation = "Larkana"},
                new Employee()  {EmployeeId =3 ,EmployeeName = "kishwar",EmployeeFatherName = "Imdaad", EmployeeAge = 20,EmployeeCNIC = "40023-53352352-2",EmployeeExperience = "2 Years",EmployeeOccupation = "Larkana"},
            };
        }
        public Employee CreateEmployee(Employee employee)
        {
            employee.EmployeeId = _employeeList.Max(x => x.EmployeeId) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(int EmployeeId)
        {
            var result = _employeeList.FirstOrDefault(x => x.EmployeeId == EmployeeId);
            if (result != null)
            {
                _employeeList.Remove(result);
            }
            return result;
        }

        public IEnumerable<Employee> GetAllEmployee()
        {
            return _employeeList.ToList();
        }

        public Employee GetEmployee(int EmployeeId)
        {
            Employee result = _employeeList.FirstOrDefault(x => x.EmployeeId == EmployeeId);

            return result;
        }

        public Employee Update(Employee EmployeeChanges)
        {
            Employee result = _employeeList.FirstOrDefault(x => x.EmployeeId == EmployeeChanges.EmployeeId);
            if (result != null)
            {
                result.EmployeeName = EmployeeChanges.EmployeeName;
                result.EmployeeFatherName = EmployeeChanges.EmployeeFatherName;
                result.EmployeeCNIC = EmployeeChanges.EmployeeCNIC;
                result.EmployeeOccupation = EmployeeChanges.EmployeeOccupation;
                result.EmployeeAge = EmployeeChanges.EmployeeAge;
                result.EmployeeExperience = EmployeeChanges.EmployeeExperience;
                
            }
            return result;
        }
    }
}
