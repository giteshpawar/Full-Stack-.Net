using System;
using System.Collections.Generic;
using System.Linq;

class Task2_Program
{
    static List<Task2_Student> students = new List<Task2_Student>();
    static List<Task2_Course> courses = new List<Task2_Course>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("========== Student Management System ==========");
            Console.WriteLine("1. Student Management");
            Console.WriteLine("2. Course Management");
            Console.WriteLine("3. Register Course");
            Console.WriteLine("4. View Student Details");
            Console.WriteLine("5. Exit");
            Console.Write("Enter Choice : ");

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    StudentManagement();
                    break;

                case 2:
                    CourseManagement();
                    break;

                case 3:
                    RegisterCourse();
                    break;

                case 4:
                    DisplayStudent();
                    break;

                case 5:
                    Console.WriteLine("Application Closed");
                    return;

                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
    }

    static void StudentManagement()
    {
        Console.WriteLine();
        Console.WriteLine("1. Register Student");
        Console.WriteLine("2. View Students");
        Console.WriteLine("3. Search Student");

        Console.Write("Choice : ");
        int ch = Convert.ToInt32(Console.ReadLine());

        switch (ch)
        {
            case 1:

                Task2_Student s = new Task2_Student();

                Console.Write("Student ID : ");
                s.StudentId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Student Name : ");
                s.StudentName = Console.ReadLine();

                Console.Write("Department : ");
                s.Department = Console.ReadLine();

                Console.Write("Student Type (Regular/Scholarship/Part-Time): ");
                s.StudentType = Console.ReadLine();

                students.Add(s);

                Console.WriteLine("Student Registered Successfully.");

                break;

            case 2:

                foreach (Task2_Student st in students)
                {
                    Console.WriteLine(st.StudentId + " " + st.StudentName + " " + st.Department);
                }

                break;

            case 3:

                Console.Write("Enter Student ID : ");
                int id = Convert.ToInt32(Console.ReadLine());

                Task2_Student student = students.Find(x => x.StudentId == id);

                if (student == null)
                {
                    Console.WriteLine("Student Not Found");
                }
                else
                {
                    Console.WriteLine(student.StudentId);
                    Console.WriteLine(student.StudentName);
                    Console.WriteLine(student.Department);
                }

                break;
        }
    }

    static void CourseManagement()
    {
        Console.Write("Course ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Course Name : ");
        string name = Console.ReadLine();

        Console.Write("Credits : ");
        int credits = Convert.ToInt32(Console.ReadLine());

        Task2_Course c = new Task2_Course();

        c.CourseId = id;
        c.CourseName = name;
        c.Credits = credits;

        courses.Add(c);

        Console.WriteLine("Course Added Successfully.");

        Console.WriteLine();

        Console.WriteLine("Available Courses");

        foreach (Task2_Course course in courses)
        {
            Console.WriteLine(course.CourseId + " " + course.CourseName + " " + course.Credits);
        }
    }

    static void RegisterCourse()
    {
        Console.Write("Student ID : ");
        int sid = Convert.ToInt32(Console.ReadLine());

        Task2_Student student = students.Find(x => x.StudentId == sid);

        if (student == null)
        {
            Console.WriteLine("Student Not Found");
            return;
        }

        if (student.EnrolledCourses.Count >= 5)
        {
            Console.WriteLine("Maximum 5 Courses Allowed");
            return;
        }

        Console.Write("Course ID : ");
        int cid = Convert.ToInt32(Console.ReadLine());

        Task2_Course course = courses.Find(x => x.CourseId == cid);

        if (course == null)
        {
            Console.WriteLine("Course Not Found");
            return;
        }

        if (student.EnrolledCourses.Any(x => x.CourseId == cid))
        {
            Console.WriteLine("Course Already Registered");
            return;
        }

        student.EnrolledCourses.Add(course);

        Console.WriteLine("Course Registered Successfully");
    }

    static void DisplayStudent()
    {
        Console.Write("Student ID : ");
        int id = Convert.ToInt32(Console.ReadLine());

        Task2_Student student = students.Find(x => x.StudentId == id);

        if (student == null)
        {
            Console.WriteLine("Student Not Found");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Student Information");
        Console.WriteLine("------------------------------");

        Console.WriteLine("ID : " + student.StudentId);
        Console.WriteLine("Name : " + student.StudentName);
        Console.WriteLine("Department : " + student.Department);
        Console.WriteLine("Type : " + student.StudentType);

        int totalCredits = 0;

        Console.WriteLine();
        Console.WriteLine("Enrolled Courses");

        foreach (Task2_Course c in student.EnrolledCourses)
        {
            Console.WriteLine(c.CourseName + " (" + c.Credits + " Credits)");
            totalCredits += c.Credits;
        }

        Console.WriteLine();

        Console.WriteLine("Total Credits : " + totalCredits);

        double fee = Task2_FeeCalculator.CalculateFee(totalCredits, student.StudentType);

        Console.WriteLine("Total Fee : " + fee);
    }
}