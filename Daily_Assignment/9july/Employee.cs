using System;

abstract class Employee
{
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public int LeaveBalance { get; set; }

    public Employee(int employeeId, string name, string department)
    {
        EmployeeId = employeeId;
        Name = name;
        Department = department;
    }

    public abstract void SetLeaveBalance();

    public void DisplayDetails()
    {
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("Employee ID   : " + EmployeeId);
        Console.WriteLine("Name          : " + Name);
        Console.WriteLine("Department    : " + Department);
        Console.WriteLine("Leave Balance : " + LeaveBalance + " Days");
        Console.WriteLine("Employee Type : " + GetType().Name);
    }
}