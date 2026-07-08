using System;

class Program
{
    public static void Main(string[] args)
    {
        Student student1 = new Student
        {
            Name = "Gitesh",
            RollNumber = 49,
            Gender = 'M',
            DOB = "26032006",
            Height = 178,
            College = "SSGMCE"
        };

        student1.DisplayDetails();
    }
}