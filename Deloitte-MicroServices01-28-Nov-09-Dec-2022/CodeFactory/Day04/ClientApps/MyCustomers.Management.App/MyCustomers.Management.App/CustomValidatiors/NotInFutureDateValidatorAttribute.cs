using System.ComponentModel.DataAnnotations;

namespace MyCustomers.Management.App.CustomValidatiors
{
    public class NotInFutureDateValidatorAttribute : ValidationAttribute
    {
        ValidationResult result = null;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DateTime enteredDate = (DateTime)value;

            if(enteredDate.Date <= DateTime.Now.Date)
            {
                //do nothing
            }
            else
            {
                result = new ValidationResult("InvalidDate");
            }
            return result;
        }
    }
}
