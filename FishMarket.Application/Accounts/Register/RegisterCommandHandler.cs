using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using FishMarket.Application.Configuration.Commands;
using FishMarket.Application.Configuration.Identity;
using FishMarket.Application.Emails;
using MediatR;

namespace FishMarket.Application.Accounts.Register
{
    public class RegisterCommandHandler : ICommandHandler<RegisterCommand>
    {
        private readonly IAccountService accountService;
        private readonly IEmailSender emailSender;

        public RegisterCommandHandler(IAccountService accountService,IEmailSender emailSender)
        {
            this.accountService = accountService;
            this.emailSender = emailSender;
        }

        public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
          var registerResult = await accountService.RegisterAsync(request.Username, request.Password);
            if (registerResult.IsSucceed)
            {
                var confirmBody = $"{request.CurrentUrl}/Account/ConfirmEmailAddress?emailAddress={request.Username}&confirmationToken={registerResult.ConfirmationToken}";
                var emailMessage = new EmailMessage(request.Username, confirmBody);
                emailSender.SendEmail(emailMessage);
                return Unit.Value;
            }
            throw new FailedRegistrationException(request.Username);
        }
    }
}

