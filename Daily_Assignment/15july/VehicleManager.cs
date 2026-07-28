using System;
using System.Collections.Generic;
using System.Linq;

namespace AutomobileVehicleManagementSystem
{
    public class VehicleManager
    {
        private List<Vehicle> vehicles = new List<Vehicle>();

        public void AddVehicle()
        {
            Console.Write("Vehicle ID : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Vehicle Name : ");
            string name = Console.ReadLine();

            Console.Write("Vehicle Type : ");
            string type = Console.ReadLine();

            Console.Write("Brand : ");
            string brand = Console.ReadLine();

            Console.Write("Price : ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Manufacturing Year : ");
            int year = Convert.ToInt32(Console.ReadLine());

            vehicles.Add(new Vehicle(id, name, type, brand, price, year));

            Console.WriteLine("Vehicle added successfully.");
        }

        public void ViewVehicles()
        {
            if (vehicles.Count == 0)
            {
                Console.WriteLine("No vehicles available.");
                return;
            }

            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("ID\tName\tBrand\tType\tPrice");
            Console.WriteLine("--------------------------------------------------------------");

            foreach (var v in vehicles)
            {
                Console.WriteLine($"{v.VehicleId}\t{v.VehicleName}\t{v.Brand}\t{v.VehicleType}\t{v.Price}");
            }
        }

        public void SearchVehicle()
        {
            Console.Write("Enter Vehicle ID : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Vehicle vehicle = vehicles.FirstOrDefault(v => v.VehicleId == id);

            if (vehicle != null)
            {
                Console.WriteLine("Vehicle Found");
                Console.WriteLine("ID : " + vehicle.VehicleId);
                Console.WriteLine("Name : " + vehicle.VehicleName);
                Console.WriteLine("Brand : " + vehicle.Brand);
                Console.WriteLine("Type : " + vehicle.VehicleType);
                Console.WriteLine("Price : " + vehicle.Price);
                Console.WriteLine("Year : " + vehicle.ManufacturingYear);
            }
            else
            {
                Console.WriteLine("Vehicle not found.");
            }
        }

        public void UpdatePrice()
        {
            Console.Write("Enter Vehicle ID : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Vehicle vehicle = vehicles.FirstOrDefault(v => v.VehicleId == id);

            if (vehicle != null)
            {
                Console.Write("Enter New Price : ");
                vehicle.Price = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Price updated successfully.");
            }
            else
            {
                Console.WriteLine("Vehicle ID does not exist.");
            }
        }

        public void DeleteVehicle()
        {
            Console.Write("Enter Vehicle ID : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Vehicle vehicle = vehicles.FirstOrDefault(v => v.VehicleId == id);

            if (vehicle != null)
            {
                vehicles.Remove(vehicle);
                Console.WriteLine("Vehicle deleted successfully.");
            }
            else
            {
                Console.WriteLine("Vehicle not available.");
            }
        }

        public void CalculateDiscount()
        {
            Console.Write("Enter Vehicle ID : ");
            int id = Convert.ToInt32(Console.ReadLine());

            Vehicle vehicle = vehicles.FirstOrDefault(v => v.VehicleId == id);

            if (vehicle == null)
            {
                Console.WriteLine("Vehicle not found.");
                return;
            }

            double discount = 0;

            switch (vehicle.VehicleType.ToLower())
            {
                case "car":
                    discount = vehicle.Price * 0.10;
                    break;

                case "bike":
                    discount = vehicle.Price * 0.05;
                    break;

                case "truck":
                    discount = vehicle.Price * 0.12;
                    break;

                default:
                    discount = 0;
                    break;
            }

            Console.WriteLine("Vehicle Price : " + vehicle.Price);
            Console.WriteLine("Discount : " + discount);
            Console.WriteLine("Final Price : " + (vehicle.Price - discount));
        }

        public void ShowVehicleDetails()
        {
            Console.Write("Enter Vehicle Type : ");
            string type = Console.ReadLine().ToLower();

            switch (type)
            {
                case "car":
                    Console.WriteLine("Car is a four wheeler.");
                    Console.WriteLine("Suitable for family.");
                    break;

                case "bike":
                    Console.WriteLine("Bike is fuel efficient.");
                    Console.WriteLine("Suitable for city rides.");
                    break;

                case "truck":
                    Console.WriteLine("Truck is used for transportation.");
                    Console.WriteLine("Heavy load vehicle.");
                    break;

                default:
                    Console.WriteLine("Invalid vehicle type.");
                    break;
            }
        }
    }
}