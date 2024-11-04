using Microsoft.AspNetCore.Identity;

namespace BooknGoApi.Interface
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(string userName, string password);
        Task<IdentityUser> GetUserByNameAsync(string userName);
        Task<IdentityResult> CreateDefaultUserAsync();
    }
}
