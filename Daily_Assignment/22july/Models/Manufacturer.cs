using System.ComponentModel.DataAnnotations;

namespace AutomobileManagementSystem.Models
{
    public class Manufacturer
    {
        [Required]
        [StringLength(50)]
        public string ManufacturerName { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{10}$")]
        public string ContactNumber { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}