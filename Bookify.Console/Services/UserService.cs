using Bookify.Domain.Entities.Books;
using Bookify.Domain.Entities.Users;
using Bookify.Domain.Persistence.Users;

namespace Bookify.Console.Services
{
    public class UserService
    {
        private readonly IUserUnitOfWork _unitOfWork;

        public UserService(IUserUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            var result = await _unitOfWork.Repository.Get();
            return result.Values;
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            try
            {
                return await _unitOfWork.Repository.GetById(userId);
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Book>> GetUserBooksAsync(int userId)
        {
            return await _unitOfWork.Repository.GetUserBooks(userId);
        }
    }
}
