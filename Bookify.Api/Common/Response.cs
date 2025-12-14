using Bookify.Application.Common.Model;

namespace Bookify.Api.Common
{
    public class Response<TValue> where TValue : class
    {
        public IReadOnlyList<ValidationResultItem> Infos { get; init; }
        public IReadOnlyList<ValidationResultItem> Warnings { get; init; }
        public IReadOnlyList<ValidationResultItem> Errors { get; init; }

        public TValue? Value { get; private set; }
        public Guid RequestId { get; private set; }

        public Response(Result<TValue> result)
        {
            Infos = result.Infos;
            Warnings = result.Warnings;
            Errors = result.Errors;
            Value = result.Value;
            RequestId = result.RequestId;
        }
    }
}
