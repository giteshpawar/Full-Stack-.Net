using System;

namespace StationeryStoreManagement
{
    public class DuplicateItemException : Exception
    {
        public DuplicateItemException()
            : base("Item ID already exists.")
        {
        }
    }
}