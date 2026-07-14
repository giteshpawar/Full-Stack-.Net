using System;

namespace StationeryStoreManagement
{
    public class InsufficientStockException : Exception
    {
        public InsufficientStockException()
            : base("Insufficient stock available.")
        {
        }
    }
}