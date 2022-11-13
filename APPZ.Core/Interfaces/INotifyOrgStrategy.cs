using APPZ.Core.Entities;
using Microsoft.Extensions.Configuration;

namespace APPZ.Core.Interfaces
{
    public interface INotifyOrgStrategy
    {
        public Task SendNotification(OrganisationDetails organisationDetails, string text, CancellationToken cancellationToken);
    }
}
