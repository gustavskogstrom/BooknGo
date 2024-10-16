using BooknGo.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BooknGo.Data
{
    public class BookNGoDbContext : DbContext
    {
        public BookNGoDbContext(DbContextOptions<BookNGoDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Payment> Payments { get; set; }
    }
}
