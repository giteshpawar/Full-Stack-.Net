//Scenario array
//A company stores the monthly sales (in ₹) of 6 employees in an array. 
//Display all sales, calculate the total sales, average sales, highest sales, and lowest sales.


using System;

namespace Practical
{
    public class Problem_1
    {
        public static void Run()
        {
            int[] sales = { 25000, 32000, 28000, 40000, 35000, 30000 };

            int total = 0;
            int highest = sales[0];
            int lowest = sales[0];

            Console.WriteLine("Monthly Sales of Employees");

            for (int i = 0; i < sales.Length; i++)
            {
                Console.WriteLine("Employee " + (i + 1) + " : ₹" + sales[i]);

                total += sales[i];

                if (sales[i] > highest)
                    highest = sales[i];

                if (sales[i] < lowest)
                    lowest = sales[i];
            }

            double average = (double)total / sales.Length;

            Console.WriteLine();
            Console.WriteLine("Total Sales   : ₹" + total);
            Console.WriteLine("Average Sales : ₹" + average);
            Console.WriteLine("Highest Sales : ₹" + highest);
            Console.WriteLine("Lowest Sales  : ₹" + lowest);
        }
    }
}