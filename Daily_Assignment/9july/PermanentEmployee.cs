using System;

class PermanentEmployee : Employee
{
    public PermanentEmployee(int employeeId, string name, string department)
        : base(employeeId, name, department)
    {
        SetLeaveBalance();
    }

    public override void SetLeaveBalance()
    {
        LeaveBalance = 24;
    }
}