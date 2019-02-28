using System.ComponentModel.DataAnnotations;

namespace Web.ITroc.Core
{
    public class CustomValidationAttribute : ValidationAttribute
    {
        private readonly int _lowAge;
        private readonly int _highAge;

        public CustomValidationAttribute(int lowAge, int highAge)
        {
            _lowAge = lowAge;
            _highAge = highAge;
            ErrorMessage = "{0} - name of the field, dsqg sqdgsdg";
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //if (xxxxx)
            //{
            //    return new ValidationResult("xxxxx");
            //}

            return ValidationResult.Success;
        }
    }
}