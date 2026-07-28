using System;

namespace AutomobileVehicleManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Employee Name : ");
            string employeeName = Console.ReadLine();

            Console.Write("Enter Employee ID : ");
            string employeeId = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Welcome " + employeeName);

            VehicleManager manager = new VehicleManager();

            int choice;

            do
            {
                Console.WriteLine();
                Console.WriteLine("==============================");
                Console.WriteLine("*****---Gitesh MOTORS---*****");
                Console.WriteLine("Vehicle Management System");
                Console.WriteLine("==============================");
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. View All Vehicles");
                Console.WriteLine("3. Search Vehicle");
                Console.WriteLine("4. Update Vehicle Price");
                Console.WriteLine("5. Delete Vehicle");
                Console.WriteLine("6. Calculate Discount");
                Console.WriteLine("7. Show Vehicle Details");
                Console.WriteLine("8. Exit");
                Console.Write("Enter your choice : ");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        manager.AddVehicle();
                        break;

                    case 2:
                        manager.ViewVehicles();
                        break;

                    case 3:
                        manager.SearchVehicle();
                        break;

                    case 4:
                        manager.UpdatePrice();
                        break;

                    case 5:
                        manager.DeleteVehicle();
                        break;

                    case 6:
                        manager.CalculateDiscount();
                        break;

                    case 7:
                        manager.ShowVehicleDetails();
                        break;

                    case 8:
                        Console.WriteLine("Thank you for using ABC Motors System.");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            } while (choice != 8);
        }
    }
}