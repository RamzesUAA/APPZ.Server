using APPZ.Core.Constants;
using APPZ.Core.DTO;
using APPZ.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPZ.Test.MockData
{
    public static class RequestData
    {
        public static IEnumerable<RequestEntity> GetRequestEntities()
        {
            var user1 = new UserEntity() { Id = Guid.NewGuid(), FirstName = "Luke", LastName = "Skywalker" };
            var user2 = new UserEntity() { Id = Guid.NewGuid(), FirstName = "Darth", LastName = "Vader" };
            var user3 = new UserEntity() { Id = Guid.NewGuid(), FirstName = "Obi-Wan", LastName = "Kenobi" };

            return new List<RequestEntity>()
            {
                new RequestEntity(){Id= Guid.NewGuid(), Name = "Broken knee", DateCreated = DateTime.Parse("11/14/2022"),
                    Description = "Ukraine", Status = Status.Completed, User = user1, UserId = user1.Id },
                new RequestEntity(){Id= Guid.NewGuid(), Name = "Broken head", DateCreated = DateTime.Parse("11/14/2022"),
                    Description = "Stewjon", Status = Status.Pending, User = user2, UserId = user3.Id  },
                new RequestEntity(){Id= Guid.NewGuid(), Name = "Broken leg", DateCreated = DateTime.Parse("11/14/2022"),
                    Description = "Daiyu", Status = Status.Rejected, User =user3, UserId = user3.Id  },
            };
        }

        public static IEnumerable<APPZ.Core.DTO.RequestReadDTO> GetRequestDTOs()
        {
            return new List<APPZ.Core.DTO.RequestReadDTO>()
            {
                new RequestReadDTO(){Id= Guid.NewGuid(), Name = "Broken knee", DateCreated = DateTime.Parse("11/14/2022"), Description = "Ukraine", Status = "Completed"},
                new RequestReadDTO(){Id= Guid.NewGuid(), Name = "Broken head", DateCreated = DateTime.Parse("11/14/2022"), Description = "Stewjon", Status = "Pending"},
                new RequestReadDTO(){Id= Guid.NewGuid(), Name = "Broken leg", DateCreated = DateTime.Parse("11/14/2022"), Description = "Daiyu", Status = "Rejected" },
            };
        }
    }
}
