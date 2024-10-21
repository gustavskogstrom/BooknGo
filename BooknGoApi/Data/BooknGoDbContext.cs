using BooknGoApi.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BooknGoApi.Data
{
    public class BooknGoDbContext : DbContext
    {
        public BooknGoDbContext(DbContextOptions<BooknGoDbContext> options) : base(options) 
        {
        }

        DbSet<Availability> Availabilities { get; set; }
        DbSet<Booking> Bookings { get; set; }
        DbSet<Resource> Resources { get; set; }
        DbSet<User> Users { get; set; }
    }
}
