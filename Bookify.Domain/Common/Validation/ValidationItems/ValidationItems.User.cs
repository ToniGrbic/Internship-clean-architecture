namespace Bookify.Domain.Common.Validation.ValidationItems
{
    public static partial class ValidationItems
    {
        public static class User
        {
            public static string CodePrefix = nameof(User);

            public static readonly ValidationItem ItemNotFound = new ValidationItem()
            {
                Code = $"{CodePrefix}1",
                Message = "Podatak ne postoji",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };

            public static readonly ValidationItem NameMaxLength = new ValidationItem()
            {
                Code = $"{CodePrefix}2",
                Message = $"Ime ne smije biti duže od {Entities.Users.User.NameMaxLength} znakova",
                ValidationSeverity = ValidationSeverity.Error,
                ValidationType = ValidationType.BussinessRule
            };
        }
    }
}
