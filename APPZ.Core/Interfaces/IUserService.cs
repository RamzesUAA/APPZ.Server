﻿using APPZ.Core.DTO;
using APPZ.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPZ.Core.Interfaces
{
    public interface IUserService
    {
        public Task<bool> Login(UserDto organisationDetails, CancellationToken cancellationToken);
    }
}