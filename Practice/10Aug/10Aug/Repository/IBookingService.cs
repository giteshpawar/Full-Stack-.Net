using _10_Aug.Models;

namespace _10_Aug.Repository
{
    public interface IBookingService
    {
        Booking CreateBooking(Booking booking);
        List<Booking> GetBookings();
        Booking? GetBookingById(int id);
    }
}