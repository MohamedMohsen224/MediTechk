using Core.Models.Identity;
using Microsoft.Extensions.Options;
using MimeKit;

namespace MediTech.Helper
{
    public class EmailSettings : IMailSetting
    {
        private MailSetting options;

        public EmailSettings(IOptions<MailSetting> options)
        {
            this.options = options.Value;
        }
        public void SendEmail(Email email)
        {
            var Email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(options.Email),
                Subject = email.subject
            };

            Email.To.Add(MailboxAddress.Parse(email.to));

            var builder = new BodyBuilder();
            builder.HtmlBody = email.body;
            Email.Body = builder.ToMessageBody();
            Email.From.Add(new MailboxAddress(options.DisplayName, options.Email));

           
            //
            using var client = new MailKit.Net.Smtp.SmtpClient();
            client.Connect(options.Host, options.Port, MailKit.Security.SecureSocketOptions.StartTls);
            client.Authenticate(options.Email, options.Password);
            client.Send(Email);
            client.Disconnect(true);
           

        }
    }
}
