using SeakerSop.AttributeValidation;
using System.ComponentModel.DataAnnotations;

namespace SeakerSop.Models
{
    public class OrderNotMap
    {
        [Required(ErrorMessage = ErrorMessage.NameRequired)]
        [StringLength(12, MinimumLength = 3, ErrorMessage = ErrorMessage.NameLengthError)]
        [NameOrderingValidation]
        public string Name { get; set; }
        [Required(ErrorMessage = ErrorMessage.LastNameRequired)]
        [StringLength(15, MinimumLength = 5, ErrorMessage = ErrorMessage.LastNameLengthError)]
        [LastNameOrderingValidation]
        public string LastName { get; set; }
        [SurNameOrderingValidation]
        public string Surname { get; set; }
        [PhoneNumberOrderingValidation]
        public long PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        
        public int NumberPostOffice { get; set; }
    }
}
