using _10_Aug.Models;
using _10_Aug.Repository;
using Microsoft.AspNetCore.Mvc;

namespace _10_Aug.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService bookingService;

        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }

        [HttpPost]
        public IActionResult CreateBooking([FromBody] Booking booking)
        {
            try
            {
                var result = bookingService.CreateBooking(booking);

                return CreatedAtAction(
                    nameof(GetBookingById),
                    new { id = result.Id },
                    result
                );
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }

        [HttpGet]
        public IActionResult GetBookings()
        {
            var bookings = bookingService.GetBookings();

            return Ok(bookings);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookingById(int id)
        {
            var booking = bookingService.GetBookingById(id);

            if (booking == null)
            {
                return NotFound(new
                {
                    message = "Booking not found"
                });
            }

            return Ok(booking);
        }
    }
}