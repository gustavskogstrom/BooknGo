using BooknGoApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BooknGoApi.Data
{
    public class SeedData
    {
        private readonly BooknGoDbContext _context;

        public SeedData(BooknGoDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            // Ensure the database is up to date.
            _context.Database.Migrate();

            // Seed data if not already seeded.
            if (!_context.Customers.Any())
            {
                var customers = LoadJsonData<Customer>("Data/Json/Customer.json");
                _context.Customers.AddRange(customers);
            }

            if (!_context.Bookings.Any())
            {
                var bookings = LoadJsonData<Booking>("Data/Json/Booking.json");
                _context.Bookings.AddRange(bookings);
            }

            _context.SaveChanges();
        }

        private List<T> LoadJsonData<T>(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }
    }
}