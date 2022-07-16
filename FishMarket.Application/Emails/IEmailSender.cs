using System;
using System.Threading.Tasks;

namespace FishMarket.Application.Emails
{
    public interface IEmailSender
    {
        void SendEmail(EmailMessage message);
    }
}

