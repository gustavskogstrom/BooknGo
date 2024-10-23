using BooknGoApi.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BooknGoApi.Data
{
    public class BooknGoDbContext : IdentityDbContext
    {
        public BooknGoDbContext(DbContextOptions<BooknGoDbContext> options) : base(options) 
        {
        }

        DbSet<Availability> Availabilities { get; set; }
        DbSet<Booking> Bookings { get; set; }
        DbSet<Resource> Resources { get; set; }
        DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Resource)
                .WithMany(r => r.Bookings)
                .HasForeignKey(b => b.ResourceId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Customer)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.CustomerId);
        }
    }
}
