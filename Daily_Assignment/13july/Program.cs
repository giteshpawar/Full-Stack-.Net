using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingAssignment
{
    class Customer
    {
        public int CustomerId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }

    class Product
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }

    class CartItem
    {
        public Product? Product { get; set; }
        public int Quantity { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("========== CUSTOMER REGISTRATION ==========");

            Customer customer = new Customer();

            Console.Write("Enter Customer ID: ");
            customer.CustomerId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Name: ");
            customer.Name = Console.ReadLine();

            Console.Write("Enter Email: ");
            customer.Email = Console.ReadLine();

            Console.Write("Enter Password: ");
            customer.Password = Console.ReadLine();

            Console.WriteLine("\nRegistration Successful");

            Console.WriteLine("\n========== CUSTOMER LOGIN ==========");

            bool loginSuccess = false;

            for (int i = 1; i <= 3; i++)
            {
                Console.Write("Enter Email: ");
                string? email = Console.ReadLine();

                Console.Write("Enter Password: ");
                string? password = Console.ReadLine();

                if (email == customer.Email && password == customer.Password)
                {
                    loginSuccess = true;
                    Console.WriteLine($"\nWelcome {customer.Name}");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Credentials");
                }
            }

            if (!loginSuccess)
            {
                Console.WriteLine("Account Locked");
                return;
            }

            Console.WriteLine("\n========== PRODUCT ENTRY ==========");

            List<Product> products = new List<Product>();

            Console.Write("How many products do you want to add? ");
            int count = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Product p = new Product();

                Console.WriteLine($"\nEnter Details of Product {i + 1}");

                Console.Write("Enter Product ID: ");
                p.ProductId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Product Name: ");
                p.ProductName = Console.ReadLine();

                Console.Write("Enter Price: ");
                p.Price = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter Stock: ");
                p.Stock = Convert.ToInt32(Console.ReadLine());

                products.Add(p);
            }

            Console.WriteLine("\n========== PRODUCT LIST ==========");

            foreach (Product p in products)
            {
                Console.WriteLine("--------------------------------");
                Console.WriteLine("Product ID   : " + p.ProductId);
                Console.WriteLine("Product Name : " + p.ProductName);
                Console.WriteLine("Price        : " + p.Price);
                Console.WriteLine("Stock        : " + p.Stock);
            }

            Console.WriteLine("\n========== SEARCH PRODUCT ==========");

            Console.Write("Enter product name to search: ");
            string? searchName = Console.ReadLine();

            Product? searchProduct = products.Find(x => x.ProductName.Equals(searchName, StringComparison.OrdinalIgnoreCase));

            if (searchProduct != null)
            {
                Console.WriteLine("\nProduct Found");
                Console.WriteLine("Product Id   : " + searchProduct.ProductId);
                Console.WriteLine("Product Name : " + searchProduct.ProductName);
                Console.WriteLine("Price        : " + searchProduct.Price);
                Console.WriteLine("Stock        : " + searchProduct.Stock);
            }
            else
            {
                Console.WriteLine("Product Not Found");
            }

            Console.WriteLine("\n========== SHOPPING CART ==========");

            List<CartItem> cart = new List<CartItem>();

            while (true)
            {
                Console.WriteLine("\nAvailable Products");

                foreach (Product p in products)
                {
                    Console.WriteLine($"{p.ProductId} - {p.ProductName} - Price:{p.Price} - Stock:{p.Stock}");
                }

                Console.Write("\nEnter Product ID: ");
                int pid = Convert.ToInt32(Console.ReadLine());

                Product? selected = products.Find(x => x.ProductId == pid);

                if (selected == null)
                {
                    Console.WriteLine("Invalid Product ID");
                }
                else
                {
                    Console.Write("Enter Quantity: ");
                    int qty = Convert.ToInt32(Console.ReadLine());

                    if (qty <= selected.Stock)
                    {
                        selected.Stock -= qty;

                        CartItem? item = cart.Find(x => x.Product.ProductId == pid);

                        if (item == null)
                        {
                            cart.Add(new CartItem
                            {
                                Product = selected,
                                Quantity = qty
                            });
                        }
                        else
                        {
                            item.Quantity += qty;
                        }

                        Console.WriteLine("Product Added To Cart");
                    }
                    else
                    {
                        Console.WriteLine("Stock Not Available");
                    }
                }

                Console.WriteLine("\nDo you want to add another product?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");

                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 2)
                    break;
            }

            Console.WriteLine("\n========== CART ==========");

            double total = 0;

            foreach (CartItem item in cart)
            {
                Console.WriteLine($"{item.Product.ProductName} x{item.Quantity}");
                total += item.Product.Price * item.Quantity;
            }

            double discount = 0;

            if (total >= 1000 && total <= 4999)
            {
                discount = total * 0.10;
            }
            else if (total >= 5000 && total <= 9999)
            {
                discount = total * 0.20;
            }
            else if (total >= 10000)
            {
                discount = total * 0.30;
            }

            double finalAmount = total - discount;

            Console.WriteLine("\n========== BILL ==========");
            Console.WriteLine("Total Amount : " + total);
            Console.WriteLine("Discount     : " + discount);
            Console.WriteLine("Final Amount : " + finalAmount);

            Console.WriteLine("\n========== PAYMENT ==========");

            Console.WriteLine("1. UPI");
            Console.WriteLine("2. Credit Card");
            Console.WriteLine("3. Debit Card");
            Console.WriteLine("4. Cash on Delivery");

            Console.Write("Choose Payment: ");
            int payment = Convert.ToInt32(Console.ReadLine());

            switch (payment)
            {
                case 1:
                    Console.WriteLine("Payment Successful via UPI");
                    break;

                case 2:
                    Console.WriteLine("Payment Successful via Credit Card");
                    break;

                case 3:
                    Console.WriteLine("Payment Successful via Debit Card");
                    break;

                case 4:
                    Console.WriteLine("Payment Successful via Cash on Delivery");
                    break;

                default:
                    Console.WriteLine("Invalid Option");
                    break;
            }

            Console.WriteLine("\nThank You For Shopping!");
        }
    }
}