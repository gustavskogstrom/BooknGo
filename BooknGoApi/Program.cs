using BooknGoApi.Data;
using BooknGoApi.Data.Models;
using BooknGoApi.Interface;
using BooknGoApi.Middleware;
using BooknGoApi.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

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
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            builder.Services.AddAutoMapper(typeof(Program));

            builder.Services.AddScoped<IBookingService, BookingService>();
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddScoped<SeedData>();

            builder.Services.AddDbContext<BooknGoDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                   .AddCookie(options =>
                   {
                       options.Cookie.HttpOnly = true;
                       options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                       //options.Cookie.SameSite = SameSiteMode.Strict;

                       // Timeout och sliding expiration
                       options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                       options.LoginPath = "/login";
                    //    options.Cookie.MaxAge = TimeSpan.FromDays(7); // Max time
                   });

            builder.Services.AddAuthorization();

            builder.Services.AddIdentityApiEndpoints<IdentityUser>()
                .AddEntityFrameworkStores<BooknGoDbContext>();

            // Konfigurera CORS
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.WithOrigins("http://localhost:5173")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });

            var app = builder.Build();

            // Seed the database.
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var seedData = services.GetRequiredService<SeedData>();
                seedData.Seed();
            }

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapIdentityApi<IdentityUser>();

            app.UseMiddleware<Register>();

            // app.UseHttpsRedirection();
            app.UseCors();
            //app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var userService = scope.ServiceProvider.GetRequiredService<IUserService>();
                userService.CreateDefaultUserAsync().GetAwaiter().GetResult();
            }

            app.Run();
        }
    }
}