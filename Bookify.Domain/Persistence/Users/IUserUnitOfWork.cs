using Bookify.Domain.Persistence.Common;

namespace Bookify.Domain.Persistence.Users
{
    public interface IUserUnitOfWork : IUnitOfWork
    {
        IUserRepository Repository { get; }
    }
}
