using System;
using System.Threading;
using System.Threading.Tasks;
using FishMarket.Application.Configuration.Commands;
using FishMarket.Application.Configuration.Identity;
using MediatR;

namespace FishMarket.Application.Accounts.Logout
{
    public class LogoutCommandHandler : ICommandHandler<LogoutCommand>
    {
        private readonly IAccountService accountService;

        public LogoutCommandHandler(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        public async Task<Unit> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            await accountService.LogoutAsync();
            return Unit.Value;
        }
    }
}

