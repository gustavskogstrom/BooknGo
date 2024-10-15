using BooknGo.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BooknGo.Data
{
    public class TicketingContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<EventDetail> Events { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public TicketingContext(DbContextOptions<TicketingContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Event)
                .WithMany(e => e.Tickets)
                .HasForeignKey(t => t.EventId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tickets)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
