using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace MassageStudio.MVC.Areas.Identity.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly  IConfiguration rootConfiguration;

        public EmailSender(IConfiguration configuration)
        {
            this.rootConfiguration = configuration;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var hostEmail = rootConfiguration["EmailSender:Email"];
            var hostPassword = rootConfiguration["EmailSender:Password"];
            var server = rootConfiguration["EmailSender:OutgoingServer"];
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(hostEmail);
                mail.To.Add(email);
                mail.Subject = subject;
                mail.Body = htmlMessage;
                mail.IsBodyHtml = true;

                using (SmtpClient smtp = new SmtpClient(server, 587))
                {
                    smtp.Credentials = new NetworkCredential(hostEmail, hostPassword);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
            return Task.CompletedTask;
        }
    }
}
