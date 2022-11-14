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
        public readonly static UserEntity userEntity;

        static NotificationData()
        {
            userEntity = new UserEntity() { Id = Guid.NewGuid(), FirstName = "Luke", LastName = "Skywalker" };
        }

        public static IEnumerable<NotificationEntity> GetNotificationData()
        {

            return new List<NotificationEntity>()
            {
                new NotificationEntity(){Id= Guid.NewGuid(), Name = "Bohdan Hmelnickij become the president", ToUserId = userEntity.Id, User = userEntity},
                new NotificationEntity(){Id= Guid.NewGuid(), Name = "Ivan Sirko become the president", ToUserId = userEntity.Id, User = userEntity},
                new NotificationEntity(){Id= Guid.NewGuid(), Name = "Ukraine got Kherson back"}
            };
        }
    }
}
