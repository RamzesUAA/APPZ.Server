using APPZ.Core.Entities;
using APPZ.Core.Interfaces;
using APPZ.Infrastructure.Services;

namespace APPZ.Infrastructure.Strategies
{
    internal class MailNotifier : INotifyOrgStrategy
    {
        public async Task SendNotification(OrganisationDetails organisationDetails, string text, CancellationToken cancellationToken)
        {
            await MailService.GetInstance.SendMail(organisationDetails.Organisation.Email, text);
        }
    }
}
