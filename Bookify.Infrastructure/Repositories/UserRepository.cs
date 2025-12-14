using Bookify.Domain.Entities.Books;
using Bookify.Domain.Entities.Users;
using Bookify.Domain.Persistence.Users;
using Bookify.Infrastructure.Database;

namespace Bookify.Infrastructure.Repositories
{
    internal sealed class UserRepository : Repository<User, int>, IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IDapperManager _dapperManager;

        public UserRepository(ApplicationDbContext dbContext, IDapperManager dapperManager)
            : base(dbContext)
        {
            _dapperManager = dapperManager;
        }

        public async Task<User> GetById(int id)
        {
            var sql = 
            """
                SELECT
                    id AS Id,
                    name AS Name,
                    date_of_birth AS DateOfBirth
                FROM
                    public.users
                WHERE
                    id = @Id
            """;

            var parameters = new
            {
                Id = id
            };

            return await _dapperManager.QuerySingleAsync<User>(sql, parameters);
        }

        public async Task<IEnumerable<Book>> GetUserBooks(int userId)
        {
            var sql =
            """
                SELECT
                    id AS Id,
                    title AS Title,
                    author AS Author,
                    isbn AS ISBN,
                    published_date AS PublishedDate,
                    user_id AS UserId
                FROM
                    public.books
                WHERE
                    user_id = @UserId
            """;

            var parameters = new
            {
                UserId = userId
            };

            return await _dapperManager.QueryAsync<Book>(sql, parameters);
        }
    }
}
