using System;
namespace FishMarket.Application.Emails
{

    public struct EmailMessage
    {

        public string To { get; }

        public string Content { get; }

        public EmailMessage(
            string to,
            string content)
        {
            this.To = to;
            this.Content = content;
        }
    }
}

