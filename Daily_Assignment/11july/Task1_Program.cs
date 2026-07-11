using System;
using System.Collections.Generic;
using System.Linq;

class Task1_Program
{
    static List<Task1_Student> students = new List<Task1_Student>();
    static List<Task1_Course> courses = new List<Task1_Course>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n===== Student Management System =====");
            Console.WriteLine("1. Register Student");
            Console.WriteLine("2. View Students");
            Console.WriteLine("3. Search Student");
            Console.WriteLine("4. Add Course");
            Console.WriteLine("5. View Courses");
            Console.WriteLine("6. Register Course");
            Console.WriteLine("7. Display Student Details");
            Console.WriteLine("8. Exit");

            Console.Write("Enter Choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    RegisterStudent();
                    break;
                case 2:
                    ViewStudents();
                    break;
                case 3:
                    SearchStudent();
                    break;
                case 4:
                    AddCourse();
                    break;
                case 5:
                    ViewCourses();
                    break;
                case 6:
                    RegisterCourse();
                    break;
                case 7:
                    DisplayStudent();
                    break;
                case 8:
                    return;
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    static void RegisterStudent()
    {
        Task1_Student s = new Task1_Student();

        Console.Write("Student ID: ");
        s.StudentId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Student Name: ");
        s.Name = Console.ReadLine();

        Console.Write("Department: ");
        s.Department = Console.ReadLine();

        Console.Write("Student Type (Regular/Scholarship/Part-Time): ");
        s.Type = Console.ReadLine();

        students.Add(s);

        Console.WriteLine("Student Registered Successfully.");
    }

    static void ViewStudents()
    {
        foreach (Task1_Student s in students)
        {
            Console.WriteLine($"{s.StudentId} {s.Name} {s.Department}");
        }
    }

    static void SearchStudent()
    {
        Console.Write("Enter Student ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Task1_Student s = students.Find(x => x.StudentId == id);

        if (s != null)
        {
            Console.WriteLine($"ID : {s.StudentId}");
            Console.WriteLine($"Name : {s.Name}");
            Console.WriteLine($"Department : {s.Department}");
        }
        else
        {
            Console.WriteLine("Student Not Found");
        }
    }

    static void AddCourse()
    {
        Task1_Course c = new Task1_Course();

        Console.Write("Course ID: ");
        c.CourseId = Convert.ToInt32(Console.ReadLine());

        Console.Write("Course Name: ");
        c.CourseName = Console.ReadLine();

        Console.Write("Credits: ");
        c.Credits = Convert.ToInt32(Console.ReadLine());

        courses.Add(c);

        Console.WriteLine("Course Added Successfully.");
    }

    static void ViewCourses()
    {
        foreach (Task1_Course c in courses)
        {
            Console.WriteLine($"{c.CourseId} {c.CourseName} Credits:{c.Credits}");
        }
    }

    static void RegisterCourse()
    {
        Console.Write("Student ID: ");
        int sid = Convert.ToInt32(Console.ReadLine());

        Task1_Student s = students.Find(x => x.StudentId == sid);

        if (s == null)
        {
            Console.WriteLine("Student Not Found");
            return;
        }

        if (s.Courses.Count >= 5)
        {
            Console.WriteLine("Maximum 5 courses allowed.");
            return;
        }

        Console.Write("Course ID: ");
        int cid = Convert.ToInt32(Console.ReadLine());

        Task1_Course c = courses.Find(x => x.CourseId == cid);

        if (c == null)
        {
            Console.WriteLine("Course Not Found");
            return;
        }

        if (s.Courses.Any(x => x.CourseId == cid))
        {
            Console.WriteLine("Course Already Registered.");
            return;
        }

        s.Courses.Add(c);

        Console.WriteLine("Course Registered Successfully.");
    }

    static void DisplayStudent()
    {
        Console.Write("Student ID: ");
        int id = Convert.ToInt32(Console.ReadLine());

        Task1_Student s = students.Find(x => x.StudentId == id);

        if (s == null)
        {
            Console.WriteLine("Student Not Found");
            return;
        }

        Console.WriteLine("\nStudent Details");
        Console.WriteLine("ID : " + s.StudentId);
        Console.WriteLine("Name : " + s.Name);
        Console.WriteLine("Department : " + s.Department);
        Console.WriteLine("Type : " + s.Type);

        int totalCredits = 0;

        Console.WriteLine("\nEnrolled Courses");

        foreach (Task1_Course c in s.Courses)
        {
            Console.WriteLine(c.CourseName + " (" + c.Credits + " Credits)");
            totalCredits += c.Credits;
        }

        Console.WriteLine("Total Credits : " + totalCredits);

        double fee = Task1_FeeCalculator.CalculateFee(totalCredits, s.Type);

        Console.WriteLine("Total Fee : " + fee);
    }
}