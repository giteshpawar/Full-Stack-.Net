using System.ComponentModel.DataAnnotations;

namespace _10_Aug.Models
{
    public class State
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "State name is required")]
        [StringLength(100)]
        public string StateName { get; set; } = string.Empty;
    }
}