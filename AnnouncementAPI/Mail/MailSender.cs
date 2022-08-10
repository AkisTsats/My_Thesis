using FluentEmail.Core;
using FluentEmail.Razor;
using FluentEmail.Smtp;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AnnouncementAPI.Mail
{
    public class MailSender
    {
        public async Task Sender(string receiverName, string subject ,string mailBody, string type, string receiverMail)
        {
            var mailSender = new SmtpSender(() => new SmtpClient(host: "localhost")
            {
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Port = 25
            });

            Email.DefaultSender = mailSender;
            Email.DefaultRenderer = new RazorRenderer();


            StringBuilder template = new();
            template.AppendLine(value: "Dear" + receiverName);


            var email = await Email
                .From(emailAddress:"test@test.com")
                .To(emailAddress: receiverMail)
                .Subject(subject: subject)
                .Body(mailBody)
                .UsingTemplate(template.ToString(), new { })
                .SendAsync();
        }
    }
}
