
using _29july.Models;
using _29july.Services;

namespace _29july.Services
{
    public class EmployeeService : IEmployeeService
    {
        private static List<Employee> employees = new List<Employee>() {
            new Employee{ Id=101, Name="Mamta", PhoneN=789654, Email="mamta@gmail.com", DeptId=11 },
            new Employee{ Id=102, Name="Bob", PhoneN=960054, Email="bob@gmail.com", DeptId=11 },
            new Employee{ Id=103, Name="John", PhoneN=654123, Email="jo@gmail.com", DeptId=12 },
            new Employee{ Id=104, Name="Alice", PhoneN=6054123, Email="joal@gmail.com", DeptId=13 },
        };

        public List<Employee> getEmployees()
        {
            return employees;
        }

        public Employee? getEmployee(int deptid)
        {
            return employees.FirstOrDefault(e => e.DeptId == deptid);
        }

        public Employee? getEmployeeName(string Name)
        {
            return employees.FirstOrDefault(e => e.Name == Name);
        }

        public Employee addEmployee(Employee employee)
        {
            employees.Add(employee);

            return employee;
        }
    }
}