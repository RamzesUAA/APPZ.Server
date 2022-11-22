using APPZ.Core.DTO;
using APPZ.Core.Entities;
using APPZ.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace APPZ.Infrastructure.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork _unitOfWork;
        public INotifyOrgStrategy Strategy { get; set; }
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<UserEntity> Login(UserDto organisationDetails, CancellationToken cancellationToken)
        {
            return await _unitOfWork.UserRepository.DbSet.FirstOrDefaultAsync(u => u.Email == organisationDetails.Email && u.Password == organisationDetails.Password);
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsers(CancellationToken cancellationToken)
        {
            return await _unitOfWork.UserRepository.GetAll(cancellationToken);
        }
    }
}
