using System;
using FishMarket.Application.Configuration.Commands;

namespace FishMarket.Application.Accounts.ConfirmEmail
{
    public class ConfirmEmailCommand:ICommand
    {
        public string EmailAddress { get; set; }
        public string Token { get; set; }
    }
}

