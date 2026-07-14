using System;

namespace StationeryStoreManagement
{
    public class Marker : StationeryItem
    {
        public bool Permanent { get; set; }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine("Permanent : " + (Permanent ? "Yes" : "No"));
        }

        public override double CalculateDiscount(double amount)
        {
            return amount * 0.08;
        }
    }
}