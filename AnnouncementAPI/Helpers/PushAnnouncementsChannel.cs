using DTOs.Data;
using System;
using AnnouncementAPI.Helpers;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AnnouncementAPI.Helpers
{
    public class ProducerOfMyObjectsEndpoint
    {
        private Channel<AnnouncementDTO> _AnnouncementChannel;
        public ProducerOfMyObjectsEndpoint(Channel<AnnouncementDTO> announcementChannel)
        {
            _AnnouncementChannel = announcementChannel;
        }

        public async Task myEndpoint(AnnouncementDTO ann)
        {
            await _AnnouncementChannel.Writer.WriteAsync(ann);
        }
    }

    public class ConsumerSingletonProcessorSendEmail : BackgroundService
    {
        private Channel<AnnouncementDTO> _AnnouncementChannel;
        private IServiceProvider services;
        private Mail.MailKit MailKit;
        public ConsumerSingletonProcessorSendEmail(Channel<AnnouncementDTO> announcementChannel, IServiceProvider services)
        {
            _AnnouncementChannel = announcementChannel;
            MailKit = new Mail.MailKit();
            this.services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("i am inside");
            await Task.Yield();
            
            while (true)
            {
                try
                {
                    Console.WriteLine($"Consumer just processed a new announcement");
                    var announcement = await _AnnouncementChannel.Reader.ReadAsync(stoppingToken);

                    using var scope = services.CreateScope(); //create a scope to get scoped services from
                    var fetchMailsToUse = scope.ServiceProvider.GetRequiredService<SendAnnouncement>(); //this has to be a scoped service because it depends on db context
                    
                    var mailSent = await fetchMailsToUse.SendToMail(announcement);
                    var receiverName = "John Doe";
                    var subject = "Subject";
                    var mailBody = "HTML Mail Body";
                    var type = "Your Type";
                    var receiverMail = " mohamed.bednar82@ethereal.email ";


                    await MailKit.MailKitSender(receiverName, subject, mailBody, type, receiverMail);

                    Console.WriteLine($"Consumer just processed a new announcement");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Exception{ex.Message}");
                }
            }
        }
    }
}
