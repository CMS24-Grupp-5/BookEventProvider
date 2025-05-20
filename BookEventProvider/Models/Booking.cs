using System.ComponentModel.DataAnnotations;

namespace BookEventProvider.Models;

public class Booking
{
    [Key]
    public int BookingId { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;
    
    [Required]
    public int EventId { get; set; }

    public DateTime BookingDate { get; set; } = DateTime.UtcNow;

}
