using System.ComponentModel.DataAnnotations;

namespace GameZone.Validation
{
    public class ValidateFileMaxSize : ValidationAttribute
    {
        private readonly int _maxSize;

        public ValidateFileMaxSize(int maxSize)
        {
            _maxSize = maxSize;
        }

        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if(file?.Length> _maxSize)
            {
                return new ValidationResult($"The Maximum Size Allowed is {_maxSize / (1024 * 1024)} MB");
            }
            return ValidationResult.Success;

        }
    }
}
