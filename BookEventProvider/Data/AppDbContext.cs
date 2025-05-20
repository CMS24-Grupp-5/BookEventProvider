using BookEventProvider.Models;
using Microsoft.EntityFrameworkCore;

namespace BookEventProvider.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Booking> Bookings { get; set; }
}