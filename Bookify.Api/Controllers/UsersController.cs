using Bookify.Api.Common;
using Bookify.Application.Users.User;
using Bookify.Domain.Common.Model;
using Bookify.Domain.Persistence.Users;
using Bookify.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Bookify.Api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAll(
            [FromServices] IUserUnitOfWork unitOfWork)
        {
            var requestHandler = new GetAllUsersRequestHandler(unitOfWork);
            var result = await requestHandler.ProcessAuthorizedRequestAsync(new GetAllRequest());
            return result.ToActionResult(this);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(
            [FromServices] IUserUnitOfWork unitOfWork,
            [FromRoute] int id)
        {
            var requestHandler = new GetUserRequestHandler(unitOfWork);
            var result = await requestHandler.ProcessAuthorizedRequestAsync(new GetByIdRequest(id));
            return result.ToActionResult(this);
        }

        [HttpPost]
        public async Task<ActionResult> Post(
            [FromServices] IUserUnitOfWork unitOfWork,
            [FromBody] CreateUserRequest request)
        {
            var requestHandler = new CreateUserRequestHandler(unitOfWork);
            var result = await requestHandler.ProcessAuthorizedRequestAsync(request);
            return result.ToActionResult(this);
        }
    }
}
