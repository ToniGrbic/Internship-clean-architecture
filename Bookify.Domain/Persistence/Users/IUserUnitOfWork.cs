using Bookify.Domain.Persistence.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookify.Domain.Persistence.Users
{
    public interface IUserUnitOfWork : IUnitOfWork
    {
        IUserRepository Repository { get; }
    }
}
