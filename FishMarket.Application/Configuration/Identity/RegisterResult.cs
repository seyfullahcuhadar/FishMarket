using System;
namespace FishMarket.Application.Configuration.Identity
{
    public class RegisterResult
    {
        public string ConfirmationToken { get; set; }
        public bool IsSucceed { get; set; }
    }
}

