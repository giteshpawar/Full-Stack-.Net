
using _29july.Models;

namespace _29july.Services
{
    public interface IEmployeeService
    {
        List<Employee> getEmployees();

        Employee getEmployee(int deptid);

        Employee getEmployeeName(string Name);

        Employee addEmployee(Employee employee);
    }
}