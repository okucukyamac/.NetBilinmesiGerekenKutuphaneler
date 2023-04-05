using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace HangFire.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;
        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task Sender(string userId, string message)
        {

            var apiKey = _configuration.GetSection("APIs")["SendGridApi"];
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("okucukyamac@gmail.com", "Example User");
            var subject = "site bilgilendirme mailidir.";
            var to = new EmailAddress("ogushan888@gmail.com", "Example User");
            //var plainTextContent = "and easy to do anywhere, even with C#";
            var htmlContent = "<strong>" + message + "</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, null, htmlContent);
            var response = await client.SendEmailAsync(msg);

        }
    }
}
