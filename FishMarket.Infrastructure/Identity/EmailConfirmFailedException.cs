using System;
using FishMarket.Infrastructure.SeedWork;

namespace FishMarket.Infrastructure.Identity
{
    public class EmailConfirmFailedException : InfrastructureException
    {
        public EmailConfirmFailedException(string message) : base(message)
        {
        }
    }
}

