using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace HangfireApp.Web.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail(string to, string subject, string body)
        {
            var from = _configuration.GetSection("EmailUserName").Value;
            var pass = _configuration.GetSection("EmailPassword").Value;
            var host = _configuration.GetSection("EmailHost").Value;

            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect(host, 587, SecureSocketOptions.StartTls);
            smtp.Authenticate(from, pass);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
