using APPZ.Core;
using APPZ.Core.Entities;
using APPZ.Core.Interfaces;
using APPZ.Core.Repository;
using APPZ.Infrastructure.Implementations;
using APPZ.Test.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace APPZ.Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGenericRepository<BaseEntity>, GenericRepository<BaseEntity>>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddDbContext<MDBContext>();
        }
    }
}
