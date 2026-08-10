using System.ComponentModel.DataAnnotations;

namespace _10_Aug.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Passenger is required")]
        public int PassengerId { get; set; }

        [Required(ErrorMessage = "Bus is required")]
        public int BusId { get; set; }

        [Required(ErrorMessage = "State is required")]
        public int StateId { get; set; }

        [Required(ErrorMessage = "Travel date is required")]
        public DateTime TravelDate { get; set; }

        [Required(ErrorMessage = "Seat number is required")]
        [Range(1, 50, ErrorMessage = "Seat number must be between 1 and 50")]
        public int SeatNumber { get; set; }

        public Passenger? Passenger { get; set; }

        public Bus? Bus { get; set; }

        public State? State { get; set; }
    }
}