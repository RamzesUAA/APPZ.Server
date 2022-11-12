using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APPZ.Core.Repository;
using APPZ.Core;

namespace APPZ.Test.Utilities
{
     /* 
     TODO:
     1. Units of work
     2. 
     */


    public class UnitOfWorkStub : UnitOfWork
    {
        public UnitOfWorkStub(MDBContext context) : base(context)
        {
        }

    }
}
