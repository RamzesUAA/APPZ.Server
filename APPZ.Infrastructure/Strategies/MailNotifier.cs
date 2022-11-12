using APPZ.Core.Entities;
using APPZ.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace APPZ.Infrastructure.Strategies
{
    internal class MailNotifier : INotifyOrgStrategy
    {
        public async Task SendNotification(OrganisationDetails organisationDetails, string text, IConfiguration configuration, CancellationToken cancellationToken)
        {
            var smtpClient = new SmtpClient(configuration["Smtp:Host"])
            {
                Port = int.Parse(configuration["Smtp:Port"]),
                Credentials = new NetworkCredential(configuration["Smtp:Username"], configuration["Smtp:Password"]),
                EnableSsl = true,
            };
            //sendAsync requires some token, hz karoche
            await Task.Run(() => smtpClient.Send(new MailMessage(configuration["Smtp:Username"], organisationDetails.Organisation.Email, "Notification", text)));
        }
    }
}
