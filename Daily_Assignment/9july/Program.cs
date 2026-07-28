using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Task 1
        List<Employee> employees = new List<Employee>()
        {
            new PermanentEmployee(101, "Rahul", "HR"),
            new ContractEmployee(102, "Sneha", "IT"),
            new PermanentEmployee(103, "Amit", "Finance"),
            new ContractEmployee(104, "Priya", "Marketing"),
            new PermanentEmployee(105, "Karan", "Sales")
        };

        Console.WriteLine("========== Task 2 ==========");
        Console.WriteLine("Employee Details");

        foreach (Employee emp in employees)
        {
            emp.DisplayDetails();
        }

        // Task 3
        List<LeaveRequest> leaveRequests = new List<LeaveRequest>()
        {
            new LeaveRequest(1, 101, 3, "Medical"),
            new LeaveRequest(2, 103, 5, "Family Function"),
            new LeaveRequest(3, 104, 2, "Personal Work")
        };

        // Task 4
        Console.WriteLine();
        Console.WriteLine("========== Task 4 ==========");
        Console.WriteLine("Leave Requests");

        foreach (LeaveRequest leave in leaveRequests)
        {
            leave.DisplayLeave();
        }

        // Task 5
        Console.WriteLine();
        Console.WriteLine("========== Task 5 ==========");
        Console.WriteLine("Permanent Employees");

        foreach (Employee emp in employees)
        {
            if (emp is PermanentEmployee)
            {
                emp.DisplayDetails();
            }
        }

        // Task 6
        Console.WriteLine();
        Console.WriteLine("========== Task 6 ==========");
        Console.WriteLine("Employee with ID 103");

        Employee employee = employees.Find(e => e.EmployeeId == 103);

        if (employee != null)
        {
            employee.DisplayDetails();
        }
        else
        {
            Console.WriteLine("Employee Not Found");
        }

        // Task 7
        Console.WriteLine();
        Console.WriteLine("========== Task 7 ==========");
        Console.WriteLine("Total Employees : " + employees.Count);

        // Task 8
        Console.WriteLine();
        Console.WriteLine("========== Task 8 ==========");
        Console.WriteLine("Total Leave Requests : " + leaveRequests.Count);
    }
}