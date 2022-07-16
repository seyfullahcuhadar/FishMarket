using System;
namespace FishMarket.Application.Accounts.Register
{
    public class FailedRegistrationException : Exception
    {
        public FailedRegistrationException(string username) : base($"Username:{username} registration is failed")
        {
         
        }
    }

}

