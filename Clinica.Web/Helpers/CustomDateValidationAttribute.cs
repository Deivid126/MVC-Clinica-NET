using System.ComponentModel.DataAnnotations;

namespace Clinica.Web.Helpers
{
    public class CustomDateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime data = (DateTime)value;

            if (data.Date < DateTime.Now.Date)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
