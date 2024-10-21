
using BooknGoApi.Data;
using BooknGoApi.Interface;
using BooknGoApi.Services;
using Microsoft.EntityFrameworkCore;

namespace BooknGoApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddScoped<IAvailabilityService, AvailabilityService>();
            builder.Services.AddScoped<IBookingService, BookingService>();
            builder.Services.AddScoped<IResourceService, ResourceService>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddDbContext<BooknGoDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
