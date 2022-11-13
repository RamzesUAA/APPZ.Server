using APPZ.Core.Entities;
using APPZ.Core.Exceptions;
using APPZ.Core.Interfaces;
using Microsoft.Extensions.Configuration;

namespace APPZ.Infrastructure.Strategies
{
    internal class SlackNotifier : INotifyOrgStrategy
    {
        public async Task SendNotification(OrganisationDetails organisationDetails, string message, CancellationToken cancellationToken)
        {
            if (organisationDetails.SlackHook == null)
                throw new HttpCodeException(System.Net.HttpStatusCode.NotFound, "CurRent organisation doesn`t provided slack hook, to send message to.");

            using (var httpClient = new HttpClient())
            {
                var httpRequest = new StringContent("{\"text\":\"" + message + "\"}");
                await httpClient.PostAsync(organisationDetails.SlackHook, httpRequest, cancellationToken);
            }
        }
    }
}
