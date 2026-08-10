using System.ComponentModel.DataAnnotations;

namespace _10_Aug.Models
{
    public class Passenger
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [Phone(ErrorMessage = "Number is not correct")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email id is required")]
        [EmailAddress(ErrorMessage = "Email id is not correct")]
        public string Email { get; set; } = string.Empty;
    }
}