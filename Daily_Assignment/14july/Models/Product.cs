using System;

namespace StationeryStoreManagement
{
    public abstract class Product
    {
        public abstract double CalculateDiscount(double amount);
    }
}