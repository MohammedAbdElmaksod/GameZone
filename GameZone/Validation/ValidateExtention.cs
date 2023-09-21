using System.ComponentModel.DataAnnotations;

namespace GameZone.Validation
{
    public class ValidateExtension : ValidationAttribute
    {
        private readonly string _allowedExtension;

        public ValidateExtension(string allowedExtension)
        {
            _allowedExtension = allowedExtension;
        }
        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file is not null)
            {
                var extension = Path.GetExtension(file.FileName);

                var isAllowed = _allowedExtension.Split(',').Contains(extension, StringComparer.OrdinalIgnoreCase);
                return isAllowed ? ValidationResult.Success : 
                    new ValidationResult($"Only ({_allowedExtension}) are Allowed");
            }
            return ValidationResult.Success;
        }
    }
}
