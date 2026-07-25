using System.Diagnostics;
using _16July_Assign.Models;
using Microsoft.AspNetCore.Mvc;

namespace _16July_Assign.Controllers
{
    public class HomeController : Controller
    {
      

        

        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>() {
            new Employee{Employee_id=111 ,Employee_name="Divyansh",Department="HR",Salary=10000,Email="divyansh@123"},
            new Employee{Employee_id=112 ,Employee_name="Aditya",Department="Accounts",Salary=25000,Email="aditya@123"},
            new Employee{Employee_id=113 ,Employee_name="Devansh",Department="Coke Oven",Salary=8000,Email="devansh@123"},
            new Employee{Employee_id=114 ,Employee_name="Abhiram",Department="QC",Salary=100000,Email="abhiram@123"},
            new Employee{Employee_id=115 ,Employee_name="Param",Department="Logistics",Salary=45000,Email="param123"},

};

            return View(employees);
           



        }
        public IActionResult Department()
        {
            List<Department> departments = new List<Department>() {
            new Department{Department_name="HR" ,Department_head="Mohan",Hcontact=9887799678,Hemail="mohan@123"},
            new Department{Department_name="Accounts" ,Department_head="Digvijay",Hcontact=9847799678,Hemail="digvijay@123"},
            new Department{Department_name="Coke Oven" ,Department_head="Rahul",Hcontact=9827799678,Hemail="rahul@123"},
            new Department{Department_name="QC" ,Department_head="Mahesh",Hcontact=9887709678,Hemail="mahesh@123"},
            new Department{Department_name="Logistics" ,Department_head="Ajay",Hcontact=9887599678,Hemail="ajay@123"},


};

            return View(departments);

        }

    }
}
