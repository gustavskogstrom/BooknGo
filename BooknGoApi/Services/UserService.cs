using BooknGoApi.Interface;
using Microsoft.AspNetCore.Identity;

namespace BooknGoApi.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<IdentityResult> CreateUserAsync(string userName, string password)
        {
            var user = new IdentityUser
            {
                UserName = userName,
                Email = $"{userName}@example.com"
            };

            return await _userManager.CreateAsync(user, password);
        }

        public async Task<IdentityUser> GetUserByNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<IdentityResult> CreateDefaultUserAsync()
        {
            string userName = _configuration["UserSettings:UserName"];
            string password = _configuration["UserSettings:Password"];

            if (await _userManager.FindByNameAsync(userName) == null)
            {
                var user = new IdentityUser
                {
                    UserName = userName,
                    Email = $"{userName}@example.com"
                };
                return await _userManager.CreateAsync(user, password);
            }

            return IdentityResult.Success;
        }
    }
}
