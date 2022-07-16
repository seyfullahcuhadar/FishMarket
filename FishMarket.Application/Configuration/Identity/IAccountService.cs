using System.Threading.Tasks;

namespace FishMarket.Application.Configuration.Identity
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(string username, string password, bool rememberMe);
        Task<RegisterResult> RegisterAsync(string username, string password);
        public Task ConfirmEmailAsync(string email, string token);
        public Task LogoutAsync();
    }
}
