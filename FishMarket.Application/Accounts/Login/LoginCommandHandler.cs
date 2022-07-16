using FishMarket.Application.Configuration.Commands;
using FishMarket.Application.Configuration.Identity;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FishMarket.Application.Accounts.Login
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand, bool>
    {
        private readonly IAccountService accountService;

        public LoginCommandHandler(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        async Task<bool> IRequestHandler<LoginCommand, bool>.Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var result = await accountService.LoginAsync(request.Username, request.Password, request.RememberMe);
            return result;
        }
    }
}
