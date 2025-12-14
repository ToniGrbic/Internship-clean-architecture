using Bookify.Domain.Persistence.Users;
using Bookify.Infrastructure.Database;

namespace Bookify.Infrastructure.Repositories
{
    public class UserUnitOfWork : IUserUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        public IUserRepository Repository { get; }

        public UserUnitOfWork(ApplicationDbContext dbContext, IUserRepository repository)
        {
            _dbContext = dbContext;
            Repository = repository;
        }

        public async Task CreateTransaction()
        {
            await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _dbContext.SaveChangesAsync();
            await _dbContext.Database.CommitTransactionAsync();
        }

        public async Task Rollback()
        {
            await _dbContext.Database.RollbackTransactionAsync();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
