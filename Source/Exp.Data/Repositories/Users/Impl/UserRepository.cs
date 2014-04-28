using Exp.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exp.Data.Repositories.Users.Impl
{
    public class UserRepository : EFRepository<User, int>, IUserRepository
    {

        public UserRepository(IEFRepositoryContext context)
            : base(context)
        { 
        }
    }
}
