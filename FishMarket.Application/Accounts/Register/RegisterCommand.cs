using System;
using FishMarket.Application.Configuration.Commands;

namespace FishMarket.Application.Accounts.Register;

public class RegisterCommand : ICommand
{
    public string Username { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public string CurrentUrl { get; set; }

}
