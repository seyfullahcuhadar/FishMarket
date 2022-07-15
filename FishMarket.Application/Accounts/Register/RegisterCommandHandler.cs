using System;
using System.Threading;
using System.Threading.Tasks;
using FishMarket.Application.Configuration.Commands;
using FishMarket.Application.Configuration.Identity;
using MediatR;

namespace FishMarket.Application.Accounts.Register
{
    public class RegisterCommandHandler : ICommandHandler<RegisterCommand>
    {
        private readonly IAccountService accountService;

        public RegisterCommandHandler(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var result = await accountService.LoginAsync(request.Username, request.Password, false);
            return Unit.Value;
        }
    }
}

