//Scenario list coln
//A library stores the names of available books in a List. 
//Display all books, add one new book, remove one old book, and 
//display the updated list along with the total number of books.

using System;
using System.Collections.Generic;

namespace Practical
{
    public class Problem_2
    {
        public static void Run()
        {
            List<string> books = new List<string>()
            {
                "C# Programming",
                "Java Basics",
                "Python Guide",
                "Data Structures",
                "Operating System"
            };

            Console.WriteLine("Available Books");

            foreach (string book in books)
            {
                Console.WriteLine(book);
            }

            books.Add("ASP.NET Core");

            books.Remove("Java Basics");

            Console.WriteLine();
            Console.WriteLine("Updated Book List");

            foreach (string book in books)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine();
            Console.WriteLine("Total Books : " + books.Count);
        }
    }
}