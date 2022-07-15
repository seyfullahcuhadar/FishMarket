using System.Threading.Tasks;

namespace FishMarket.Application.Configuration.Identity
{
    public interface IAccountService
    {
        Task<bool> LoginAsync(string username, string password, bool rememberMe);
        Task RegisterAsync(string username, string password);

    }
}
