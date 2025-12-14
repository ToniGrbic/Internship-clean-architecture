using Bookify.Application.Common.Model;
using Bookify.Domain.Common.Model;
using Bookify.Domain.Persistence.Users;

namespace Bookify.Application.Users.User
{
    public class GetAllUsersRequestHandler : RequestHandler<GetAllRequest, GetAllResponse<Domain.Entities.Users.User>>
    {
        private readonly IUserUnitOfWork _unitOfWork;
        public GetAllUsersRequestHandler(IUserUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        protected async override Task<Common.Model.Result<GetAllResponse<Domain.Entities.Users.User>>> HandleRequest(GetAllRequest request, Common.Model.Result<GetAllResponse<Domain.Entities.Users.User>> result)
        {
            var sqlResult = await _unitOfWork.Repository.Get();
            result.SetResult(sqlResult);

            return result;
        }

        protected override Task<bool> IsAuthorized()
        {
            return Task.FromResult(true);
        }
    }
}
