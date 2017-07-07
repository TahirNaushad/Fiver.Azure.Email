using Fiver.Azure.Email.Message;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Fiver.Azure.Email
{
    public class AzureEmailSender : IAzureEmailSender
    {
        private readonly AzureEmailSettings settings;

        public AzureEmailSender(AzureEmailSettings settings)
        {
            this.settings = settings;
        }

        public async Task<ResponseMessage> SendAsync(EmailMessage message)
        {
            // Message
            var msg = new SendGridMessage();
            msg.Subject = message.Subject;
            msg.From = new EmailAddress(message.From);
            msg.PlainTextContent = message.Body;
            msg.AddTos(message.To.Select(s => new EmailAddress(s)).ToList());

            if (message.CC.Count > 0)
                msg.AddCcs(message.CC.Select(s => new EmailAddress(s)).ToList());

            if (message.BCC.Count > 0)
                msg.AddBccs(message.BCC.Select(s => new EmailAddress(s)).ToList());

            if (message.Attachments.Count > 0)
                msg.AddAttachments(message.Attachments.Select(s => new Attachment
                {
                    Filename = s,
                    Content = Convert.ToBase64String(System.IO.File.ReadAllBytes(s))
                }).ToList());

            // Send
            var client = new SendGridClient(this.settings.ApiKey);
            var response = await client.SendEmailAsync(msg);

            // Return
            return new ResponseMessage(response.StatusCode.ToString());
        }
    }
}
