namespace Bookify.Application.Common.Model
{
    public class SuccessResponse
    {
        public bool IsSuccess { get; init; }

        public SuccessResponse(bool isSuccess)
        {
            IsSuccess = isSuccess;
        }

        public SuccessResponse()
        {
            
        }
    }
}
