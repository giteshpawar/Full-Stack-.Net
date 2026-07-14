using System;

namespace StationeryStoreManagement
{
    public class LoginService
    {
        private const string Username = "admin";
        private const string Password = "admin123";

        public void Login()
        {
            int attempts = 3;

            while (attempts > 0)
            {
                Console.Clear();

                Console.Write("Enter Username: ");
                string username = Console.ReadLine();

                Console.Write("Enter Password: ");
                string password = Console.ReadLine();

                if (username == Username && password == Password)
                {
                    Console.WriteLine();
                    Console.WriteLine("Login Successful.");
                    return;
                }

                attempts--;

                if (attempts > 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Invalid Login");
                    Console.WriteLine("Attempts Left : " + attempts);
                    Console.WriteLine();
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                }
            }

            throw new LoginFailedException();
        }
    }
}