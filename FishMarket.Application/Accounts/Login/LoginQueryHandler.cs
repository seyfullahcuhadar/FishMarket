using FishMarket.Application.Configuration.Identity;
using FishMarket.Application.Configuration.Queries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FishMarket.Application.Accounts.Login
{
    public class LoginQueryHandler : IQueryHandler<LoginQuery, bool>
    {
        private readonly IAccountService accountService;

        public LoginQueryHandler(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        async Task<bool> IRequestHandler<LoginQuery, bool>.Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var result = await accountService.LoginAsync(request.Username, request.Password, request.RememberMe);
            return result;
        }
    }
}
