using SeakerSop.AttributeValidation;
using System.ComponentModel.DataAnnotations;

namespace SeakerSop.Models
{
    public class RequisitesUser
    {
        public int Id { get; set; }
        [Required(ErrorMessage = ErrorMessage.CardNumberRequired)]
        [CardNumberValidation]
        public long CardNumber { get; set; }
        [Required(ErrorMessage = ErrorMessage.DateRequired)]
        [DateValidation]
        public int Date { get; set; }
        [Required(ErrorMessage = ErrorMessage.CVCCodeRequired)]
        [CVCCodeValidation]
        public int CVCode { get; set; }
        public double Balance { get; set; }
    }
}
