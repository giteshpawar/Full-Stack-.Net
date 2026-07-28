using System;

class LeaveRequest
{
    public int LeaveId { get; set; }
    public int EmployeeId { get; set; }
    public int NumberOfDays { get; set; }
    public string Reason { get; set; }

    public LeaveRequest(int leaveId, int employeeId, int numberOfDays, string reason)
    {
        LeaveId = leaveId;
        EmployeeId = employeeId;
        NumberOfDays = numberOfDays;
        Reason = reason;
    }

    public void DisplayLeave()
    {
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("Leave ID       : " + LeaveId);
        Console.WriteLine("Employee ID    : " + EmployeeId);
        Console.WriteLine("Days Requested : " + NumberOfDays);
        Console.WriteLine("Reason         : " + Reason);
    }
}