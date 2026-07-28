using System;

namespace StationeryStoreManagement
{
    public class LoginFailedException : Exception
    {
        public LoginFailedException()
            : base("Login Failed! Invalid username or password entered 3 times.")
        {
        }
    }
}