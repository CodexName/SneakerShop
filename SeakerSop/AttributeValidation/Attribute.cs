using System.ComponentModel.DataAnnotations;

namespace SeakerSop.AttributeValidation
{
    public class NameValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int number;
            foreach (char item in value.ToString())
            {
                bool parseboolvalue = int.TryParse(item.ToString(), out number);
                if (parseboolvalue)
                {
                    return new ValidationResult("Имя не должно содержать цифры");
                }
            }
            return ValidationResult.Success;
        }
    }

    public class LastNameValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int number;
            foreach (char item in value.ToString())
            {
                bool parseboolvalue = int.TryParse(item.ToString(), out number);
                if (parseboolvalue)
                {
                    return new ValidationResult("Фамилия не должна содержать цифры");
                }
            }
            return ValidationResult.Success;
        }
    }

    public class AdressValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int number;
            foreach (char item in value.ToString())
            {
                bool parseboolvalue = int.TryParse(item.ToString(), out number);
                if (parseboolvalue)
                {
                    return new ValidationResult("Адресс не должен содержать цифры");
                }
            }
            return ValidationResult.Success;
        }
    }
    public class PasswordValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            double todoublevalue = Convert.ToDouble(value);
            int DigidCount = (int)Math.Log10(todoublevalue) + 1;
            if (DigidCount < 8)
            {
                return new ValidationResult("Пароль должен содержать 8 символов");
            }
            return ValidationResult.Success;
        }
    }
}
