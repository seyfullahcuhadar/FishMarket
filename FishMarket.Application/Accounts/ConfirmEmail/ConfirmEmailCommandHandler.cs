using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using FishMarket.Application.Configuration.Commands;
using FishMarket.Application.Configuration.Identity;
using MediatR;

namespace FishMarket.Application.Accounts.ConfirmEmail
{
    public class ConfirmEmailCommandHandler:ICommandHandler<ConfirmEmailCommand>
    {
        private readonly IAccountService accountService;

        public ConfirmEmailCommandHandler(IAccountService accountService)
        {
            this.accountService = accountService;
        }

        public async Task<Unit> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            await accountService.ConfirmEmailAsync(request.EmailAddress,request.Token);
            return Unit.Value;
        }
    }
}

