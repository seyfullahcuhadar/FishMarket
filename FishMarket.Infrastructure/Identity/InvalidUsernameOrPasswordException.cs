﻿using FishMarket.Infrastructure.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FishMarket.Infrastructure.Identity
{
    public class InvalidUsernameOrPasswordException : InfrastructureException
    {
        public InvalidUsernameOrPasswordException() : base($"Invalid username or password")
        {
        }

        public override string Code { get; } = "invalid_username_or_password";


          
    }
}
