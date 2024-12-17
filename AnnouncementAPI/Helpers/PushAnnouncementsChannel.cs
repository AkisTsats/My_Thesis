using DTOs.Data;
using System;
using AnnouncementAPI.Helpers;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DTOs.WordpressLibrary;

namespace AnnouncementAPI.Helpers
{
    public class ChannelWrapper
    {
        private Channel<AnnouncementDTO> _AnnouncementChannel;
        public ChannelWrapper(Channel<AnnouncementDTO> announcementChannel)
        {
            _AnnouncementChannel = announcementChannel;
        }

        public async Task InformChannel(AnnouncementDTO ann)
        {
            await _AnnouncementChannel.Writer.WriteAsync(ann);
        }
    }

    public class ConsumerSingletonProcessorSendEmail : BackgroundService
    {
        private Channel<AnnouncementDTO> _AnnouncementChannel;
        private IServiceProvider services;
        private Mail.MailKitWrapper MailKit;

        public ConsumerSingletonProcessorSendEmail(Channel<AnnouncementDTO> announcementChannel, IServiceProvider services)
        {
            _AnnouncementChannel = announcementChannel;
            MailKit = new Mail.MailKitWrapper();
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
                    Console.WriteLine($"Consumer will process a new announcement");
                    var announcement = await _AnnouncementChannel.Reader.ReadAsync(stoppingToken);

                    var subject = announcement.Title;

                    var wordpressReq = new PostsFunctions.CreatePostDTO
                    {
                        title = announcement.Title,
                        content = announcement.Body,
                        status = "publish",
                        excerpt = announcement.Abstract,
                    };

                    var postsFunctions = new PostsFunctions();

                    try
                    {
                        await postsFunctions.CreatePost(wordpressReq, postsFunctions.CreateHttpClient("http://localhost", "testakis", "sngz x4fo HQRX UJOL SxR9 6XyK"));

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Exception occured with uploading to wordpress, will continue {ex.Message}, stack trace: {ex.StackTrace}");
                    }

                    var mailBody =
                        $$"""
                        Προστέθηκε ανακοίνωση που σας ενδιαφέρει!
                        Τίτλος: {{announcement.Title}}
                        Περίληψη: {{announcement.Abstract}}
                        <a href='https://localhost:7078/showannouncement/{{announcement.Id}}'>Δείτε την ανακοίνωση</a>
                        """;

                    using var scope = services.CreateScope(); //create a scope to get scoped services from
                    //var fetchMailsToUse = scope.ServiceProvider.GetRequiredService<SendAnnouncement>(); //this has to be a scoped service because it depends on db context
                    //var usersToSendTo = await fetchMailsToUse.GetUsersToInform(announcement);

                    //foreach (var user in usersToSendTo)
                    {
                        var receiverName = "Geia"; //user.FullName
                        var receiverMail = "tsatsoulis@ceid.upatras.gr"; //user.Email

                        await MailKit.SendMail(receiverName, subject, mailBody, receiverMail);
                    }

                    Console.WriteLine($"Consumer just processed a new announcement with id {announcement.Id}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception occured, will continue {ex.Message}, stack trace: {ex.StackTrace}");
                }
            }
        }
    }
}
