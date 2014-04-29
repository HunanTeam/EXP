using Exp.Core.Data;
using Exp.Core.Domain.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exp.Data.Repositories.Users
{
    public partial interface IUserRepository : IRepository<User,int>
    {
    }
}
