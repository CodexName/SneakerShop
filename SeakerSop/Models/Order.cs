using SeakerSop.AttributeValidation;
using System.ComponentModel.DataAnnotations;

namespace SeakerSop.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public SneakersProduct Product { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }

        public DateTime Date { get; set; }

        public bool Status { get; set; }
        public string Email { get; set; }

        public int NumberPostOffice { get; set; }
        public long PhoneNumber { get; set; }

        public int? UserId { get; set; }

        public User Users { get; set; } = null!;

    }
}
