using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO.Validations
{
    public class ValidEnumAttribute : ValidationAttribute
    {
        private readonly Type _enumType;

        public ValidEnumAttribute(Type enumType)
        {
            _enumType = enumType;
        }

        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && !Enum.IsDefined(_enumType, value))
            {
                return new ValidationResult($"Invalid value for enum {_enumType.Name}");
            }

            return ValidationResult.Success;
        }
    }
}
