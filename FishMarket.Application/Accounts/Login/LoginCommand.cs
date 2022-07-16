using FishMarket.Application.Configuration.Commands;

namespace FishMarket.Application.Accounts.Login;

public class LoginCommand : ICommand<bool>
{
    public string Username { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }

}
