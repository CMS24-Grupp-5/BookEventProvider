using BookEventProvider.Models;
using BookEventProvider.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookEventProvider.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private readonly BookingService _bookingService;

        public BookingController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        public async Task<IActionResult> Book([FromBody] Booking booking)
        {
            try
            {
                Console.WriteLine($"Received userId: {booking.UserId}, eventId: {booking.EventId}");

                if (string.IsNullOrEmpty(booking.UserId))
                    return BadRequest("UserId is missing.");

                var createdBooking = await _bookingService.CreateBookingAsync(booking.UserId, booking.EventId);

                Console.WriteLine($"Booking created for user {booking.UserId} and event {booking.EventId}");

                return Ok(createdBooking);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Booking failed: {ex.Message}");
                return StatusCode(500, $"Server error: {ex.Message}");
            }
        }


        [HttpGet("By-user")]
        public async Task<IActionResult> GetBookingsByUserId([FromQuery] string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return BadRequest("UserId is missing.");

            var bookings = await _bookingService.GetBookingsForUserAsync(userId);
            return Ok(bookings);
        }

        [HttpDelete("{bookingId}")]
        public async Task<IActionResult> CancelBooking(int bookingId)
        {
            var success = await _bookingService.CancelBookingAsync(bookingId);
            if (!success)
                return NotFound("Booking not found.");

            return Ok("Your booking has been cancelled.");
        }

        [HttpGet("MyBookings")]
        public async Task<IActionResult> GetMyUserId([FromQuery] string userId, [FromQuery] string eventId)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(eventId))
                return BadRequest("UserId or EventId not found.");

            Console.WriteLine($"Received UserId: {userId}, EventId: {eventId}");

            var booking = await _bookingService.CreateBookingAsync(userId, int.Parse(eventId));
            return Ok("Your booking was sucessful.");
        }
    }
}
