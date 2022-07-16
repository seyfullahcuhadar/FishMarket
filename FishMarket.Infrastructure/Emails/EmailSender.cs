using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using FishMarket.Application.Emails;
using Mailjet.Client;
using Mailjet.Client.Resources;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

namespace FishMarket.Infrastructure.Emails
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailSettings emailSettings;

        public EmailSender(IOptions<EmailSettings> options)
        {
            this.emailSettings = options.Value;
        }
        public  void SendEmail(EmailMessage emailMessage)
        {
            
            var smtpClient = new SmtpClient(emailSettings.Host)
            {
                EnableSsl = true,
                Port = 587,
                Credentials = new NetworkCredential(emailSettings.EmailAddress, emailSettings.Password)
            };

            var message =  new MailMessage(){
                Body = emailMessage.Content,
                From = new MailAddress(emailSettings.EmailAddress), 
            };
            message.To.Add(emailMessage.To);

            smtpClient.Send(message);      
        }
    }
}

