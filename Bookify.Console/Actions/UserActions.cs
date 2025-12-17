using Bookify.Application.Common.Model;
using Bookify.Application.Users.User;

namespace Bookify.Console.Actions
{
    public class UserActions
    {
        private readonly GetAllUsersRequestHandler _getAllUsersHandler;
        private readonly GetUserRequestHandler _getUserHandler;
        private readonly GetUserBooksRequestHandler _getUserBooksHandler;

        public UserActions(
            GetAllUsersRequestHandler getAllUsersHandler,
            GetUserRequestHandler getUserHandler,
            GetUserBooksRequestHandler getUserBooksHandler)
        {
            _getAllUsersHandler = getAllUsersHandler;
            _getUserHandler = getUserHandler;
            _getUserBooksHandler = getUserBooksHandler;
        }

        public async Task<IEnumerable<UserResponse>> GetAllUsersAsync()
        {
            var result = await _getAllUsersHandler.ProcessAuthorizedRequestAsync(new GetAllRequest());

            if (result.Value == null)
                return [];

            return result.Value.Values.Select(u => new UserResponse
            {
                Id = u.Id,
                Name = u.Name
            });
        }

        public async Task<UserResponse?> GetUserByIdAsync(int userId)
        {
            var result = await _getUserHandler.ProcessAuthorizedRequestAsync(new GetByIdRequest(userId));

            if (result.Value == null)
                return null;

            return new UserResponse
            {
                Id = result.Value.Id,
                Name = result.Value.Name
            };
        }

        public async Task<IEnumerable<BookResponse>> GetUserBooksAsync(int userId)
        {
            var result = await _getUserBooksHandler.ProcessAuthorizedRequestAsync(new GetUserBooksRequest(userId));

            if (result.Value == null)
                return [];

            return result.Value.Values.Select(b => new BookResponse
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                ISBN = b.ISBN,
                PublishedDate = b.PublishedDate
            });
        }
    }
}
