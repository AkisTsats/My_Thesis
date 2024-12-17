using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit;
using MailKit.Security;

namespace AnnouncementAPI.Mail
{
    public class MailKitWrapper
    {
        public async Task SendMail(string receiverName, string subject, string mailBody, string receiverMail)
        {
            MimeMessage message = new MimeMessage();

            message.From.Add(new MailboxAddress("CEID Announcement System", "tsatsoulis@ceid.upatras.gr"));

            message.To.Add(new MailboxAddress(receiverName, receiverMail));

            message.Subject = subject;

            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = mailBody
            };


            SmtpClient client = new SmtpClient();

            try
            {
                client.Connect("mail.ceid.upatras.gr", 587, SecureSocketOptions.StartTls);
                client.Authenticate("tsatsoulis@ceid.upatras.gr", "Th3Tr0l1;;;");
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
