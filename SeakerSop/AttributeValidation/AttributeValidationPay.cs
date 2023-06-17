using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SeakerSop.AttributeValidation
{
    public class CVCCodeValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string cvcCode = value.ToString();
            int tempCvcvalue;
            int cvcLength = cvcCode.Length;
            if (cvcLength != 3)
            {
                return new ValidationResult("CVC код должен иметь трех значное значение");
            }
            foreach (char item in cvcCode)
            {
                bool parseboolvalue = int.TryParse(item.ToString(), out tempCvcvalue);
                if (parseboolvalue == false)
                {
                    return new ValidationResult("CVC код не должен содержать буквенные значения");
                }
            }
            return ValidationResult.Success;
        }
    }
    public class CardNumberValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string cardnumber = value.ToString();
            int tempcardnumbervalue;
            int cvcLength = cardnumber.Length;
            foreach (char item in cardnumber)
            {
                bool parseboolvalue = int.TryParse(item.ToString(), out tempcardnumbervalue);
                if (parseboolvalue == false)
                {
                    return new ValidationResult("Карта не должна содержать буквенные значения");
                }
            }
            if (cvcLength != 11)
            {
                return new ValidationResult("Номер карты должен иметь 11 символов");
            }
            
            return ValidationResult.Success;
        }
    }
    public class DateValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string datenumber = value.ToString();
            int tempdatenumbervalue;
            int cvcLength = datenumber.Length;
            if (cvcLength != 4)
            {
                return new ValidationResult("Дата должна содержать 4 символа");
            }
            foreach (char item in datenumber)
            {
                bool parseboolvalue = int.TryParse(item.ToString(), out tempdatenumbervalue);
                if (parseboolvalue == false)
                {
                    return new ValidationResult("Дата не должна содержать буквенные значения");
                }
            }
            return ValidationResult.Success;
        }
    }
}
