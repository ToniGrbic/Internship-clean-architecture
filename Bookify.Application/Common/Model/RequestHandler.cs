namespace Bookify.Application.Common.Model
{
    public abstract class RequestHandler<TRequest, TResult> where TRequest : class where TResult : class
    {
        public Guid RequestId => Guid.NewGuid();

        public async Task<Result<TResult>> ProcessAuthorizedRequestAsync(TRequest request)
        {
            var result = new Result<TResult>(RequestId);

            //logiranje
            //autorizacija

            if (await IsAuthorized() == false)
            {
                result.SetUnauthorizedResult();
                return result;
            }

            await HandleRequest(request, result);

            //cacheriranje

            return result;
        }
        protected abstract Task<Result<TResult>> HandleRequest(TRequest request, Result<TResult> result);
        protected abstract Task<bool> IsAuthorized();
    }
}
