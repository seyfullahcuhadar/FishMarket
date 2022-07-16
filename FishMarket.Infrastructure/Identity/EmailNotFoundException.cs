using System;
using FishMarket.Infrastructure.SeedWork;

namespace FishMarket.Infrastructure.Identity
{
    public class EmailNotFoundException : InfrastructureException
    {
        public EmailNotFoundException(string email) : base($"{email} Email Not Found")
        {
        }

        public override string Code { get; } = "email_not_found";
    }
}

