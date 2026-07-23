using System.ComponentModel.DataAnnotations;

namespace AutomobileManagementSystem.Models
{
    public class Automobile
    {
        [Required]
        public int VehicleID { get; set; }

        [Required]
        [StringLength(50)]
        public string VehicleName { get; set; }

        [Required]
        [StringLength(50)]
        public string Brand { get; set; }

        [Required]
        [Range(2000, 2100)]
        public int ModelYear { get; set; }

        [Required]
        [Range(10000, 10000000)]
        public decimal Price { get; set; }

        [Required]
        public string FuelType { get; set; }
    }
}