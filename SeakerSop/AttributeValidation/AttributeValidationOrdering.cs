using PhoneNumbers;
using System.ComponentModel.DataAnnotations;

namespace SeakerSop.AttributeValidation
{
    public class NameOrderingValidationAttribute : ValidationAttribute
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
    public class LastNameOrderingValidationAttribute : ValidationAttribute
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
    public class SurNameOrderingValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            int number;
            foreach (char item in value.ToString())
            {
                bool parseboolvalue = int.TryParse(item.ToString(), out number);
                if (parseboolvalue)
                {
                    return new ValidationResult("Отчество не должно содержать цифры");
                }
            }
            return ValidationResult.Success;
        }
    }
    public class PhoneNumberOrderingValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
 
            string phoneNumber = value.ToString();
            if (phoneNumber.Length != 9)
            {
                return new ValidationResult("Номер телефона должен содержать 10 цифр");
            }
            PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();
            bool isValidNumber = phoneNumberUtil.IsValidNumber(phoneNumberUtil.Parse(phoneNumber, "UA"));
            if (isValidNumber)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Не корректно введен номер ");
          
        }
    }
}
