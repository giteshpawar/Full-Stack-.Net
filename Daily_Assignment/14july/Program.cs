using System;

namespace StationeryStoreManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LoginService loginService = new LoginService();

            try
            {
                loginService.Login();

                StationeryManager manager = new StationeryManager();

                bool exit = false;

                while (!exit)
                {
                    Console.Clear();

                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("Stationery Store Management System");
                    Console.WriteLine("------------------------------------");
                    Console.WriteLine("1. Add Stationery Item");
                    Console.WriteLine("2. Display All Items");
                    Console.WriteLine("3. Search Item");
                    Console.WriteLine("4. Update Item");
                    Console.WriteLine("5. Delete Item");
                    Console.WriteLine("6. Purchase Item");
                    Console.WriteLine("7. View Low Stock Items");
                    Console.WriteLine("8. Sort Items");
                    Console.WriteLine("9. Exit");
                    Console.Write("\nEnter Choice: ");

                    int choice;

                    if (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine("Invalid Choice.");
                        Console.ReadKey();
                        continue;
                    }

                    try
                    {
                        switch (choice)
                        {
                            case 1:
                                manager.AddItem();
                                break;

                            case 2:
                                manager.DisplayAllItems();
                                break;

                            case 3:
                                manager.SearchItem();
                                break;

                            case 4:
                                manager.UpdateItem();
                                break;

                            case 5:
                                manager.DeleteItem();
                                break;

                            case 6:
                                manager.PurchaseItem();
                                break;

                            case 7:
                                manager.ViewLowStockItems();
                                break;

                            case 8:
                                manager.SortItems();
                                break;

                            case 9:
                                exit = true;
                                Console.WriteLine();
                                Console.WriteLine("Thank You");
                                Console.WriteLine("Visit Again");
                                break;

                            default:
                                Console.WriteLine("Invalid Choice.");
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine(ex.Message);
                    }

                    if (!exit)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                    }
                }
            }
            catch (LoginFailedException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}