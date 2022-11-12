using APPZ.Core.Entities;
using APPZ.Core.Interfaces;
using APPZ.Core.Repository;
using APPZ.Infrastructure.Implementations;
using System.Diagnostics.CodeAnalysis;

namespace APPZ.Server.Utilities
{
    [ExcludeFromCodeCoverage]
    public static class ServiceRegistration
    {
        public static void AddFunctions(this IServiceCollection services)
        {
            services.AddSingleton<IGenericRepository<BaseEntity>, GenericRepository<BaseEntity>>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<INotificationService, NotificationService>();
        }
    }
}
