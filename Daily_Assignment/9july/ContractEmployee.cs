using System;

class ContractEmployee : Employee
{
    public ContractEmployee(int employeeId, string name, string department)
        : base(employeeId, name, department)
    {
        SetLeaveBalance();
    }

    public override void SetLeaveBalance()
    {
        LeaveBalance = 12;
    }
}