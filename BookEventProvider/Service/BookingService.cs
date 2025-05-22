using BookEventProvider.Models;
using BookEventProvider.Repository;

namespace BookEventProvider.Service
{
    public class BookingService
    {
        private readonly BookingRepository _repository;

        public BookingService(BookingRepository repository)
        {
            _repository = repository;
        }

        public async Task<Booking> CreateBookingAsync(string userId, int eventId)
        {
            var booking = new Booking
            {
                UserId = userId,
                EventId = eventId,
                BookingDate = DateTime.UtcNow
            };

            return await _repository.AddBookingAsync(booking);
        }

        public async Task<List<Booking>> GetBookingsForUserAsync(string userId)
        {
            return await _repository.GetBookingsByUserIdAsync(userId);
        }

        public async Task<bool> CancelBookingAsync(int bookingId)
        {
            return await _repository.DeleteBookingAsync(bookingId);
        }
    }
}
