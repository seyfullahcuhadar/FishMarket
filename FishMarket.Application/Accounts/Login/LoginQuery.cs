using FishMarket.Application.Configuration.Queries;

namespace FishMarket.Application.Accounts.Login;

public class LoginQuery : IQuery<bool>
{
    public string Username { get; set; }
    public string Password { get; set; }
    public bool RememberMe { get; set; }

}
