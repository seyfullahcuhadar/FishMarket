using System.Threading.Tasks;

namespace FishMarket.Application.Configuration.Identity
{
    public interface ITokenClaimsService
    {
        Task<string> GetTokenAsync(string userName);
    }


}
