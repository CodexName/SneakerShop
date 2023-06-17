using Microsoft.Extensions.Hosting;
using SeakerSop.AttributeValidation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeakerSop.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = ErrorMessage.NameRequired)]
        [StringLength(12, MinimumLength = 3, ErrorMessage = ErrorMessage.NameLengthError)]
        [NameValidation]
        public string? Name { get; set; }

        [Required(ErrorMessage = ErrorMessage.AgeRequired)]
        [StringLength(15,MinimumLength = 5,ErrorMessage = ErrorMessage.LastNameLengthError)]
        [LastNameValidation]
        public string LastName { get; set; }

        [Required(ErrorMessage = ErrorMessage.AdressRequired)]
        [Range(14,80, ErrorMessage = ErrorMessage.AgeError )]
        public int? Age { get; set; }

        [Required(ErrorMessage = ErrorMessage.AdressRequired)]
        [AdressValidation]
        [StringLength(20, MinimumLength = 8, ErrorMessage = ErrorMessage.AdressLengthError)]
        public string? Adress { get; set; }

        [Required(ErrorMessage = ErrorMessage.GmailRequired)]
        [EmailAddress]
        public string Gmail { get; set; }

        [Required(ErrorMessage = ErrorMessage.AdressRequired)]
        [PasswordValidation]
        public long Password { get; set; }

        [NotMapped]
        [Compare("Password" , ErrorMessage = ErrorMessage.PasswordCompareError)]
        public long? ComparePassword { get; set; }

        public ICollection<Order> Orders { get; set; } 
    }
}
