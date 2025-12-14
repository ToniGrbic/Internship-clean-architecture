using System;
using System.Collections.Generic;
using System.Text;

namespace Bookify.Domain.Persistence.Common
{
    public interface IUnitOfWork
    {
        Task CreateTransaction();
        Task Commit();
        Task Rollback();
        Task SaveAsync();
    }
}
