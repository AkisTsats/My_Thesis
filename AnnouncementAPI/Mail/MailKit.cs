using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit;
using MailKit.Security;

namespace AnnouncementAPI.Mail
{
    public class MailKit
    {
        public async Task MailKitSender(string receiverName, string subject, string mailBody, string type, string receiverMail)
        {
            MimeMessage message = new MimeMessage();

            message.From.Add(new MailboxAddress("test", "test@test.com"));

            message.To.Add(MailboxAddress.Parse(receiverMail));

            message.Subject = subject;

            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = mailBody
            };


            SmtpClient client = new SmtpClient();

            try
            {
                client.Connect("smtp.ethereal.email", 587, SecureSocketOptions.StartTls);
                client.Authenticate("mohamed.bednar82@ethereal.email", "xSTCXBbj2G6U4hq4Fn");
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            };
        }
    }
}
