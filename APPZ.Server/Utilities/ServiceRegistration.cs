using APPZ.Core.Entities;
using APPZ.Core.Interfaces;
using APPZ.Core.Profiles;
using APPZ.Core.Repository;
using APPZ.Infrastructure.Implementations;
using APPZ.Infrastructure.Services;
using AutoMapper;
using System.Diagnostics.CodeAnalysis;

namespace APPZ.Server.Utilities
{
    [ExcludeFromCodeCoverage]
    public static class ServiceRegistration
    {
        public static void AddFunctions(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IRequestService, RequestService>();
            services.AddTransient<IUserService, UserService>();
        }
        public static void AddMapper(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new RequestProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
