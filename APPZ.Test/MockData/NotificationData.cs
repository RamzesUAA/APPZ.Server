using APPZ.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPZ.Test.MockData
{
    public static class NotificationData
    {
        public static IEnumerable<NotificationEntity> GetNotificationData()
        {
            return new List<NotificationEntity>()
            {
                new NotificationEntity(){Id= Guid.NewGuid(), Name = "Bohdan Hmelnickij become the president"},
                new NotificationEntity(){Id= Guid.NewGuid(), Name = "Ivan Sirko become the president"},
                new NotificationEntity(){Id= Guid.NewGuid(), Name = "Ukraine got Kherson back"}
            };
        }
    }
}
