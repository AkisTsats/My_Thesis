using System;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit;

namespace AnnouncementAPI.Mail
{
    public class MailKit
    {
        public void MailKitSender(string receiverName, string subject, string mailBody, string type, string receiverMail)
        {
            MimeMessage message = new MimeMessage();

            message.From.Add(new MailboxAddress("test", "test@test.com"));

            message.To.Add(MailboxAddress.Parse(receiverMail));

            message.Subject = subject;

            message.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {

            };


            SmtpClient client = new SmtpClient();

            try
            {
                client.Connect("smtp.gmail.com", 465, true);
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
