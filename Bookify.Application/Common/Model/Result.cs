using Bookify.Domain.Common.Validation;

namespace Bookify.Application.Common.Model
{
    public class Result<TValue> where TValue : class
    {
        private readonly List<ValidationResultItem> _infos = new();
        private readonly List<ValidationResultItem> _warnings = new();
        private readonly List<ValidationResultItem> _errors = new();

        public TValue? Value { get; set; } = null;
        public Guid RequestId { get; set; }
        public bool IsAuthorized { get; set; } = true;

        public IReadOnlyList<ValidationResultItem> Infos
        {
            get => _infos.AsReadOnly();
            init => _infos.AddRange(value);
        }

        public IReadOnlyList<ValidationResultItem> Errors
        {
            get => _errors.AsReadOnly();
            init => _errors.AddRange(value);
        }

        public IReadOnlyList<ValidationResultItem> Warnings
        {
            get => _warnings.AsReadOnly();
            init => _warnings.AddRange(value);
        }

        public Result(Guid requestId)
        {
            RequestId = requestId;
        }

        public bool HasInfo => Errors.Any(validationResult => validationResult.ValidationSeverity == Domain.Common.Validation.ValidationSeverity.Info);
        public bool HasWarning => Errors.Any(validationResult => validationResult.ValidationSeverity == Domain.Common.Validation.ValidationSeverity.Warning);
        public bool HasError => Errors.Any(validationResult => validationResult.ValidationSeverity == Domain.Common.Validation.ValidationSeverity.Error);

        public void SetResult(TValue value)
        {
            Value = value;
        }

        public void SetValidationResult(ValidationResult validationResult)
        {
            _infos?.AddRange(validationResult.ValidationItems.Where(x => x.ValidationSeverity == ValidationSeverity.Info).Select(x => ValidationResultItem.FromValidationItem(x)));
            _warnings?.AddRange(validationResult.ValidationItems.Where(x => x.ValidationSeverity == ValidationSeverity.Warning).Select(x => ValidationResultItem.FromValidationItem(x)));
            _errors?.AddRange(validationResult.ValidationItems.Where(x => x.ValidationSeverity == ValidationSeverity.Error).Select(x => ValidationResultItem.FromValidationItem(x)));
        }

        public void SetUnauthorizedResult()
        {
            Value = null;
            IsAuthorized = false;
        }
    }
}
