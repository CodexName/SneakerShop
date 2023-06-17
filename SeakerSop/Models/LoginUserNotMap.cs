using SeakerSop.AttributeValidation;
using System.ComponentModel.DataAnnotations;

namespace SeakerSop.Models
{
    public class LoginUserNotMap
    {
        [Required(ErrorMessage = ErrorMessage.AdressRequired)]
        [PasswordValidation]
        public long PasswordLogin { get; set; }

        [Required(ErrorMessage = ErrorMessage.GmailRequired)]
        [EmailAddress]
        public string GmailLogin { get; set; }
    }
}
